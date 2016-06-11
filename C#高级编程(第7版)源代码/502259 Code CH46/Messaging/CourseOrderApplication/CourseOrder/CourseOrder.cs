namespace Wrox.ProCSharp.Messaging
{
    public class CourseOrder
    {
        public const string CourseOrderQueueName = "FormatName:Public=D99CE5F3–4282–4a97–93EE-E9558B15EB13";

        public Customer Customer { get; set; }
        public Course Course { get; set; }
    }

}
