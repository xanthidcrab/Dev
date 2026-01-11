using System.Windows;
using System.Windows.Input;

namespace DxfViewer.Behaviours
{
    public static class MouseUpToCommand {
        public static readonly DependencyProperty MouseUpCommand = DependencyProperty.RegisterAttached(
        "MouseUpCommand",
        typeof(System.Windows.Input.ICommand),
        typeof(MouseUpToCommand),
        new PropertyMetadata(null, OnMouseUpCommandChanged));
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (System.Windows.Input.ICommand)obj.GetValue(MouseUpCommand);
        }
        public static void SetMouseUpCommand(DependencyObject obj, System.Windows.Input.ICommand value)
        {
            obj.SetValue(MouseUpCommand, value);
        }
        static void OnMouseUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.NewValue != null)
                {
                    element.MouseUp += Element_MouseUp;
                }
                if (e.OldValue != null)
                {
                    element.MouseUp -= Element_MouseUp;
                }
            }
        }

        private static void Element_MouseUp(object sender, MouseButtonEventArgs e)
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

