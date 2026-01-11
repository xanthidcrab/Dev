using DxfService;
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreeD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DxfInstance _CurrenDxf;

        public DxfInstance CurrenDxf
        {
            get { return _CurrenDxf; }
            set { 
                
                _CurrenDxf = value;

                OnDxfReceived();
            }
        }

        private void OnDxfReceived()
        {
            var geometry = CurrenDxf.Contour.Data as PathGeometry;
            var points2D = new List<Point>();

            foreach (var figure in geometry.Figures)
            {
                points2D.Add(figure.StartPoint);

                foreach (var segment in figure.Segments)
                {
                    if (segment is System.Windows.Media.LineSegment line)
                        points2D.Add(line.Point);
                    else if (segment is PolyLineSegment poly)
                        points2D.AddRange(poly.Points);
                }
            }

            // extrusion düzlemi
            var xaxis = new Vector3D(0, 0, 1);
            var p0 = new Point3D(0, 0, 0);
            var p1 = new Point3D(0, 0, 500);

            // MeshBuilder (veya benzeri yapıyı varsayalım)
            var builder = new MeshBuilder(false, false);
            builder.AddExtrudedGeometry(points2D, xaxis, p0, p1);

            var model = new GeometryModel3D
            {
                Geometry = builder.ToMesh(),
                Material = Materials.Green
            };

            helixViewport3D.Children.Clear();
            helixViewport3D.Children.Add(new SunLight());
            helixViewport3D.Children.Add(new ModelVisual3D { Content = model });
        }


        public DxfService.DxfService dxf { get { return new DxfService.DxfService(); } }
        public MainWindow()
        {
            InitializeComponent();
            //CreateScene();
            LoadDxfAsync();
            
        }

        private async Task LoadDxfAsync()
        {
            CurrenDxf = await dxf.GetDxfPath("G:\\Dev\\ThreeD\\ThreeD\\ThreeD\\70KARİZMAKASA.dxf", 0, 0, false, Color.FromRgb(255, 255, 255));
        }

        private void CreateScene()
        {
            // 1. HelixViewport3D oluştur
            var viewport = new HelixViewport3D
            {
                ZoomExtentsWhenLoaded = true
            };

            // 2. Işık ekle
            var light = new SunLight();
            viewport.Children.Add(light);

            // 3. MeshGeometry3D (küp noktaları ve yüzeyleri)
            var mesh = new MeshGeometry3D();

            // Köşe noktaları (Positions)
            Point3D[] positions = new Point3D[]
            {
                new Point3D(0, 0, 0),
                new Point3D(1, 0, 0),
                new Point3D(0, 1, 0),
                new Point3D(1, 1, 0),
                new Point3D(0, 0, 1),
                new Point3D(1, 0, 1),
                new Point3D(0, 1, 1),
                new Point3D(1, 1, 1)
            };
            foreach (var p in positions)
                mesh.Positions.Add(p);

            // Üçgen yüzeyler (TriangleIndices)
            int[] indices = new int[]
            {
                2, 3, 1,  2, 1, 0,    // Alt
                7, 1, 3,  7, 5, 1,    // Sağ
                6, 5, 7,  6, 4, 5,    // Üst
                6, 2, 0,  6, 0, 4,    // Sol
                2, 7, 3,  2, 6, 7,    // Ön
                0, 1, 5,  0, 5, 4     // Arka
            };
            foreach (var i in indices)
                mesh.TriangleIndices.Add(i);

            // 4. Materyal oluştur
            var material = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));

            // 5. GeometryModel3D oluştur
            var model = new GeometryModel3D
            {
                Geometry = mesh,
                Material = material
            };

            // 6. Modeli sarmala ve sahneye ekle
            var modelVisual = new ModelVisual3D
            {
                Content = model
            };
            viewport.Children.Add(modelVisual);

            // 7. GridLines (opsiyonel zemin ızgarası)
            var grid = new GridLinesVisual3D
            {
                Width = 8,
                Length = 8,
                MinorDistance = 1,
                MajorDistance = 1,
                Thickness = 0.01
            };
            viewport.Children.Add(grid);
             
            // 8. Son olarak viewport'u Grid'e ekle
            //MainGrid.Children.Add(viewport);
        }
    }
}
