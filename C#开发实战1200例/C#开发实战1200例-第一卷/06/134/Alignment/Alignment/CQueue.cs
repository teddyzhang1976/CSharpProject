using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnilateralismChainTable;

namespace Alignment
{
    /// <summary>
    /// 队列类
    /// </summary>

    public class CQueue
    {
        private Clist m_List;

        public CQueue()
        {
            //构造函数

            //这里使用到前面编写的List 
            m_List = new Clist();

        }
        /// <summary>
        /// 入队
        /// </summary>
        public void EnQueue(int DataValue)
        {
            //功能：加入队列，这里使用List 类的Append 方法：

            //尾部添加数据，数据个数加1

            m_List.Append(DataValue);
        }

        /// <summary>
        /// 出队
        /// </summary>

        public int DeQueue()
        {
            //功  能：出队

            //返回值： 2147483647 表示为空队列无返回

            int QueValue;

            if (!IsNull())
            {
                //不为空的队列

                //移动到队列的头

                m_List.MoveFrist();

                //取得当前的值

                QueValue = m_List.GetCurrentValue();

                //删除出队的数据

                m_List.Delete();

                return QueValue;

            }
            return 2147483647;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>

        public bool IsNull()
        {
            //功能：判断是否为空的队列

            return m_List.IsNull();

        }

        /// <summary>
        /// 清空队列
        /// </summary>

        public void Clear()
        {
            //清空链表
            m_List.Clear();
        }
        /// <summary>
        /// 取得队列的数据个数
        /// </summary>
        public int QueueCount
        {
            get
            {
                //取得队列的个数
                return m_List.ListCount;
            }
        }

    }
}
