using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DxfViewer.Behaviours
{
    public static class MouseMoveToCommand
    {
        public static readonly DependencyProperty MouseMoveCommandProperty =
            DependencyProperty.RegisterAttached(
                "MouseMoveCommand",
                typeof(ICommand),
                typeof(MouseMoveToCommand),
                new PropertyMetadata(null, OnMouseMoveCommandChanged));

        public static void SetMouseMoveCommand(UIElement element, ICommand value)
        {
            element.SetValue(MouseMoveCommandProperty, value);
        }

        public static ICommand GetMouseMoveCommand(UIElement element)
        {
            return (ICommand)element.GetValue(MouseMoveCommandProperty);
        }

        private static void OnMouseMoveCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    element.MouseMove += Element_MouseMove;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseMove -= Element_MouseMove;
                }
            }
        }

        private static void Element_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is UIElement element)
            {
                var command = GetMouseMoveCommand(element);
                if (command != null && command.CanExecute(e))
                {
                    command.Execute(e);
                }
            }
        }
    }
}
