public class coll {
    public static bool poipoi(Vector2 x, Vector2 y) => x == y;
    public static bool poipoi(float x, float y, float u, float v) => x==u && y==v;
    public static bool poipoi(Vector2 a, float x, float y) => a.X == x && a.Y == y;
    public static bool poipoi(float x, float y, Vector2 a) => a.X == x && a.Y == y;

    public static bool poicirc(Vector2 cp, float cr, Vector2 pos) => math.sqrdist(cp,pos) <= cr*cr;
    public static bool poicirc(Vector2 cp, float cr, float x, float y) => math.sqrdist(cp,x,y) <= cr*cr;
    public static bool poicirc(float u, float v, float cr, float x, float y) => math.sqrdist(u,v,x,y) <= cr*cr;
    public static bool poicirc(float u, float v, float cr, Vector2 pos) => math.sqrdist(pos,u,v) <= cr*cr;

    public static bool circcirc(Vector2 p1, float r1, Vector2 p2, float r2) => math.sqrdist(p1,p2) <= r1*r1+r2*r2;
    public static bool circcirc(float x1, float y1, float r1, Vector2 p2, float r2) => math.sqrdist(p2,x1,y1) <= r1*r1+r2*r2;
    public static bool circcirc(Vector2 p1, float r1, float x2, float y2, float r2) => math.sqrdist(p1,x2,y2) <= r1*r1+r2*r2;
    public static bool circcirc(float x1, float y1, float r1, float x2, float y2, float r2) => math.sqrdist(x1,y1,x2,y2) <= r1*r1+r2*r2;
}