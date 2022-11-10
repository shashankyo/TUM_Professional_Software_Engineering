using ProSE_Assignment1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProSE_Assignment1
{
    public abstract class ImplicitGeometry
    {

        public abstract bool IsInside(ref double x, ref double y);
        public abstract bool IsInside(ref double y);
        public void Visualize(double xGrid, double yGrid)
        {
            char falseGridChar = ' ';
            char trueGridChar = '#';
            bool isInside = false;
            // IsInside(xGrid, yGrid);
            //
            //
            // BUG!!
            // tam olarak çalışmıyor, xGrid'e IsInside'ın true olduğu aralıktan büyük bir değer verdiğimde, hep false dönüyor
            // 
            //
            for (double y = yGrid; y >= 0; y--)
            {
                isInside = IsInside(ref y);
                if (isInside == true)
                {
                    for (double x = 0; x <= xGrid; x++)
                    {
                        isInside = IsInside(ref x, ref y);
                        if (isInside == true)
                        {
                            Console.Write($"({x},{y})");
                            //Console.BackgroundColor = ConsoleColor.Blue;
                            //Console.ForegroundColor = ConsoleColor.Blue;
                            //Console.Write(trueGridChar);
                        }
                        else
                        {
                            //Console.Write($"({x},{y})");
                            //Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(falseGridChar);
                        }
                    }
                }
                else
                {
                    for (int x = 0; x <= xGrid; x++)
                    {
                        if (isInside == true)
                        {
                            //Console.BackgroundColor = ConsoleColor.Blue;
                            //Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(trueGridChar);
                            //Console.BackgroundColor = ConsoleColor.White;
                            isInside = false;
                        }
                        else
                        {
                            //Console.Write($"({x},{y})");
                            //Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(falseGridChar);
                        }
                    }
                }
                //Console.BackgroundColor = ConsoleColor.White;
                Console.Write('\n');
            }
        }
    }
    public class Rectangle : ImplicitGeometry
    {
        public double x1;
        public double x2;
        public double y1;
        public double y2;


        public Rectangle(double x1, double x2, double y1, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public override bool IsInside(ref double x, ref double y)
        {
            if (y >= y1 && y <= y2)
            {
                if (x >= x1 && x <= x2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override bool IsInside(ref double y)
        {
            if (y >= y1 && y <= y2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public class Circle : ImplicitGeometry
    {
        public double xCenter;
        public double yCenter;
        public double radius;

        public Circle(double xCenter, double yCenter, double radius)
        {
            this.xCenter = xCenter;
            this.yCenter = yCenter;
            this.radius = radius;
        }
        public override bool IsInside(ref double y)
        {

                return true;
            
        }
        public override bool IsInside(ref double x, ref double y)
        {
            if ((x - center_x) ^ 2 + (y - center_y) ^ 2 < radius ^ 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public abstract class Operation : ImplicitGeometry
    {
        public Operation(ref Rectangle operand1, ref Rectangle operand2)
        {
        }
        //public Operation(ref Circle operand1, ref Circle operand2)
        //{
        //}
        //public Operation(ref Circle operand1, ref Rectangle operand2)
        //{
        //}
        public Operation(ref Union operand1, ref Union operand2)
        {
        }

    }
public class Union : Operation
    {
        public ImplicitGeometry operand1;
        public ImplicitGeometry operand2;
        public Union(ref Rectangle operand1, ref Rectangle operand2) : base(ref operand1, ref operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        //public Union(ref Circle operand1, ref Circle operand2) : base(ref operand1, ref operand2)
        //{
        //    this.operand1 = operand1;
        //    this.operand2 = operand2;
        //}
        public Union(ref Union operand1, ref Union operand2) : base(ref operand1, ref operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
        public override bool IsInside(ref double y)
        {
            
            bool insideOperand1 = operand1.IsInside(ref y);
            bool insideOperand2 = operand2.IsInside(ref y);
            return insideOperand1 || insideOperand2;
        }
        public override bool IsInside(ref double x, ref double y)
        {
            bool insideOperand1 = operand1.IsInside(ref x, ref y);
            bool insideOperand2 = operand2.IsInside(ref x, ref y);
            return insideOperand1 | insideOperand2;
        }
    }
    public class Difference : Operation
    {
        public ImplicitGeometry operand1;
        public ImplicitGeometry operand2;
        public Difference(ref Rectangle operand1, ref Rectangle operand2) : base(ref operand1, ref operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public override bool IsInside(ref double y)
        {

            bool insideOperand1 = operand1.IsInside(ref y);
            bool outsideOperand2 = !operand2.IsInside(ref y);
            return insideOperand1 || outsideOperand2;
        }
        public override bool IsInside(ref double x, ref double y)
        {
            bool insideOperand1 = operand1.IsInside(ref x, ref y);
            bool outsideOperand2 = operand2.IsInside(ref x, ref y);
            return insideOperand1 | outsideOperand2;
        }
    }
    public class Intersection : Operation
    {
        public ImplicitGeometry operand1;
        public ImplicitGeometry operand2;
        public Intersection(ref Rectangle operand1, ref Rectangle operand2) : base(ref operand1, ref operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public override bool IsInside(ref double y)
        {

            bool insideOperand1 = operand1.IsInside(ref y);
            bool insideOperand2 = operand2.IsInside(ref y);
            return insideOperand1 && insideOperand2;
        }
        public override bool IsInside(ref double x, ref double y)
        {
            bool insideOperand1 = operand1.IsInside(ref x, ref y);
            bool insideOperand2 = operand2.IsInside(ref x, ref y);
            return insideOperand1 && insideOperand2;
        }
    }
}

