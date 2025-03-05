using SimulationFramework;

using thrustr.basic;
using thrustr.utils;
using thrustr.PROTO.lighting;

using SimulationFramework.Input;

partial class _main {
    static void rend(Canvas c) {
        c.Clear(Color.Black);

        lightingshader shad = new();
        shad.mp = Mouse.Position;

        c.Fill(shad);
        c.DrawRect(0,0,640,360);

        c.thr_DrawText($"{math.round(1/Time.DeltaTime)} fps", 3,3);
    }
}