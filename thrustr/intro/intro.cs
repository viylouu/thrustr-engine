using System.Numerics;

using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.utils;

namespace thrustr.basic;

public static class intro {
    static ITexture smallenginetex;
    static ITexture smallsftex;

    public static bool introplayed = true;

    static float introstart = 0;

    static string[] thrustrtext = {
        "thrustr", "engine", "v0.1.5",
        "thrustr engine <0.1.5>"
    };

    static string[] simftext = {
        "simulation", "framework", "v0.3.0 a13",
        "simulation framework <0.3.0-a13>"
    };

    public static void initintro() {
        smallenginetex.trydispose();
        smallsftex.trydispose();

        smallenginetex = Graphics.LoadTexture("thrustr/assets/sprites/icons/engine small.png");
        smallsftex = Graphics.LoadTexture("thrustr/assets/sprites/icons/sf logo small.png");

        introplayed = false;
        introstart = -1;
    }
    
    public static void render(Canvas c, font? f) {
        if((introstart -10f)*1.25f >= 1)
            return;

        if(f == null)
            f = fontie.dfont;

        introstart += Time.DeltaTime;

        if(handle.intro_smallmode) {
            float start = ease.ocirc(introstart*1.25f) *-100 +100;
            float end = ease.icirc((introstart -10f)*1.25f) *100;

            float width = math.max(fontie.predicttextwidth(simftext[3]),fontie.predicttextwidth(thrustrtext[3]))+5;

            c.Fill(Color.Black);
            c.DrawRect(-start-end,c.Height+1, width,fontie.dfont.charh-fontie.dfont.chart+4,Alignment.BottomLeft);

            c.Stroke(Color.White);
            c.DrawRect(-start-end,c.Height+1, width,fontie.dfont.charh-fontie.dfont.chart+4,Alignment.BottomLeft);

            c.Fill(Color.White);

            float ease1 = ease.oelast(introstart*.25f) *-width +width;
            float down1 = ease.iback((introstart -4f)*2f) *32;

            c.thr_DrawText(thrustrtext[3], new(2-ease1, c.Height-3+down1), Alignment.BottomLeft);

            float ease2 = ease.oelast((introstart -5f)*.25f) *-width +width;
            float down2 = ease.iback((introstart -9f)*2f) *32;
            
            c.thr_DrawText(simftext[3], new(2-ease2, c.Height-3+down2), Alignment.BottomLeft);
        } else {
            // bg

            float start = ease.ocirc(introstart*1.25f) *-100 +100;
            float end = ease.icirc((introstart -10f)*1.25f) *100;

            c.Fill(Color.Black);
            c.DrawPolygon(
                new Vector2[] {
                    new(0-start-end,c.Height-32),
                    new(0-start-end,c.Height+24),
                    new(120-start-end,c.Height+24),
                    new(72-start-end,c.Height-32)
                }
            );

            c.Stroke(Color.White);
            c.DrawPolygon(
                new Vector2[] {
                    new(0-start-end,c.Height-32),
                    new(0-start-end,c.Height+24),
                    new(120-start-end,c.Height+24),
                    new(72-start-end,c.Height-32)
                }
            );

            c.Fill(Color.White);

            // thrustr engine

            float ease1 = ease.oelast(introstart*.25f) *-72 +72;
            float ease2 = ease.oelast((introstart-.25f)*.25f) *-52 +52;
            float ease3 = ease.oelast((introstart-.5f)*.25f) *-52 +52;
            float ease4 = ease.oelast((introstart-.75f)*.25f) *-52 +52;

            float down1 = ease.iback((introstart -4f)*2f) *32;
            float down2 = ease.iback((introstart-.25f -4f)*2f) *32;
            float down3 = ease.iback((introstart-.5f -4f)*2f) *32;
            float down4 = ease.iback((introstart-.75f -4f)*2f) *32;

            c.DrawTexture(smallenginetex, new Vector2(48-ease1,c.Height+down1), Alignment.BottomLeft);

            c.thr_DrawText(thrustrtext[0], new(6-ease2, c.Height-28+down2));
            c.thr_DrawText(thrustrtext[1], new(12-ease3, c.Height-22+down3));
            c.thr_DrawText(thrustrtext[2], new(4-ease4, c.Height-2+down4), Alignment.BottomLeft);

            // simulationframework logo

            float ease5 = ease.oelast((introstart -5f)*.25f) *-72 +72;
            float ease6 = ease.oelast((introstart-.25f -5f)*.25f) *-52 +52;
            float ease7 = ease.oelast((introstart-.5f -5f)*.25f) *-52 +52;
            float ease8 = ease.oelast((introstart-.75f -5f)*.25f) *-52 +52;

            float down5 = ease.iback((introstart -9f)*2f) *32;
            float down6 = ease.iback((introstart-.25f -9f)*2f) *32;
            float down7 = ease.iback((introstart-.5f -9f)*2f) *32;
            float down8 = ease.iback((introstart-.75f -9f)*2f) *32;

            c.DrawTexture(smallsftex, new Vector2(48-ease5,c.Height+down5), Alignment.BottomLeft);

            c.thr_DrawText(simftext[0], new(6-ease6, c.Height-28+down6));
            c.thr_DrawText(simftext[1], new(8-ease7, c.Height-22+down7));
            c.thr_DrawText(simftext[2], new(4-ease8, c.Height-2+down8), Alignment.BottomLeft);
        }
    }
}