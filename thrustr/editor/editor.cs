using System.Reflection;

namespace thrustr.editor;

public static class editor {
    public static bool enabled;

    static List<component> valid_comps = new();

    public static void add_comp(component comp) {
        valid_comps.Add(comp);
    }

    public static void init() {
        if(!enabled)
            return;

        foreach(component obj in valid_comps) {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields) {
                if (Attribute.IsDefined(field, typeof(thr_visible)))
                    Console.WriteLine($"Field: {field.Name}, Value: {field.GetValue(obj)}");
            }
        }

        valid_comps.Clear();
        valid_comps = null;
    }
}