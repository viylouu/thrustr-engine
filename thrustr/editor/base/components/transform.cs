using System.Numerics;

namespace thrustr.editor;

public class transform : component {
    [thr_visible]
    public Vector3 pos;
    [thr_visible]
    public Vector3 scale;

    public Quaternion rot;

    [thr_visible("X Rotation")]
    public float eul_x = 0f;
    [thr_visible("Y Rotation")]
    public float eul_y = 0f;
    [thr_visible("Z Rotation")]
    public float eul_z = 0f;

    public override void init() => hasscripts = false;
}