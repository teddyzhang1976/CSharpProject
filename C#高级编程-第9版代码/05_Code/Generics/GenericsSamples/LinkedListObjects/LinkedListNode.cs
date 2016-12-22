
namespace Wrox.ProCSharp.Generics
{
  public class LinkedListNode
  {
    public LinkedListNode(object value)
    {
      this.Value = value;
    }

    public object Value { get; private set; }

    public LinkedListNode Next { get; internal set; }
    public LinkedListNode Prev { get; internal set; }
  }

}
