using System.Numerics;
using thrustr.basic;

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

            while((cur == '\r' && peek(1) == '\n') || cur == '\n') { 
                _toks.Add(new() { dat = "\n", type = athr_type.nl });
                if(cur == '\r' && peek(1) == '\n') idx+=2;
                else idx++;
            }
            while(char.IsWhiteSpace(cur)) idx++;
        }

        if(handle.debug)
            for(int i = 0; i < _toks.Count; i++)
                if(_toks[i].type == athr_type.nl)
                    Console.WriteLine($"({_toks[i].type})");
                else
                    Console.WriteLine($"({_toks[i].type}, {_toks[i].dat})");

        if(handle.debug) Console.WriteLine();

        // go thru the toks

        idx = 0;

        bool doing_anims = false;

        anims = new();

        for(;;) {
            if(idx >= _toks.Count)
                break;

            if(!doing_anims)
                switch(_toks[idx].dat) {
                    case "bw": 
                        base_width = Convert.ToSingle(_toks[++idx].dat); if(handle.debug) Console.WriteLine($"bw: {base_width}"); break;
                    case "bh":
                        base_height = Convert.ToSingle(_toks[++idx].dat); if(handle.debug) Console.WriteLine($"bh: {base_height}"); break;
                    case "anim":
                        doing_anims = true; idx++; if(handle.debug) Console.WriteLine("anim"); break;
                    case "\n":
                        break;
                }
            else {
                string anim_name = _toks[idx].dat; Console.WriteLine(anim_name); idx+=2;
                List<Vector2> posses = new();
                Dictionary<int,string> events = new();
                while(_toks[idx].type == athr_type.num) {
                    posses.Add(new(Convert.ToSingle(_toks[idx++].dat),Convert.ToSingle(_toks[idx++].dat))); 
                    if(handle.debug) Console.Write($"{posses.Count-1} ({posses[posses.Count-1].X}, {posses[posses.Count-1].Y})");

                    if(idx >= _toks.Count) { if(handle.debug) Console.WriteLine(); break; }

                    if(_toks[idx].type == athr_type.nl) idx++;
                    else if(_toks[idx].type == athr_type.text) { events.Add(posses.Count-1,_toks[idx++].dat); if(handle.debug) Console.Write(" "+_toks[idx-1].dat); }

                    if(handle.debug) Console.WriteLine();

                    if(idx >= _toks.Count)
                        break;
                }

                anims.Add(new() { name = anim_name, posses = posses.ToArray(), events = events });
            }

            idx++;
        }

        if(handle.debug) Console.WriteLine("done!\n");
    }
}