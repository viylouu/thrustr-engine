using thrustr.basic;

namespace thrustr.editor;

public abstract class component {
    public void Main() => editor.add_comp(this);

    public virtual void init() {}
    public virtual void update() {}
    public virtual void update_f() {}
    public virtual void render(Canvas c) {}

    public bool hasscripts;
    public object[] sparams;
}