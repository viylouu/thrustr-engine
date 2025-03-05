using System.Numerics;

namespace thrustr.athr;

public class athr {
    string _data;
    List<athr_token> _toks;


    // properties
    public float base_width = 16;
    public float base_height = 16;

    // animations
    public List<athr_anim> anims;


    public int idx = 0;


    public char peek(int ahead) {
        if(idx+ahead >= _data.Length)
            return '\0';
        return _data[idx+ahead];
    }

    public char cur => peek(0);


    public athr(string data) => _data = data;

    public void parse() {
        // make the toks

        _toks = new();

        idx = 0;

        for(;;) {
            if(idx >= _data.Length || cur == '\0')
                break;

            if(char.IsLetter(cur)) {
                string text = "";
                while(char.IsLetter(cur)) { text += cur; idx++; }
                _toks.Add(new() { dat = text, type = athr_type.text });
            }

            if(char.IsDigit(cur)) {
                string text = "";
                while(char.IsDigit(cur)) { text += cur; idx++; }
                _toks.Add(new() { dat = text, type = athr_type.num });
            }

            while(char.IsWhiteSpace(cur)) idx++;
        }

        // go thru the toks

        idx = 0;

        bool doing_anims = false;

        anims = new();

        for(;;) {
            if(idx >= _toks.Count)
                return;

            if(!doing_anims)
                switch(_toks[idx].dat) {
                    case "bw": 
                        base_width = Convert.ToSingle(_toks[++idx].dat); break;
                    case "bh":
                        base_height = Convert.ToSingle(_toks[++idx].dat); break;
                    case "anim":
                        doing_anims = true; break;
                }
            else {
                string anim_name = _toks[idx].dat;
                idx++;
                List<Vector2> posses = new();
                while(_toks[idx].type == athr_type.num) {
                    posses.Add(new(Convert.ToSingle(_toks[idx++].dat),Convert.ToSingle(_toks[idx++].dat)));

                    if(idx >= _toks.Count)
                        break;
                }

                anims.Add(new() { name = anim_name, posses = posses.ToArray() });
            }

            idx++;
        }
    }
}