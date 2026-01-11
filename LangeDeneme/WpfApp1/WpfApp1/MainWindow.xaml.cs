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

using System.IO;
using System.Text.Json;
using System.Net.Http;
using WpfApp1.json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string jsonContent = File.ReadAllText("G:\\Dev\\LangeDeneme\\WpfApp1\\WpfApp1\\json\\wpf_labels_valid.json");

            // Deserialize işlemi
            TurbocutLangugageModel labels = JsonSerializer.Deserialize<TurbocutLangugageModel>(jsonContent);

            // Örnek çıktı
            Console.WriteLine(labels.axis00_zpc_çikiş_profil_çikartma_z);
        }
    }
    }
  
