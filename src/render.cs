using SimulationFramework;

using thrustr.basic;
using thrustr.utils;

partial class main {
    static void rend(Canvas c) {
        c.Clear(Color.Black);

        c.Fill(Color.White);
        c.thr_DrawText($"{math.round(1/Time.DeltaTime)} fps", 3,3);
    }
}