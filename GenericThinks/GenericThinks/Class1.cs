using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericThinks
{
    public class Kutu<T> 
    {
        public T Deger { get; set; }
        public Kutu(T deger)
        {
            Deger = deger;
        }

        public void Yazdir()
        {
            Console.WriteLine(Deger);
        }
    }
 
}
