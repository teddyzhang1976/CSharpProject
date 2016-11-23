using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordToSql
{
    /// <summary>
    /// 定义实体类
    /// </summary>
    class InstanceClass
    {
        public long id { get; set; }//定义id属性
        public string Name { get; set; }//定义Name属性
        public double Chinese { get; set; }//定义Chinese属性
        public double Math { get; set; }//定义Math属性
        public double English { get; set; }//定义English属性
    }
}
