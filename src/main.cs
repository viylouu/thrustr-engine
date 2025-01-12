using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.basic;

partial class main {
    static void Main() {
        Simulation sim = Simulation.Create(init, rend);
        sim.Run();
    }
    
    static void init() {
        Simulation.SetFixedResolution(640, 360, Color.Black);

        intro.initintro();

        Window.SetIcon(Graphics.LoadTexture(@"thrustr\assets\sprites\icons\engine small.png"));

        Window.Title = "thrustr engine";
    }
}