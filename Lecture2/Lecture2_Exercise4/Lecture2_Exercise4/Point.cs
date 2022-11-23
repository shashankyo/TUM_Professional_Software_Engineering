using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProSE
{
    class Point
    {
        public int x;
        public int y;
    public Point(int x, int y)
        {
        this.x = x;
        this.y = y;
        }
    public void PointPrint()
        {
        Console.WriteLine($"Your points:{x}, {y}");
        }
    }
}
