using System.Windows;
using System.Windows.Input;

namespace DxfViewer.Behaviours
{
    public static class MouseWheelToCommand
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached(
                "Command",
                typeof(ICommand),
                typeof(MouseWheelToCommand),
                new PropertyMetadata(null, OnCommandChanged));

        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue != null)
                    element.MouseWheel -= Element_MouseWheel;

                if (e.NewValue != null)
                    element.MouseWheel += Element_MouseWheel;
            }
        }

        private static void Element_MouseWheel(object sender, MouseWheelEventArgs e)
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
