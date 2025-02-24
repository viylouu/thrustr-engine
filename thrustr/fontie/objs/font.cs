using SimulationFramework.Drawing;

namespace thrustr.basic;

public class font {
    public ITexture tex;
    public string chars;
    public int charw, charh, chart, charb;
    public chardata[] data;

    public caseness fcase;

    public static font gen_font(ITexture _tex, string _chars, int chartop = 0, int charbot = -1) {
        font font = new();

        int _charw = _tex.Width/_chars.Length, _charh = _tex.Height;

        font.tex = _tex;
        font.charw = _charw;
        font.charh = _charh;
        font.chars = _chars;
        font.chart = chartop;
        font.charb = charbot==-1?_charh:charbot;
        font.data = new chardata[_chars.Length];
        font.fcase = caseness.both;

        for(int i = 0; i < _chars.Length; i++) {
            font.data[i] = new chardata();
            
            int w = 0;

            for(int x = 0; x < _charw; x++)
                for(int y = 0; y < _charh; y++)
                    if(_tex[i*_charw+x,y].A > 0)
                        w = x;
            
            font.data[i].width = w+2;
        }

        return font;
    }

    public static font gen_font_wpath(ITexture _tex, string path, int chartop = 0, int charbot = -1) {
        string _chars = new StreamReader(path).ReadToEnd();
        return gen_font(_tex, _chars, chartop,charbot);
    }
}