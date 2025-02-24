using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.editor;

namespace thrustr.basic;

public class handle {
    static Action _start;
    static Action<Canvas> _render;

    // thrustr settings

    public static bool do_intro = true;
    public static font? intro_font = null;


    public static void init(Action start, Action<Canvas> render) {
        _start = start;
        _render = render;

        editorui.load();

        Simulation sim = Simulation.Create(ini, rend);
        sim.Run();
    }

    static void ini() {
        intro.initintro();

        Window.SetIcon(Graphics.LoadTexture("thrustr/assets/sprites/icons/engine small.png"));

        Window.Title = "thrustr engine";

        _start();
    }

    static void rend(ICanvas c) {
        Canvas canv = new(c);

        _render(canv);

        if(do_intro)
            intro.render(canv, intro_font);

        editorui.render(canv);
    }
}