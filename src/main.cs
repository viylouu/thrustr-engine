using SimulationFramework;

using thrustr.basic;
using thrustr.editor;

partial class main {
    static void Main() { 
        editorui.enabled = true;
        editor.enabled = true;
        
        handle.debug = true;

        handle.init(init, rend);
    }
    
    static void init() {
        Simulation.SetFixedResolution(640, 360, Color.Black);
    }
}