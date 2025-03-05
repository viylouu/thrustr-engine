using System.Numerics;

using SimulationFramework;
using SimulationFramework.Drawing;

using thrustr.utils;

namespace thrustr.stackr;

public static class stackr {
    public static Vector3 cam;
    public static float camrot;

    public static int obj_count => objs.Count;

    public static int layers_rendered;

    public static List<stk> objs = new();
    public static List<(stk a, Vector2 b)> s_objs = new();

    public static ssobj create_obj(ITexture stack, Vector2 size)
        => new ssobj() { stack = stack, size = size, layers = (int)math.round(stack.Height/size.Y) };
    
    public static ssobj create_obj(ITexture stack, Vector2 size, Color tint)
        => new ssobj() { stack = stack, size = size, layers = (int)math.round(stack.Height/size.Y), tint = tint.ToColorF() };

    public static void add_obj(ssobj obj, Vector3? pos = null, float rot = 0) {
        if(pos == null)
            pos = Vector3.Zero;

        objs.Add(new stk(obj, (Vector3)pos, rot));
    }
}