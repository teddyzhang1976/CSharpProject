class program
{
    static void Main()
    {
        System.Console.Title = "循环向控制台中输入内容";//定义控制台标题
        System.Console.WindowWidth = 30;//设置控制台窗体宽度
        System.Console.WindowHeight = 2;//设置控制台窗体高度
        for (; ; )//开始无限循环
        {
            System.Console.WriteLine("当前系统时间是：{0}",//输出系统当前时间
                System.DateTime.Now.ToString("dd日 hh:mm:sss"));
            System.Threading.Thread.Sleep(1000);//线程挂起1秒钟
            System.Console.Clear();//清空控制台信息
        }
    }
}