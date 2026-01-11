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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pocotest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Initialize the rectangles with their initial colors
            _=ChangeColor();
        }



        public async Task ChangeColor() 
        {
            while (true)
            {
                // Change the color of the rectangle
                await ChangeRrect();
                // Change the color of the rectangle
                await ChangeGrect();
                // Change the color of the rectangle
                await ChangeBrect();
            }
           

        }

        private async Task ChangeRrect()
        {

            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            redRectangel.Fill = new SolidColorBrush(Colors.Green);
            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            redRectangel.Fill = new SolidColorBrush(Colors.Red);
        }

        private async Task ChangeGrect()
        {
            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            greenRectangle.Fill = new SolidColorBrush(Colors.Red);
            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            greenRectangle.Fill = new SolidColorBrush(Colors.Green);
        }

        private async Task ChangeBrect()
        {
            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            blueRectangel.Fill = new SolidColorBrush(Colors.Green);
            await Task.Delay(1000); // Simulate some delay for changing the rectangle color
            blueRectangel.Fill = new SolidColorBrush(Colors.Blue);
        }
    }
}
