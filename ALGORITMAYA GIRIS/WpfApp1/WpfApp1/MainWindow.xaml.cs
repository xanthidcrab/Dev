using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
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
using ProtoBuf.Reflection;

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
            var person = new Person
            {
                Id = 1,
                Name = "Harun",
                BirthDate = DateTime.Now,
                Gender = "Male",
                Address = new Address { Street = "123 Main", City = "Istanbul" },
                Phones = new List<PhoneNumber>
    {
        new PhoneNumber { Type = "Mobile", Number = "555-1234" }
    }
            };

            // Serialize & Save
            BsonHelper.SaveBsonFile(person, "person.bson");

            // Read & Deserialize
            var loaded = BsonHelper.LoadBsonFile<Person>("person.bson");

            Console.WriteLine(loaded.Name); // "Harun"
        }
    }
}
