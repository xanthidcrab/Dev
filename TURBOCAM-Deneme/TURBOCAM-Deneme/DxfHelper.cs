using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;
using netDxf.Entities;
namespace TURBOCAM_Deneme
{
    public static class DxfHelper
    {

        public static void LoadDxfToHelixToolkit(string filePath, HelixViewport3D viewport)
        {
            var dxf = DxfDocument.Load(filePath);
            if (dxf == null)
            {
                throw new Exception("Failed to load DXF file.");
            }

            var model = new ModelVisual3D();

            foreach (var entity in dxf.Entities.All)
            {
                switch (entity)
                {
                    case Line line:
                        model.Children.Add(new LinesVisual3D
                        {
                            Points = new Point3DCollection
                        {
                            new Point3D(line.StartPoint.X, line.StartPoint.Y, line.StartPoint.Z),
                            new Point3D(line.EndPoint.X, line.EndPoint.Y, line.EndPoint.Z)
                        }
                        });
                        break;

                    case Polyline2D polyline2D:
                        var pts2D = polyline2D.Vertexes
                            .Select(v => new Point3D(v.Position.X, v.Position.Y, 0))
                            .ToList();

                        for (int i = 0; i < pts2D.Count - 1; i++)
                        {
                            model.Children.Add(new LinesVisual3D
                            {
                                Points = new Point3DCollection
                            {
                                pts2D[i],
                                pts2D[i + 1]
                            }
                            });
                        }

                        if (polyline2D.IsClosed && pts2D.Count > 1)
                        {
                            model.Children.Add(new LinesVisual3D
                            {
                                Points = new Point3DCollection
                            {
                                pts2D[pts2D.Count - 1],
                                pts2D[0]
                            }
                            });
                        }
                        break;


                        
                }
            }

            viewport.Children.Add(model);
        }


    }
}
