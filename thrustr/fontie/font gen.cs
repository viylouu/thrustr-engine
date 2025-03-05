using SimulationFramework.Drawing;
using SimulationFramework;

namespace thrustr.basic;

public static class fontie {
    public static ITexture dfonttex = Graphics.LoadTexture("thrustr/assets/fonts/dfont.png");
    public static font dfont = font.gen_font_wpath(dfonttex, "thrustr/assets/fonts/dfont.txt", 4, 10);

    public static ColorF? fill_color;

    public static float predicttextwidth(string text, float scale = 1f, font? f = null) {
        if(f == null)
            f = dfont;

        int w = 0;
        for (int i = 0; i < text.Length; i++) { 
            if (text[i] == ' ')
                w += f.data[f.chars.IndexOf(' ')].width;
            else {
                int ch = f.chars.IndexOf(text[i]);

                if (ch == -1)
                    w += f.data[f.chars.IndexOf(' ')].width;
                else
                    w += f.data[f.chars.IndexOf(text[i])].width;
            }
        }

        return (w-2)*scale;
    }
}