public class coll {
    /// <summary>checks if 2 points are colliding (why would you need this function)</summary>
    public static bool poipoi(Vector2 x, Vector2 y) => x == y;
    public static bool poipoi(float x, float y, float u, float v) => x==u && y==v;
    public static bool poipoi(Vector2 a, float x, float y) => a.X == x && a.Y == y;
    public static bool poipoi(float x, float y, Vector2 a) => a.X == x && a.Y == y;

    /// <summary>checks if a point is colliding with a circle</summary>
    public static bool poicirc(Vector2 cp, float cr, Vector2 pos) => math.sqrdist(cp,pos) <= cr*cr;
    public static bool poicirc(Vector2 cp, float cr, float x, float y) => math.sqrdist(cp,x,y) <= cr*cr;
    public static bool poicirc(float u, float v, float cr, float x, float y) => math.sqrdist(u,v,x,y) <= cr*cr;
    public static bool poicirc(float u, float v, float cr, Vector2 pos) => math.sqrdist(pos,u,v) <= cr*cr;

    /// <summary>checks if 2 circles are colliding</summary>
    public static bool circcirc(Vector2 p1, float r1, Vector2 p2, float r2) => math.sqrdist(p1,p2) <= r1*r1+r2*r2;
    public static bool circcirc(float x1, float y1, float r1, Vector2 p2, float r2) => math.sqrdist(p2,x1,y1) <= r1*r1+r2*r2;
    public static bool circcirc(Vector2 p1, float r1, float x2, float y2, float r2) => math.sqrdist(p1,x2,y2) <= r1*r1+r2*r2;
    public static bool circcirc(float x1, float y1, float r1, float x2, float y2, float r2) => math.sqrdist(x1,y1,x2,y2) <= r1*r1+r2*r2;

    /// <summary>checks if a point is colliding with a rectangle</summary>
    public static bool poirect(float px, float py, float x, float y, float w, float h, Alignment align = Alignment.TopLeft) {
        switch(align) {
            default:
                return px >= x && py >= y && px <= x+w && py <= y+h;
            case Alignment.BottomLeft:
                return px >= x && py >= y-h && px <= x+w && py <= y;
            case Alignment.TopRight:
                return px >= x-w && py >= y && px <= x && py <= y+h;
            case Alignment.BottomRight:
                return px >= x-w && py >= y-h && px <= x && py <= y;
            case Alignment.TopCenter:
                return px >= x-w/2 && py >= y && px <= x+w/2 && py <= y+h;
            case Alignment.BottomCenter:
                return px >= x-w/2 && py >= y-h && px <= x+w/2 && py <= y;
            case Alignment.CenterLeft:
                return px >= x && py >= y-h/2 && px <= x+w && py <= y+w/2;
            case Alignment.CenterRight:
                return px >= x-w && py >= y-h/2 && px <= x && py <= y+w/2;
            case Alignment.Center:
                return px >= x-w/2 && py >= y-h/2 && px <= x+w/2 && py <= y+w/2;
        }
    }
    public static bool poirect(Vector2 p, float x, float y, float w, float h, Alignment align = Alignment.TopLeft) => poirect(p.X,p.Y,x,y,w,h,align);
    public static bool poirect(float px, float py, Vector2 pos, float w, float h, Alignment align = Alignment.TopLeft) => poirect(px,py,pos.X,pos.Y,w,h,align);
    public static bool poirect(Vector2 p, Vector2 pos, float w, float h, Alignment align = Alignment.TopLeft) => poirect(p.X,p.Y,pos.X,pos.Y,w,h,align);
    public static bool poirect(float px, float py, float x, float y, Vector2 size, Alignment align = Alignment.TopLeft) => poirect(px,py,x,y,size.X,size.Y,align);
    public static bool poirect(Vector2 p, float x, float y, Vector2 size, Alignment align = Alignment.TopLeft) => poirect(p.X,p.Y,x,y,size.X,size.Y,align);
    public static bool poirect(float px, float py, Vector2 pos, Vector2 size, Alignment align = Alignment.TopLeft) => poirect(px,py,pos.X,pos.Y,size.X,size.Y,align);
    public static bool poirect(Vector2 p, Vector2 pos, Vector2 size, Alignment align = Alignment.TopLeft) => poirect(p.X,p.Y,pos.X,pos.Y,size.X,size.Y,align);
    public static bool poirect(float px, float py, Rectangle rect) => poirect(px,py,rect.X,rect.Y,rect.Width,rect.Height);
    public static bool poirect(Vector2 p, Rectangle rect) => poirect(p.X,p.Y,rect.X,rect.Y,rect.Width,rect.Height);

    /// <summary>checks if 2 rectangles are colliding</summary>
    public static bool rectrect(float r1x, float r1y, float r1w, float r1h, float r2x, float r2y, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) {
        float r1xl = 0, //x left
              r2xl = 0,
              r1yt = 0, //y top
              r2yt = 0,
              r1xr = 0, //x right
              r2xr = 0,
              r1yb = 0, //y bot
              r2yb = 0;
        
        switch(r1a) {
            default:
                r1xl = r1x; r1xr = r1x + r1w; r1yt = r1y; r1yb = r1y + r1h; break;
            case Alignment.BottomLeft:
                r1xl = r1x; r1xr = r1x + r1w; r1yt = r1y + r1h; r1yb = r1y; break;
            case Alignment.TopRight:
                r1xl = r1x-r1w; r1xr = r1x; r1yt = r1y; r1yb = r1y+r1h; break;
            case Alignment.BottomRight:
                r1xl = r1x-r1w; r1xr = r1x; r1yt = r1y+r1h; r1yb = r1y; break;
            case Alignment.TopCenter:
                r1xl = r1x-r1w/2; r1xr = r1x+r1w/2; r1yt = r1y; r1yb = r1y+r1h; break;
            case Alignment.BottomCenter:
                r1xl = r1x-r1w/2; r1xr = r1x+r1w/2; r1yt = r1y-r1h; r1yb = r1y; break;
            case Alignment.CenterLeft:
                r1xl = r1x; r1xr = r1x+r1w; r1yt = r1y-r1h/2; r1yb = r1y+r1h/2; break;
            case Alignment.CenterRight:
                r1xl = r1x-r1w; r1xr = r1x; r1yt = r1y-r1h/2; r1yb = r1y+r1h/2; break;
            case Alignment.Center:
                r1xl = r1x-r1w/2; r1xr = r1x+r1w/2; r1yt = r1y-r1h/2; r1yb = r1y+r1h/2; break;
        }

        switch(r2a) {
            default:
                r2xl = r2x; r2xr = r2x + r2w; r2yt = r2y; r2yb = r2y + r2h; break;
            case Alignment.BottomLeft:
                r2xl = r2x; r2xr = r2x + r2w; r2yt = r2y + r2h; r2yb = r2y; break;
            case Alignment.TopRight:
                r2xl = r2x-r2w; r2xr = r2x; r2yt = r2y; r2yb = r2y+r2h; break;
            case Alignment.BottomRight:
                r2xl = r2x-r2w; r2xr = r2x; r2yt = r2y+r2h; r2yb = r2y; break;
            case Alignment.TopCenter:
                r2xl = r2x-r2w/2; r2xr = r2x+r2w/2; r2yt = r2y; r2yb = r2y+r2h; break;
            case Alignment.BottomCenter:
                r2xl = r2x-r2w/2; r2xr = r2x+r2w/2; r2yt = r2y-r2h; r2yb = r2y; break;
            case Alignment.CenterLeft:
                r2xl = r2x; r2xr = r2x+r2w; r2yt = r2y-r2h/2; r2yb = r2y+r2h/2; break;
            case Alignment.CenterRight:
                r2xl = r2x-r2w; r2xr = r2x; r2yt = r2y-r2h/2; r2yb = r2y+r2h/2; break;
            case Alignment.Center:
                r2xl = r2x-r2w/2; r2xr = r2x+r2w/2; r2yt = r2y-r2h/2; r2yb = r2y+r2h/2; break;
        }

        return r1xr >= r2xl && r1xl <= r2xr && r1yb >= r2yt && r1yt <= r2yb;
    }
    public static void rectrect(Vector2 r1p, float r1w, float r1h, float r2x, float r2y, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1w,r1h,r2x,r2y,r2w,r2h,r1a,r2a);
    public static void rectrect(float r1x, float r1y, Vector2 r1s, float r2x, float r2y, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1s.X,r1s.Y,r2x,r2y,r2w,r2h,r1a,r2a);
    public static void rectrect(float r1x, float r1y, float r1w, float r1h, Vector2 r2p, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1w,r1h,r2p.X,r2p.Y,r2w,r2h,r1a,r2a);
    public static void rectrect(float r1x, float r1y, float r1w, float r1h, float r2x, float r2y, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1w,r1h,r2x,r2y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(Vector2 r1p, Vector2 r1s, float r2x, float r2y, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1s.X,r1s.Y,r2x,r2y,r2w,r2h,r1a,r2a);
    public static void rectrect(Vector2 r1p, float r1w, float r1h, Vector2 r2p, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1w,r1h,r2p.X,r2p.Y,r2w,r2h,r1a,r2a);
    public static void rectrect(Vector2 r1p, float r1w, float r1h, float r2x, float r2y, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1w,r1h,r2x,r2y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(float r1x, float r1y, Vector2 r1s, Vector2 r2p, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1s.X,r1s.Y,r2p.X,r2p.Y,r2w,r2h,r1a,r2a);
    public static void rectrect(float r1x, float r1y, Vector2 r1s, float r2x, float r2y, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1s.X,r1s.Y,r2x,r2y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(float r1x, float r1y, float r1w, float r1h, Vector2 r2p, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1w,r1h,r2p.X,r2p.Y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(Vector2 r1p, Vector2 r1s, Vector2 r2p, float r2w, float r2h, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1s.X,r1s.Y,r2p.X,r2p.Y,r2w,r2h,r1a,r2a);
    public static void rectrect(Vector2 r1p, Vector2 r1s, float r2x, float r2y, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1s.X,r1s.Y,r2x,r2y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(Vector2 r1p, float r1w, float r1h, Vector2 r2p, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1w,r1h,r2p.X,r2p.Y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(float r1x, float r1y, Vector2 r1s, Vector2 r2p, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1x,r1y,r1s.X,r1s.Y,r2p.X,r2p.Y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(Vector2 r1p, Vector2 r1s, Vector2 r2p, Vector2 r2s, Alignment r1a = Alignment.TopLeft, Alignment r2a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1s.X,r1s.Y,r2p.X,r2p.Y,r2s.X,r2s.Y,r1a,r2a);
    public static void rectrect(Rectangle r1, float r2x, float r2y, float r2w, float r2h, Alignment r2a = Alignment.TopLeft) => rectrect(r1.X,r1.Y,r1.Width,r1.Height,r2x,r2y,r2w,r2h,Alignment.TopLeft,r2a);
    public static void rectrect(Rectangle r1, Vector2 r2p, float r2w, float r2h, Alignment r2a = Alignment.TopLeft) => rectrect(r1.X,r1.Y,r1.Width,r1.Height,r2p.X,r2p.Y,r2w,r2h,Alignment.TopLeft,r2a);
    public static void rectrect(Rectangle r1, float r2x, float r2y, Vector2 r2s, Alignment r2a = Alignment.TopLeft) => rectrect(r1.X,r1.Y,r1.Width,r1.Height,r2x,r2y,r2s.X,r2s.Y,Alignment.TopLeft,r2a);
    public static void rectrect(Rectangle r1, Vector2 r2p, Vector2 r2s, Alignment r2a = Alignment.TopLeft) => rectrect(r1.X,r1.Y,r1.Width,r1.Height,r2p.X,r2p.Y,r2s.X,r2s.Y,Alignment.TopLeft,r2a);
    public static void rectrect(Vector2 r1p, float r1w, float r1h, Rectangle r2, Alignment r1a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1w,r1h,r2.X,r2.Y,r2.Width,r2.Height,r1a);
    public static void rectrect(float r1x, float r1y, Vector2 r1s, Rectangle r2, Alignment r1a = Alignment.TopLeft) => rectrect(r1x,r1y,r1s.X,r1s.Y,r2.X,r2.Y,r2.Width,r2.Height,r1a);
    public static void rectrect(float r1x, float r1y, float r1w, float r1h, Rectangle r2, Alignment r1a = Alignment.TopLeft) => rectrect(r1x,r1y,r1w,r1h,r2.X,r2.Y,r2.Width,r2.Height,r1a);
    public static void rectrect(Vector2 r1p, Vector2 r1s, Rectangle r2, Alignment r1a = Alignment.TopLeft) => rectrect(r1p.X,r1p.Y,r1s.X,r1s.Y,r2.X,r2.Y,r2.Width,r2.Height,r1a);
    public static void rectrect(Rectangle r1, Rectangle r2) => rectrect(r1.X,r1.Y,r1.Width,r1.Height,r2.X,r2.Y,r2.Width,r2.Height);
}