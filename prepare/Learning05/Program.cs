using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Square sShape= new Square();
        sShape.SetColor("Yellow");
        sShape.SetSide(15);

        Rectangle rShape = new Rectangle();
        rShape.SetColor("Blue");
        rShape.SetLength(15);
        rShape.SetWidth(10);

        Circle cShape = new Circle();
        cShape.SetColor("Red");
        cShape.SetRadius(15);

        DisplayShapeInformation (sShape);
        DisplayShapeInformation (rShape);
        DisplayShapeInformation (cShape);
        
        List<Shape> shapes = new List<Shape>();
        shapes.Add(sShape);
        shapes.Add(rShape);        
        shapes.Add(cShape);

        foreach (Shape shape in shapes)
        {
            double area = shape.GetArea();
        }

        void DisplayShapeInformation (Shape shape)
        {
            double area = shape.GetArea(); 
            Console.WriteLine ($"The area of {shape} is {area}");
        }
    }
}