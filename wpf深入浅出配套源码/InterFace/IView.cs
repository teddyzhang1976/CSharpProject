using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1.InterFace
{
    public interface IView
    {
        //属性
        bool IsChanged { get; set; }
        //方法
        void SetBinding();
        void Refresh();
        void Clear();
        void Save();
    }
}
