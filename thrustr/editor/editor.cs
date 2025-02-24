using SimulationFramework.Drawing;

using thrustr.basic;

namespace thrustr.editor;

public static class editorui {
    public static bool enabled = false;

    public static editortheme theme;


    public static void load() {
        theme = new() {
            base_color = new(31,30,33),
            button_color = new(44,43,46)
        };
    }


    public static void render(ICanvas c) {
        if(!enabled)
            return;

        c.Fill(theme.base_color);
        c.DrawRect(0,0,c.Width,fontie.dfont.charh+4);

        c.Fill(theme.button_color);
        c.DrawRoundedRect(2,2,24,fontie.dfont.charh,4);
    }
}