using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.basic;
using thrustr.utils;

partial class main {
    static void rend(ICanvas c) {
        c.Clear(Color.Black);

        c.f_DrawText($"{math.round(1/Time.DeltaTime)} fps", 9,14-fontie.dfont.chart*3, Alignment.TopLeft, 3);
    }
}