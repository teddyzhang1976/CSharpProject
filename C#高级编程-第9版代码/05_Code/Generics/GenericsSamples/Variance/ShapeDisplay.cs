using System;

namespace Wrox.ProCSharp.Generics
{
  public class ShapeDisplay : IDisplay<Shape>
  {
    public void Show(Shape s)
    {
      Console.WriteLine("{0} Width: {1}, Height: {2}", s.GetType().Name, s.Width, s.Height);
    }
  }
}
