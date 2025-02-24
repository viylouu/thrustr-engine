using SimulationFramework.Drawing;
using SimulationFramework;

using System.Numerics;

namespace thrustr.basic;

public static class fontie {
    public static ITexture dfonttex = Graphics.LoadTexture("thrustr/assets/fonts/dfont.png");
    public static font dfont = font.gen_font_wpath(dfonttex, "thrustr/assets/fonts/dfont.txt", 4, 10);

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

    public static void f_DrawText(this ICanvas c, string text, Vector2 pos, Alignment align, float scale, font f, Color? col) => f_DrawText(c,text,pos.X,pos.Y,align,scale,f,col?.ToColorF() ?? null);
    public static void f_DrawText(this ICanvas c, string text, Vector2 pos, Alignment align = Alignment.TopLeft, float scale = 1f, font f = null, ColorF? col = null) => f_DrawText(c,text,pos.X,pos.Y,align,scale,f,col);
    public static void f_DrawText(this ICanvas c, string text, float px, float py, Alignment align, float scale, font f, Color col) => f_DrawText(c,text,px,py,align,scale,f,col.ToColorF());

    public static void f_DrawText(this ICanvas c, string text, float px, float py, Alignment align = Alignment.TopLeft, float scale = 1f, font f = null, ColorF? col = null) {
        if(f == null)
           f = dfont; 

        if(f.fcase == caseness.lower)
            text = text.ToLower();
        else if(f.fcase == caseness.upper)
            text = text.ToUpper();

        ColorF _c = col ?? ColorF.White; 

        switch(align) {
            case Alignment.TopLeft:
                py -= f.chart;
                break;
            case Alignment.BottomLeft:
                py += f.charh-f.charb;
                break;
            case Alignment.TopRight:
                py -= f.chart;
                px -= predicttextwidth(text,scale,f);
                break;
            case Alignment.BottomRight:
                py += f.charh-f.charb;
                px -= predicttextwidth(text,scale,f);
                break;
            case Alignment.CenterLeft:
                py += (f.charh-f.charb + -f.chart) * .5f;
                break;
            case Alignment.CenterRight:
                py += (f.charh-f.charb + -f.chart) * .5f;
                px -= predicttextwidth(text,scale,f);
                break;
            case Alignment.Center:
                py += (f.charh-f.charb + -f.chart) * .5f;
                px -= predicttextwidth(text,scale,f)/2f;
                break;
            case Alignment.TopCenter:
                py -= f.chart;
                px -= predicttextwidth(text,scale,f)-f.charw/2f;
                break;
            case Alignment.BottomCenter:
                py += f.charh-f.charb;
                px -= predicttextwidth(text,scale,f)/2f;
                break;
        }

        float x = 0;
        for (int i = 0; i < text.Length; i++) {
            if (text[i] == ' ')
                x += f.data[f.chars.IndexOf(' ')].width*scale;
            else {
                int ch = f.chars.IndexOf(text[i]);

                if (ch == -1) {
                    c.DrawTexture(
                        f.tex,
                        new Rectangle(0,0,f.charw,f.charh),
                        new Rectangle(px+x,py,f.charw*scale,f.charh*scale,align),
                        _c
                    );
                    x += f.data[f.chars.IndexOf(' ')].width*scale;
                } else { 
                    c.DrawTexture(
                        f.tex,
                        new Rectangle(ch*f.charw,0,f.charw,f.charh),
                        new Rectangle(px+x,py,f.charw*scale,f.charh*scale,align),
                        _c
                    );
                    x += f.data[f.chars.IndexOf(text[i])].width*scale;
                }
            }
        }

        c.Flush();
    }
}