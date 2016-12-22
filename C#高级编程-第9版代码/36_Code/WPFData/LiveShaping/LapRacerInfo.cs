
namespace Wrox.ProCSharp.WPF
{
  public enum PositionChange
  {
    None,
    Up,
    Down,
    Out
  }

  public class LapRacerInfo : BindableObject
  {
    public Racer Racer { get; set; }
    private int lap;
    public int Lap
    {
      get { return lap; }
      set { SetProperty(ref lap, value); }
    }
    private int position;
    public int Position
    {
      get { return position; }
      set { SetProperty(ref position, value); }
    }
    private PositionChange positionChange;
    public PositionChange PositionChange
    {
      get { return positionChange; }
      set { SetProperty(ref positionChange, value); }
    }
  }
}
