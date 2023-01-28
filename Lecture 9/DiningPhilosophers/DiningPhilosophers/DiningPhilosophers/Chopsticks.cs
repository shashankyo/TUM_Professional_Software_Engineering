using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    public class Chopstick
    {
        private static int _count = 0;
        public string Name { get; private set; }

        public Chopstick()
        {
            _count++;
            this.Name = "Chopstick " + _count;
        }
    }
}
