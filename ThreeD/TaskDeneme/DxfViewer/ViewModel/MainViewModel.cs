using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DxfViewer.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private double zoomLevel = 1.0;
        [ObservableProperty] private double panOffsetX;
        [ObservableProperty] private double panOffsetY;
        [ObservableProperty] private double posx;
        [ObservableProperty] private double posy;

        [ObservableProperty] private PathGeometry dxfData;

        private bool isDragging;
        private Point lastMousePosition;

        // 🔹 Mouse Wheel → ZOOM
        [RelayCommand]
        private void MouseWheel(MouseWheelEventArgs e)
        {
            const double zoomStep = 0.1;
            const double minZoom = 0.2;
            const double maxZoom = 10.0;

            double delta = e.Delta > 0 ? zoomStep : -zoomStep;
            double newZoom = ZoomLevel + delta;

            ZoomLevel = Clamp(newZoom, minZoom, maxZoom);
        }

        // 🔹 Mouse Down → Pan başlat
        [RelayCommand]
        private void MouseDown(MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(null);
        }

        // 🔹 Mouse Move → Pan
        [RelayCommand]
        private void MouseMove(MouseEventArgs e)
        {
         
         
            if (!isDragging)
                return;

            Point current = e.GetPosition(null);

            Vector delta = current - lastMousePosition;

            PanOffsetX += delta.X;
            PanOffsetY += delta.Y;

            lastMousePosition = current;
        }

        // 🔹 Mouse Up → Pan bitir
        [RelayCommand]
        private void MouseUp(MouseButtonEventArgs e)
        {
            isDragging = false;
        }
        [RelayCommand]
        private void LoadDxf()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DXF Files (*.dxf)|*.dxf",
                Title = "Select a DXF File"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var dxfService = new DxfService.DxfService();
                    DxfData = dxfService.DxfToPathGeometry(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading DXF file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        [RelayCommand]
        private void InneerCanvasMouseMove(MouseEventArgs e)
        {
            if (e.Source is not FrameworkElement container)
                return;

            // Mouse pozisyonu (pixel)
            Point mouse = e.GetPosition(container);

            double width = container.ActualWidth;
            double height = container.ActualHeight;

            // SAĞ ALT = (0,0)
            Posx = width - mouse.X;
            Posy = height - mouse.Y;
        }
        private static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

}
