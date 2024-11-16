public class illumshad : CanvasShader {
    public light[] l;
    public tri[] objs;

    public override ColorF GetPixelColor(Vector2 pos) {
        ColorF col = ColorF.Black;
        Vector3 _col = new Vector3(0,0,0);

        for(int i = 0; i < l.Length; i++) {
            bool inshadow = false;
            float dist = Distance(pos, l[i].pos);

            if(dist <= l[i].rad) {
                float r = Max((l[i].lum*l[i].col.R+(l[i].lum-1))*(1-dist/l[i].rad),0);
                float g = Max((l[i].lum*l[i].col.G+(l[i].lum-1))*(1-dist/l[i].rad),0);
                float b = Max((l[i].lum*l[i].col.B+(l[i].lum-1))*(1-dist/l[i].rad),0);

                if (l[i].clmp) {
                    r = Round(r/l[i].rnd)*l[i].rnd;
                    g = Round(g/(l[i].rnd*.5f))*(l[i].rnd*.5f);
                    b = Round(b/l[i].rnd)*l[i].rnd;
                }

                Vector2 _p = pos;

                for (int j = 0; j < (int)dist; j++) 
                    if(!inshadow) {
                        _p += (l[i].pos-_p).Normalized();

                        for (int k = 0; k < objs.Length; k++)
                            if(!inshadow)
                                if (intri(_p, objs[k].p1, objs[k].p2, objs[k].p3)) 
                                { inshadow = true; break; }
                    } else
                        break;

                if(!inshadow)
                    _col += new Vector3(r,g,b);
            }
        }
        
        col = new ColorF(_col.X,_col.Y,_col.Z);

        return col;
    }

    /*public bool intri(Vector2 p, Vector2 p1, Vector2 p2, Vector2 p3) { 
        float areaOrig = Abs((p2.X-p1.X)*(p3.Y-p1.Y) - (p3.X-p1.X)*(p2.Y-p1.Y));

        float area1 = Abs((p1.X - p.X) * (p2.Y - p.Y) - (p2.X - p.X) * (p1.Y - p.Y));
        float area2 = Abs((p2.X - p.X) * (p3.Y - p.Y) - (p3.X - p.X) * (p2.Y - p.Y));
        float area3 = Abs((p3.X - p.X) * (p1.Y - p.Y) - (p1.X - p.X) * (p3.Y - p.Y));

        return (area1+area2+area3) == areaOrig;
    }*/

    public bool intri(Vector2 p, Vector2 p1, Vector2 p2, Vector2 p3) {
        float s = p1.Y * p3.X - p1.X * p3.Y + (p3.Y - p1.Y) * p.X + (p1.X - p3.X) * p.Y;
        float t = p1.X * p2.Y - p1.Y * p2.X + (p1.Y - p2.Y) * p.X + (p2.X - p1.X) * p.Y;

        if ((s < 0) != (t < 0)) return false;

        float A = -p2.Y * p3.X + p1.Y * (p3.X - p2.X) + p1.X * (p2.Y - p3.Y) + p2.X * p3.Y;
        return A < 0 ? (s <= 0 && s + t >= A) : (s >= 0 && s + t <= A);
    }
}