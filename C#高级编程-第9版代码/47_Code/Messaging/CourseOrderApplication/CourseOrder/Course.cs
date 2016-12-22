namespace Wrox.ProCSharp.Messaging
{
   public class Course : BindableBase
   {
     private string title;

     public string Title
     {
       get { return title; }
       set
       {
         SetProperty(ref title, value);
       }
     }     
   }

}
