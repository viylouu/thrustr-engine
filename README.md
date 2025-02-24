# thrustr engine
### an easy to use engine for some of my projects

## planned features
- a 3D editor
- a 2D editor
- game objects
- components
- scenes
- networking
- lighting

## current features
- a "font renderer"
- a math class
- an easings class
- a collision class (unfinished)
- an intro player
- a sprite-stack renderer

# requirements
- SimulationFramework (0.3.0-alpha.12)             (graphical stuff and shaders)
- SimulationFramework.Desktop (0.3.0-alpha.12)     (graphical stuff and shaders)
- SimulationFramework.OpenGL (0.3.0-alpha.12)      (graphical stuff and shaders)
- AssimpNet                                        (fbx importing inside of misc.cs)

## installing requirements
here is a basic command to install the requirements  
``` dotnet add package SimulationFramework -v 0.3.0-alpha.13 | dotnet add package SimulationFramework.Desktop -v 0.3.0-alpha.13 | dotnet add package SimulationFramework.OpenGL -v 0.3.0-alpha.13 | dotnet add package AssimpNet ```