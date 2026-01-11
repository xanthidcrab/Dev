using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum SnapType
    {
        EndPoint,
        MidPoint
    }

    public class SnapPoint
    {
        public Point Position { get; set; }
        public SnapType Type { get; set; }
        public object SourceObject { get; set; }
    }

    public partial class MainWindow : Window
    {
        private readonly List<SnapPoint> snapPoints = new List<SnapPoint>();
        private readonly Canvas canvas = new Canvas();
        public MainWindow()
        {
            InitializeComponent();
            Content = canvas;
            Loaded += MainWindow_Loaded;
            canvas.Background = Brushes.White;
            canvas.MouseMove += Canvas_MouseMove;
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");

            foreach (var device in searcher.Get())
            {
                Console.WriteLine(device["Name"]);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Add a demo line
            var line = new Line
            {
                X1 = 50,
                Y1 = 100,
                X2 = 300,
                Y2 = 100,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(line);
            RegisterLine(line);
        }

        private void RegisterLine(Line line)
        {
            snapPoints.Add(new SnapPoint
            {
                Position = new Point(line.X1, line.Y1),
                Type = SnapType.EndPoint,
                SourceObject = line
            });

            snapPoints.Add(new SnapPoint
            {
                Position = new Point(line.X2, line.Y2),
                Type = SnapType.EndPoint,
                SourceObject = line
            });

            snapPoints.Add(new SnapPoint
            {
                Position = new Point((line.X1 + line.X2) / 2, (line.Y1 + line.Y2) / 2),
                Type = SnapType.MidPoint,
                SourceObject = line
            });
        }

        private async void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(canvas);
            Point finalPos = mousePos;

            double snapTolerance = 10.0;

            var nearestSnap = snapPoints
                .Select(p => new { Point = p, Distance = Distance(mousePos, p.Position) })
                .Where(p => p.Distance < snapTolerance)
                .OrderBy(p => p.Distance)
                .FirstOrDefault();

            if (nearestSnap != null)
            {
                // Snap noktasını ekran koordinatına çevir
                Point screenPoint = canvas.PointToScreen(nearestSnap.Point.Position);
                POINT current;
                GetCursorPos(out current);

                // Zıplama hissi olmaması için pozisyon farkı kontrol edilir
                if (Math.Abs(screenPoint.X - current.X) > 2 || Math.Abs(screenPoint.Y - current.Y) > 2)
                {
                    SetCursorPos((int)screenPoint.X, (int)screenPoint.Y); // hafif sabitlik
                }

                HighlightSnapPoint(nearestSnap.Point.Position, nearestSnap.Point.Type);
                await Task.Delay(1); // snap hissi
            }
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        private static double Distance(Point a, Point b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void HighlightSnapPoint(Point p, SnapType type)
        {
            var ellipse = new Ellipse
            {
                Width = 8,
                Height = 8,
                Fill = Brushes.Transparent,
                Stroke = GetBrushForSnapType(type),
                StrokeThickness = 2
            };

            Canvas.SetLeft(ellipse, p.X - 4);
            Canvas.SetTop(ellipse, p.Y - 4);
            canvas.Children.Add(ellipse);

            Task.Delay(300).ContinueWith(_ =>
            {
                Dispatcher.Invoke(() => canvas.Children.Remove(ellipse));
            });
        }

        private Brush GetBrushForSnapType(SnapType type)
        {
            switch (type)
            {
                case SnapType.EndPoint:
                    return Brushes.Red;
                case SnapType.MidPoint:
                    return Brushes.Green;
                default:
                    return Brushes.Gray;
            }
        }
    }

}
