using SimulationFramework;
using SimulationFramework.Drawing;

namespace thrustr.athr;

public class animation {
    public static animation load_from_path(string path, ITexture texture) {
        string data = "";
        using(StreamReader sr = new(path))
            data = sr.ReadToEnd();

        return load_from_data(data, texture);
    }

    public static animation load_from_data(string data, ITexture texture) {
        animation a = new();

        a.file = new(data);
        a.file.parse();
        
        a.tex = texture;

        a._frames = new();
        for(int i = 0; i < a.file.anims.Count; i++)
            a._frames.Add(a.file.anims[i].name,a.file.anims[i]);

        return a;
    }


    public athr file;
    public string anim;
    public int frame;
    public ITexture tex;

    public float spf;
    float _fps;
    public float fps {
        get {
            return _fps;
        }
        set {
            spf = 1f/value;
            _fps = value;
        }
    }

    public float _frameprogress;
    public Dictionary<string, athr_anim> _frames;


    public void update(float delta_time) {
        _frameprogress -= delta_time;
        if(_frameprogress < 0) {
            _frameprogress = spf;
            frame++;
            frame = frame % _frames[anim].posses.Length;
        }
    }


    // if you get the error "value cannot be null" then you probably havent set the animation string
    // check the manual for what to set the animation string to
    public Rectangle get_source_rect() {
        return new(
            _frames[anim].posses[frame].X*file.base_width,
            _frames[anim].posses[frame].Y*file.base_height,
            file.base_width,file.base_height
        );
    }
}