namespace thrustr.editor;

[AttributeUsage(AttributeTargets.Field)]
class thr_visible : Attribute { 
    public string? _name;

    public thr_visible(string? name = null) => _name = name;
}