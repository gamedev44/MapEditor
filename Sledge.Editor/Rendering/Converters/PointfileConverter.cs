using System.Drawing;
using Sledge.DataStructures.MapObjects;
using Sledge.Editor.Documents;
using Sledge.Editor.Extensions;
using Line = Sledge.Rendering.Scenes.Renderables.Line;

namespace Sledge.Editor.Rendering.Converters
{
    public class PointfileConverter : IMapObjectSceneConverter
    {
        public MapObjectSceneConverterPriority Priority { get { return MapObjectSceneConverterPriority.OverrideLow; } }

        public bool ShouldStopProcessing(SceneMapObject smo, MapObject obj)
        {
            return false;
        }

        public bool Supports(MapObject obj)
        {
            return obj is World;
        }

        public bool Convert(SceneMapObject smo, Document document, MapObject obj)
        {
            if (document.Pointfile == null) return true;

            var r = 255;
            var g = 127;
            var b = 127;
            var change = 128 / (float) document.Pointfile.Lines.Count;

            for (int i = 0; i < document.Pointfile.Lines.Count; i++)
            {
                var line = document.Pointfile.Lines[i];
                var colour = Color.FromArgb(r, g, b);
                smo.SceneObjects.Add(new object(), new Line(colour, line.Start.ToVector3(), line.End.ToVector3()));

                r = 255 - (int)(change * i);
                b = 127 + (int)(change * i);
            }
            return true;
        }

        public bool Update(SceneMapObject smo, Document document, MapObject obj)
        {
            return false;
        }
    }
}