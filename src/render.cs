partial class main {
    static void rend(ICanvas c) {
        c.Clear(Color.Black);

        if (!intro.introplayed)
        { intro.dointro(c, dfont); return; }

        fontie.rendertext(c, dfont, $"{MathF.Round(1/Time.DeltaTime)} fps", 3,3, ColorF.White);
    }
}