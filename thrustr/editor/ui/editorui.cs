using SimulationFramework;
using SimulationFramework.Input;
using thrustr.basic;
using thrustr.utils;

namespace thrustr.editor;

public static class editorui {
    public static bool enabled;

    public static editortheme theme;


    static List<thr_editor_button> buttons = new () { //werid
        new() { text = "hi", function = add },
    };

    static void add() {
        buttons.Add(new() { text = "hi", function = add });
    }


    static float tbadd;
    static float maxbuttonsize;


    public static void load() {
        theme = new() {
            base_color = new(31,30,33),
            button_color = new(44,43,46),
            highlighted_button_color = new(54,53,56),

            button_scale_amount = 4f,

            button_highlight_speed = 4f,
            button_scale_speed = 6f
        };
    }


    public static void render(Canvas c) {
        if(!enabled)
            return;

        c.Fill(theme.base_color);
        c.DrawRect(0,0,c.Width,fontie.dfont.charh+4+maxbuttonsize);

        maxbuttonsize = 0;

        float x = 2;
        for(int i = 0; i < buttons.Count; i++) {
            var but = buttons[i];

            float width = 8+fontie.predicttextwidth(but.text) +but.size*theme.button_scale_amount;
            float height = fontie.dfont.charh +but.size*theme.button_scale_amount;

            // -----------------------------------------------------------------------

            c.Fill(Color.Lerp(theme.button_color,theme.highlighted_button_color,but.tint));
            c.DrawRoundedRect(x,2,width,height,4);

            c.Fill(Color.White);
            c.thr_DrawText(but.text, x+width/2f,2+height/2f, Alignment.Center); 

            // -----------------------------------------------------------------------

            if(coll.poirect(Mouse.Position, x,2, width,fontie.dfont.charh)) {
                but.tint += ease.dyn(but.tint,1,theme.button_highlight_speed);
                but.size += ease.dyn(but.size,1,theme.button_scale_speed);

                if(Mouse.IsButtonPressed(MouseButton.Left)) but.function();
            } else { 
                but.tint += ease.dyn(but.tint,0,theme.button_highlight_speed); 
                but.size += ease.dyn(but.size,0,theme.button_scale_speed);
            }

            but.tint = math.clamp01(but.tint);
            but.size = math.clamp01(but.size);

            // -----------------------------------------------------------------------

            x += width+2;

            if(height-fontie.dfont.charh > maxbuttonsize)
                maxbuttonsize = height-fontie.dfont.charh;
        }
    }
}