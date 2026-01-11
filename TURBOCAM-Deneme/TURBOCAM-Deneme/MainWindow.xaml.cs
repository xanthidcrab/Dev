using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace TURBOCAM_Deneme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadDxf_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "DXF Files (*.dxf)|*.dxf"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Önceki çizimleri temizle
                MainViewport.Children.Clear();

                // Eksen ve ızgarayı tekrar ekle
                MainViewport.Children.Add(new CoordinateSystemVisual3D());
                MainViewport.Children.Add(new GridLinesVisual3D
                {
                    Width = 200,
                    Length = 200,
                    MinorDistance = 10,
                    Thickness = 0.1
                });

                // DXF yükle
                DxfHelper.LoadDxfToHelixToolkit(openFileDialog.FileName, MainViewport);
            }
        }



        private void MakeIt3D(object sender, RoutedEventArgs e)
        {
            var segments = new List<(Point start, Point end)>();

            // 1. Viewport içindeki LinesVisual3D'leri yakala
            foreach (var child in MainViewport.Children)
            {
                if (child is ModelVisual3D modelGroup)
                {
                    foreach (var sub in modelGroup.Children)
                    {
                        if (sub is LinesVisual3D line)
                        {
                            var pts = line.Points;
                            if (pts.Count >= 2)
                            {
                                var p1 = new Point(pts[0].X, pts[0].Y);
                                var p2 = new Point(pts[1].X, pts[1].Y);
                                segments.Add((p1, p2));
                            }
                        }
                    }
                }
            }

            if (segments.Count < 3)
            {
                MessageBox.Show("Yeterli sayıda çizgi yok.");
                return;
            }

            // 2. Konturu sıraya diz
            var ordered = new List<Point> { segments[0].start, segments[0].end };
            segments.RemoveAt(0);

            while (segments.Count > 0)
            {
                var last = ordered[ordered.Count - 1];
                var nextIndex = segments.FindIndex(s => s.start == last || s.end == last);

                if (nextIndex == -1)
                    break; // Açık kontur, bağlayamadı

                var next = segments[nextIndex];
                segments.RemoveAt(nextIndex);

                if (next.start == last)
                    ordered.Add(next.end);
                else
                    ordered.Add(next.start);
            }

            // 3. Kapalı kontur mu? Değilse kapat
            if (ordered[0] != ordered[ordered.Count - 1])
                ordered.Add(ordered[0]);

            // 4. Extrusion işlemi
            var height = 10.0;
            var builder = new MeshBuilder(false, false);
            builder.AddExtrudedGeometry(ordered, new Vector3D(1, 0, 0), new Point3D(0, 0, 0), new Point3D(0, 0, height));

            var mesh = builder.ToMesh();
            var material = MaterialHelper.CreateMaterial(Colors.Orange);

            var model = new GeometryModel3D
            {
                Geometry = mesh,
                Material = material,
                BackMaterial = material
            };

            MainViewport.Children.Add(new ModelVisual3D { Content = model });
        }



    }
}
