using SimulationFramework;
using SimulationFramework.Drawing;
using SimulationFramework.Drawing.Shaders;

using System.Numerics;

using thrustr.athr;

namespace thrustr.basic;

public class Canvas : ICanvas {
    readonly ICanvas _canv;

    public Canvas(ICanvas canv) => _canv = canv;

    public void Fill(ColorF color) {
        fontie.fill_color = color;
        _canv.Fill(color);
    }

    public void ResetState() { 
        fontie.fill_color = null;
        _canv.ResetState();
    }

    public void Fill(Color color) => Fill(color.ToColorF());
    public void Fill(CanvasShader shader) => _canv.Fill(shader);
    public void Fill(CanvasShader shader, VertexShader vertexShader) => _canv.Fill(shader, vertexShader);
    public void Clear(Color color) => Clear(color.ToColorF());
    public void Clear(ColorF color) => _canv.Clear(color);
    public void Flush() => _canv.Flush();
    public void Antialias(bool antialias) => _canv.Antialias(antialias);
    public void Stroke(Color color) => Stroke(color.ToColorF());
    public void Stroke(ColorF color) => _canv.Stroke(color);
    public void Stroke(CanvasShader shader) => _canv.Stroke(shader);
    public void Stroke(CanvasShader shader, VertexShader vertexShader) => _canv.Stroke(shader, vertexShader);
    public void StrokeWidth(float width) => _canv.StrokeWidth(width);
    public void Clip(Rectangle? rectangle) => _canv.Clip(rectangle);
    public void DrawLine(Vector2 p1, Vector2 p2) => _canv.DrawLine(p1, p2);
    public void DrawLines<TVertex>(ReadOnlySpan<TVertex> vertices) where TVertex : unmanaged => _canv.DrawLines(vertices);
    public void DrawRect(float x, float y, float width, float height, Alignment alignment = Alignment.TopLeft) => DrawRect(new Rectangle(x, y, width, height, alignment));
    public void DrawRect(Vector2 position, Vector2 size, Alignment alignment = Alignment.TopLeft) => DrawRect(new Rectangle(position, size, alignment));
    public void DrawRect(Rectangle rect) => _canv.DrawRect(rect);
    public void DrawRoundedRect(Rectangle rect, Vector2 radii) => _canv.DrawRoundedRect(rect, radii);
    public void DrawRoundedRect(float x, float y, float width, float height, float radius, Alignment alignment = Alignment.TopLeft) => _canv.DrawRoundedRect(x,y, width,height, radius, alignment);
    public void DrawEllipse(Rectangle bounds) => _canv.DrawEllipse(bounds);
    public void DrawArc(Rectangle bounds, float begin, float end, bool includeCenter) => _canv.DrawArc(bounds, begin, end, includeCenter);
    public void DrawTriangles(ReadOnlySpan<Vector2> triangles) => _canv.DrawTriangles(triangles);
    public void DrawTriangles<TVertex>(ReadOnlySpan<TVertex> vertices) where TVertex : unmanaged => _canv.DrawTriangles(vertices);
    public void DrawTriangles<TVertex>(ReadOnlySpan<TVertex> vertices, ReadOnlySpan<uint> indices) where TVertex : unmanaged => _canv.DrawTriangles(vertices, indices);
    public void DrawInstancedTriangles<TVertex, TInstance>(ReadOnlySpan<TVertex> vertices, ReadOnlySpan<TInstance> instances) where TVertex : unmanaged where TInstance : unmanaged => _canv.DrawInstancedTriangles(vertices, instances);
    public void DrawInstancedTriangles<TVertex, TInstance>(ReadOnlySpan<TVertex> vertices, ReadOnlySpan<uint> indices, ReadOnlySpan<TInstance> instances) where TVertex : unmanaged where TInstance : unmanaged => _canv.DrawInstancedTriangles(vertices, indices, instances);
    public void DrawPolygon(ReadOnlySpan<Vector2> polygon, bool close = true) => _canv.DrawPolygon(polygon, close);
    public void DrawGeometry(IGeometry geometry) => _canv.DrawGeometry(geometry);
    public void DrawInstancedGeometry(IGeometry geometry, ReadOnlySpan<Matrix3x2> instances) => _canv.DrawInstancedGeometry(geometry, instances);
    public void DrawInstancedGeometry<TInstance>(IGeometry geometry, ReadOnlySpan<TInstance> instances) where TInstance : unmanaged => _canv.DrawInstancedGeometry(geometry, instances);
    public Vector2 DrawText(ReadOnlySpan<char> text, float size, Vector2 baseline, TextStyle style = TextStyle.Regular) => _canv.DrawText(text, size, baseline, style);
    public void DrawText(string text, float size, float x, float y, Alignment align = Alignment.TopLeft) => _canv.DrawAlignedText(text, size, x,y, align);
    public void DrawText(string text, float size, Vector2 pos, Alignment align = Alignment.TopLeft) => _canv.DrawAlignedText(text, size, pos, align);
    public Vector2 DrawCodepoint(int codepoint, float size, Vector2 baseline, TextStyle style = TextStyle.Regular) => _canv.DrawCodepoint(codepoint, size, baseline, style);
    public Rectangle MeasureText(ReadOnlySpan<char> text, float size, TextStyle style = TextStyle.Regular) => _canv.MeasureText(text, size, style);
    public void Font(IFont font) => _canv.Font(font);
    public void PushState() => _canv.PushState();
    public void PopState() => _canv.PopState();
    public void SetTransform(Matrix3x2 transform) => _canv.SetTransform(transform);
    public void Mask(IMask? mask) => _canv.Mask(mask);
    public void WriteMask(IMask? mask, bool? value = true) => _canv.WriteMask(mask, value);
    public void DrawTexture(ITexture texture, Rectangle source, Rectangle destination, ColorF tint) => _canv.DrawTexture(texture, source, destination, tint);
    public void DrawTexture(ITexture texture, Rectangle source, Rectangle destination) => _canv.DrawTexture(texture, source, destination);
    public void DrawTexture(ITexture texture, Vector2 position, Vector2 size, Alignment alignment = Alignment.TopLeft) => _canv.DrawTexture(texture, position, size, alignment);
    public void DrawTexture(ITexture texture, float x, float y, float width, float height, Alignment alignment = Alignment.TopLeft) => _canv.DrawTexture(texture, x,y, width,height, alignment);
    public void DrawTexture(ITexture texture, Vector2 position, Alignment alignment = Alignment.TopLeft) => _canv.DrawTexture(texture, position, alignment);
    public void DrawTexture(ITexture texture, float x, float y, Alignment alignment = Alignment.TopLeft) => _canv.DrawTexture(texture, x,y, alignment);
    public void Transform(Matrix3x2 transformation) => _canv.Transform(transformation);
    public void Translate(Vector2 translation) => _canv.Translate(translation);
    public void Translate(float x, float y) => _canv.Translate(x,y);
    public void Scale(Vector2 scale) => _canv.Scale(scale);
    public void Scale(float scaleX, float scaleY) => _canv.Scale(scaleX,scaleY);
    public void Rotate(float angle) => _canv.Rotate(angle);
    public ITexture Target => _canv.Target;
    public ref readonly CanvasState State => ref _canv.State;
    public float Width => _canv.Width;
    public float Height => _canv.Height;

    // now we get to my stuff :D

    public void thr_DrawAnimation(animation anim, float x,float y, float w,float h, Alignment align, ColorF tint) => DrawTexture(anim.tex,anim.get_source_rect(),new Rectangle(x,y,w,h,align),tint);
    public void thr_DrawAnimation(animation anim, float x,float y, float w,float h, Alignment align = Alignment.TopLeft) => thr_DrawAnimation(anim,x,y,w,h,align);
    public void thr_DrawAnimation(animation anim, Vector2 pos, Vector2 size, Alignment align = Alignment.TopLeft) => thr_DrawAnimation(anim,pos.X,pos.Y,size.X,size.Y,align);
    public void thr_DrawAnimation(animation anim, float x,float y, Alignment align = Alignment.TopLeft) => thr_DrawAnimation(anim,x,y,anim.file.base_width,anim.file.base_height,align);
    public void thr_DrawAnimation(animation anim, Vector2 pos, Alignment align = Alignment.TopLeft) => thr_DrawAnimation(anim,pos.X,pos.Y,anim.file.base_width,anim.file.base_height,align);

    public void thr_DrawText(string text, Vector2 pos, Alignment align = Alignment.TopLeft, float scale = 1f, font? f = null) => thr_DrawText(text,pos.X,pos.Y,align,scale,f);
    public void thr_DrawText(string text, float px, float py, Alignment align = Alignment.TopLeft, float scale = 1f, font? f = null) {
        if(f == null)
           f = fontie.dfont; 

        if(f.fcase == caseness.lower)
            text = text.ToLower();
        else if(f.fcase == caseness.upper)
            text = text.ToUpper();

        ColorF _c = fontie.fill_color ?? ColorF.White; 

        switch(align) {
            case Alignment.TopLeft:
                py -= f.chart;
                break;
            case Alignment.BottomLeft:
                py += f.charh-f.charb;
                break;
            case Alignment.TopRight:
                py -= f.chart;
                px -= fontie.predicttextwidth(text,scale,f);
                break;
            case Alignment.BottomRight:
                py += f.charh-f.charb;
                px -= fontie.predicttextwidth(text,scale,f);
                break;
            case Alignment.CenterLeft:
                py += (f.charh-f.charb + -f.chart) * .5f;
                break;
            case Alignment.CenterRight:
                py += (f.charh-f.charb + -f.chart) * .5f;
                px -= fontie.predicttextwidth(text,scale,f);
                break;
            case Alignment.Center:
                py += (f.charh-f.charb + -f.chart) * .5f;
                px -= fontie.predicttextwidth(text,scale,f)/2f;
                break;
            case Alignment.TopCenter:
                py -= f.chart;
                px -= fontie.predicttextwidth(text,scale,f)-f.charw/2f;
                break;
            case Alignment.BottomCenter:
                py += f.charh-f.charb;
                px -= fontie.predicttextwidth(text,scale,f)/2f;
                break;
        }

        float x = 0;
        for (int i = 0; i < text.Length; i++) {
            if (text[i] == ' ')
                x += f.data[f.chars.IndexOf(' ')].width*scale;
            else {
                int ch = f.chars.IndexOf(text[i]);

                if (ch == -1) {
                    DrawTexture(
                        f.tex,
                        new Rectangle(0,0,f.charw,f.charh),
                        new Rectangle(px+x,py,f.charw*scale,f.charh*scale,align),
                        _c
                    );
                    x += f.data[f.chars.IndexOf(' ')].width*scale;
                } else { 
                    DrawTexture(
                        f.tex,
                        new Rectangle(ch*f.charw,0,f.charw,f.charh),
                        new Rectangle(px+x,py,f.charw*scale,f.charh*scale,align),
                        _c
                    );
                    x += f.data[f.chars.IndexOf(text[i])].width*scale;
                }
            }
        }

        Flush();
    }

    public void thr_stackr_RenderScene() {
        stackr.stackr.layers_rendered = 0;

        stackr.stackr.s_objs.Clear();

        if(stackr.stackr.objs.Count != 1) {
            Matrix3x2 rot = Matrix3x2.CreateRotation(stackr.stackr.camrot);

            foreach (var item in stackr.stackr.objs) {
                bool inserted = false;

                Vector2 pos2 = new (item.pos.X -stackr.stackr.cam.X,item.pos.Z -stackr.stackr.cam.Z);
                pos2 = Vector2.Transform(pos2, rot);
                pos2 += new Vector2(Width/2, Height/2 -item.pos.Y);

                for (int i = 0; i < stackr.stackr.s_objs.Count; i++) {
                    Vector2 pos1 = new (stackr.stackr.s_objs[i].a.pos.X -stackr.stackr.cam.X,stackr.stackr.s_objs[i].a.pos.Z -stackr.stackr.cam.Z);
                    pos1 = Vector2.Transform(pos1, rot);
                    pos1 += new Vector2(Width/2,Height/2 -stackr.stackr.s_objs[i].a.pos.Y);

                    bool res = item.pos.Z - stackr.stackr.s_objs[i].a.pos.Z < float.Epsilon? (pos2.Y < pos1.Y) : (item.pos.Z > stackr.stackr.s_objs[i].a.pos.Z);

                    if (res)  {
                        stackr.stackr.s_objs.Insert(i, (item, pos2));
                        inserted = true;
                        break;
                    }
                }

                if (!inserted)
                    stackr.stackr.s_objs.Add((item, pos2));
            }
        } else
            stackr.stackr.s_objs.Add((stackr.stackr.objs[0], new Vector2(Width/2,Height/2)));

        for(int i = 0; i < stackr.stackr.s_objs.Count; i++)
            for(int j = 0; j < stackr.stackr.s_objs[i].a.obj.layers; j++) {
                Translate(stackr.stackr.s_objs[i].b.X,stackr.stackr.s_objs[i].b.Y -j -stackr.stackr.cam.Y);
                Rotate(stackr.stackr.camrot+stackr.stackr.s_objs[i].a.rot);

                DrawTexture(
                    stackr.stackr.objs[i].obj.stack,
                    new Rectangle(
                        0, (stackr.stackr.s_objs[i].a.obj.layers-(j+1))*stackr.stackr.s_objs[i].a.obj.size.Y,
                        stackr.stackr.s_objs[i].a.obj.size.X, stackr.stackr.s_objs[i].a.obj.size.Y,
                        Alignment.TopLeft
                    ),
                    new Rectangle(Vector2.Zero,stackr.stackr.s_objs[i].a.obj.size,Alignment.Center),
                    stackr.stackr.s_objs[i].a.obj.tint
                );

                ResetState();

                stackr.stackr.layers_rendered++;
            }
    }

    public void thr_stackr_RenderSceneAndClear() {
        thr_stackr_RenderScene();
        stackr.stackr.objs.Clear();
    }
}