using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericThinks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Kutu<string> kutu = new Kutu<string>("Merhaba");
           
            Console.WriteLine(kutu.Deger);
            Kutu<int> intKutu = new Kutu<int>(42);
          
            Console.WriteLine(intKutu.Deger);
            Console.ReadLine();
        }
    }
}
