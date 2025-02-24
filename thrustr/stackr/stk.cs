using System.Numerics;

namespace thrustr.stackr;

public struct stk {
    public ssobj obj { get; set; }
    public Vector3 pos { get; set; }
    public float rot { get; set; }

    public stk(ssobj o, Vector3 p, float r) {
        obj = o;
        pos = p;
        rot = r;
    }
}