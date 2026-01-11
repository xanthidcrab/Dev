using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DxfViewer.Behaviours
{
    public static class MouseDownToCommand
    {
        public static readonly DependencyProperty MouseDownCommand = DependencyProperty.RegisterAttached(
            "MouseDownCommand",
            typeof(System.Windows.Input.ICommand),
            typeof(MouseDownToCommand),
            new PropertyMetadata(null, OnMouseDownCommandChanged));


        private static ICommand GetCommand(DependencyObject obj)
        {
            return (System.Windows.Input.ICommand)obj.GetValue(MouseDownCommand);
        }
        public static void SetMouseDownCommand(DependencyObject obj, System.Windows.Input.ICommand value)
        {
            obj.SetValue(MouseDownCommand, value);
        }

        private static void OnMouseDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.NewValue != null)
                {
                    element.MouseDown += Element_MouseDown;
                }
                if (e.OldValue != null)
                {
                    element.MouseDown -= Element_MouseDown;
                }

            }
        }

        private static void Element_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is UIElement element)
            {
                var command = GetCommand(element);
                if (command?.CanExecute(e) == true)
                {
                    command.Execute(e);
                    e.Handled = true;
                }
            }
        }
    }
 
    
}

