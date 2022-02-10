using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Product : IDisposable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public void Dispose()
        {
            // dispose something
        }
    }
}
