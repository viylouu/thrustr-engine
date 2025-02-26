using Silk.NET.OpenAL;
using SimulationFramework;
using SimulationFramework.Drawing;
using SimulationFramework.Drawing.Shaders;

using System.Numerics;

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
}