using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnilateralismChainTable;

namespace StackApply
{
    public class CStack
    {
        //调用链表类
        private Clist m_List;

        public CStack()
        {
            //构造函数
            m_List = new Clist();

        }
        /// <summary>
        /// 压入堆栈
        /// </summary>
        public void Push(int PushValue)
        {
            //参数： int PushValue 压入堆栈的数据
            m_List.Append(PushValue);

        }
        /// <summary>
        /// 弹出堆栈数据,如果为空，则取得 2147483647 为 int 的最大值；
        /// </summary>

        public int Pop()
        {
            //功能：弹出堆栈数据 
            int PopValue;

            if (!IsNullStack())
            {
                //不为空堆栈
                //移动到顶
                MoveTop();
                //取得弹出的数据
                PopValue = GetCurrentValue();
                //删除
                Delete();
                return PopValue;
            }
            //  空的时候为 int 类型的最大值
            return 2147483647;
        }
        /// <summary>
        /// 判断是否为空的堆栈
        /// </summary>
        public bool IsNullStack()
        {
            if (m_List.IsNull())
                return true;
            return false;
        }
        /// <summary>
        /// 堆栈的个数
        /// </summary>
        public int StackListCount
        {
            get
            {
                return m_List.ListCount;
            }

        }

        /// <summary>
        /// 移动到堆栈的底部
        /// </summary>
        public void MoveBottom()
        {
            m_List.MoveFrist();
        }

        /// <summary>
        /// 移动到堆栈的Top
        /// </summary>
        public void MoveTop()
        {
            m_List.MoveLast();
        }
        /// <summary>
        /// 向上移动
        /// </summary>

        public void MoveUp()
        {
            m_List.MoveNext();
        }
        /// <summary>
        /// 向上移动
        /// </summary>

        public void MoveDown()
        {
            m_List.MovePrevious();
        }
        /// <summary>
        /// 取得当前的值
        /// </summary>

        public int GetCurrentValue()
        {
            return m_List.GetCurrentValue();
        }
        /// <summary>
        /// 删除取得当前的结点
        /// </summary>

        public void Delete()
        {
            m_List.Delete();
        }
        /// <summary>
        /// 清空堆栈
        /// </summary>
        public void Clear()
        {
            m_List.Clear();
        }
    }
}
