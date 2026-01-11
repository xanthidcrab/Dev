using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public static class AttachedMousePoint
    {
        // MouseX Attached Property
        public static readonly DependencyProperty MouseXProperty =
            DependencyProperty.RegisterAttached(
                "MouseX",
                typeof(float),
                typeof(AttachedMousePoint),
                  new FrameworkPropertyMetadata(
            0f,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
            ));

        public static void SetMouseX(UIElement element, float value) => element.SetValue(MouseXProperty, value);
        public static float GetMouseX(UIElement element) => (float)element.GetValue(MouseXProperty);

        // MouseY Attached Property
        public static readonly DependencyProperty MouseYProperty =
            DependencyProperty.RegisterAttached(
                "MouseY",
                typeof(float),
                typeof(AttachedMousePoint),
                 new FrameworkPropertyMetadata(
            0f,
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
            ));

        public static void SetMouseY(UIElement element, float value) => element.SetValue(MouseYProperty, value);
        public static float GetMouseY(UIElement element) => (float)element.GetValue(MouseYProperty);

        // IsTracking Attached Property - MouseMove etkinliği buradan yönetilir
        public static readonly DependencyProperty IsTrackingProperty =
            DependencyProperty.RegisterAttached(
                "IsTracking",
                typeof(bool),
                typeof(AttachedMousePoint),
                new PropertyMetadata(false, OnTrackingChanged)
            );

        public static void SetIsTracking(UIElement element, bool value) => element.SetValue(IsTrackingProperty, value);
        public static bool GetIsTracking(UIElement element) => (bool)element.GetValue(IsTrackingProperty);

        private static void OnTrackingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if ((bool)e.NewValue)
                {
                    element.MouseMove += Element_MouseMove;
                }
                else
                {
                    element.MouseMove -= Element_MouseMove;
                }
            }
        }

        private static void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is UIElement element)
            {
                Point position = e.GetPosition(element);
                SetMouseX(element, (float)position.X);
                SetMouseY(element, (float)position.Y);
            }
        }
    }
}
 
