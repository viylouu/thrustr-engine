using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.basic;

partial class main {
    static void init() {
        Simulation.SetFixedResolution(320, 180, Color.Black);

        intro.loadintro();
        intro.playintro();

        Window.SetIcon(Graphics.LoadTexture(@"thrustr\assets\sprites\icons\engine small.png"));

        Window.Title = "thrustr engine";
    }
}