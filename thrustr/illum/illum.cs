partial class illum {
    static illumshad shad = new illumshad();

    static List<light> _l = new();
    static List<tri> _objs = new();

    public static void addlight(Vector2 _pos, float _rad, float _lum, ColorF _col, float _round, bool _clamp) => _l.Add(new light() { pos = _pos, rad = _rad, lum = _lum, col = _col, rnd = _round, clmp = _clamp });

    public static void addobj(Vector2 _p1, Vector2 _p2, Vector2 _p3) => _objs.Add(new tri() { p1 = _p1, p2 = _p2, p3 = _p3 });

    public static void draw(ICanvas c) {
        c.Fill(shad);
        shad.l = _l.ToArray();
        shad.objs = _objs.ToArray();
        c.DrawRect(0,0,Window.Width,Window.Height);
    }

    public static void clearlights() => _l.Clear();
    public static void clearobjs() => _objs.Clear();

    public static void clearscene() {
        _l.Clear();
        _objs.Clear();
    }
}