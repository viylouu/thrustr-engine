using System.Numerics;
using SimulationFramework;
using SimulationFramework.Drawing;

using Assimp;
using thrustr.basic;

namespace thrustr.utils;

public static class misc {
    public static void trydispose(this ITexture todisp) {
        if(todisp != null)
            todisp.Dispose();
    }

    public static void trydispose(this ISound todisp) {
        if(todisp != null)
            todisp.Dispose();
    }

    public static void trydispose(this SoundPlayback todisp) {
        if(todisp != null)
            todisp.Dispose();
    }


    static AssimpContext imp = new();

    /// <summary>loads an fbx file as a set of vertices (Vector3[]) indices (uint[]) and texture coordinates (Vector2[])</summary>
    public static (Vector3[], uint[], Vector2[]) loadfbx(string path, out bool success) {
        success = false;

        Scene scene = imp.ImportFile(path, PostProcessSteps.Triangulate);

        if(handle.debug)
            Console.WriteLine($"loading fbx file at \"{path}\"");

        List<Vector3> verts = new();
        List<uint> inds = new();
        List<Vector2> texcoords = new();

        Vector3[] def_v = Array.Empty<Vector3>();
        uint[] def_i = Array.Empty<uint>();
        Vector2[] def_t = Array.Empty<Vector2>();

        if(scene != null && scene.HasMeshes)
            foreach(var mesh in scene.Meshes) {
                if(handle.debug) {
                    Console.WriteLine($"found \"{mesh.Name}\"");
                    Console.WriteLine($"{mesh.VertexCount} vertices");
                    Console.WriteLine($"{mesh.FaceCount} faces");
                }

                foreach(var vert in mesh.Vertices)
                    verts.Add(new(vert.X, vert.Y, vert.Z));

                foreach(var face in mesh.Faces)
                    if(face.IndexCount == 3) {
                        inds.Add((uint)face.Indices[0]);
                        inds.Add((uint)face.Indices[1]);
                        inds.Add((uint)face.Indices[2]);
                    } else {
                        if(handle.debug)
                            Console.WriteLine($"error! invalid face count ({face.IndexCount}) expected (3)");
                        return (def_v,def_i,def_t);
                    }

                if(mesh.TextureCoordinateChannels[0] != null)
                    for(int i = 0; i < mesh.VertexCount; i++)
                        texcoords.Add(new(mesh.TextureCoordinateChannels[0][i].X, mesh.TextureCoordinateChannels[0][i].Y));
                else {
                    if(handle.debug)
                        Console.WriteLine("error! no texture coordinates found");
                    return (def_v,def_i,def_t);
                }
            }
        else if(handle.debug)
            Console.WriteLine("no meshes found / failed to load file");
        
        success = true;
        return (verts.ToArray(), inds.ToArray(), texcoords.ToArray());
    }
}