using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertToSQL
{
    class Time
    {
        public string Times { get; set; }//时间字符串
        public byte Hours { get; set; }//小时
        public byte Minutes { get; set; }//分钟
        public byte Seconds { get; set; }//秒
        public bool Execute { set; get; }//任务是否已经执行
        public override string ToString()//重写基类的ToString方法
        {
            return Times;//返回时间字符串
        }
    }
}
