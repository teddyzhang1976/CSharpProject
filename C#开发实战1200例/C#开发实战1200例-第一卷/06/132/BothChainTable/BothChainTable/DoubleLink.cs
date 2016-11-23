using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BothChainTable
{
    public class Objects
    {
        private int number;          /**//* 货物编号 */
        private string name;      /**//* 货物名称 */
        private int counter;        /**//* 货物数量 */

        //构造函数
        public Objects(int num, string Name, int count)
        {
            number = num;
            name = Name;
            counter = count;
        }
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
            }
        }
    }

    // 结点类
    public class ListNode
    {
        public ListNode(Objects bugs)
        {
            goods = bugs;
        }
        /**/
        /// <summary>
        /// 前一个
        /// </summary>     
        public ListNode Previous;

        /**/
        /// <summary>
        /// 后一个
        /// </summary>
        public ListNode Next;
        public ListNode next
        {
            get
            {
                return Next;
            }
            set
            {
                Next = value;
            }
        }
        /**/
        /// <summary>
        /// 值
        /// </summary>
        public Objects goods;
        public Objects Goods
        {
            get
            {
                return goods;
            }
            set
            {
                goods = value;
            }
        }
    }

    public class Clists
    {
        public Clists()
        {
            //构造函数
            //初始化
            ListCountValue = 0;
            Head = null;
            Tail = null;
        }
        /**/
        /// <summary>
        /// 表名
        /// </summary>
        private string clistname = "";
        public string ClistName
        {
            get
            {
                return clistname;
            }
            set
            {
                clistname = value;
            }
        }
        /**/
        /// <summary>
        /// 头指针
        /// </summary>
        private ListNode Head;

        /**/
        /// <summary>
        /// 尾指针
        /// </summary>
        private ListNode Tail;

        /**/
        /// <summary>
        /// 当前指针
        /// </summary>  
        private ListNode Current;
        public ListNode current
        {
            get
            {
                return Current;
            }
            set
            {
                Current = value;
            }
        }

        /**/
        /// <summary>
        /// 链表数据的个数
        /// </summary> 
        private int ListCountValue;

        /**/
        /// <summary>
        /// 尾部添加数据
        /// </summary>

        public void Append(Objects DataValue)
        {
            ListNode NewNode = new ListNode(DataValue);

            if (IsNull())

            //如果头指针为空
            {
                Head = NewNode;

                Tail = NewNode;
            }
            else
            {
                Tail.Next = NewNode;

                NewNode.Previous = Tail;

                Tail = NewNode;
            }

            Current = NewNode;

            //链表数据个数加一

            ListCountValue += 1;

        }

        /**/
        /// <summary>
        /// 删除当前的数据
        /// </summary>
        public void Delete()
        {
            //若为空链表

            if (!IsNull())
            {
                //若删除头

                if (IsBof())
                {
                    Head = Current.Next;
                    Current = Head;
                    ListCountValue -= 1;
                    return;
                }

                //若删除尾

                if (IsEof())
                {
                    Tail = Current.Previous;

                    Tail.next = null;

                    Current = Tail;

                    ListCountValue -= 1;

                    return;
                }

                //若删除中间数据

                Current.Previous.Next = Current.Next;

                Current = Current.Previous;

                ListCountValue -= 1;

                return;
            }
        }
        /**/
        /// <summary>
        /// 向后移动一个数据
        /// </summary>
        public void MoveNext()
        {
            if (!IsEof()) Current = Current.Next;
        }
        /**/
        /// <summary>
        /// 向前移动一个数据
        /// </summary>
        public void MovePrevious()
        {
            if (!IsBof()) Current = Current.Previous;
        }
        /**/
        /// <summary>
        /// 移动到第一个数据
        /// </summary>
        public void MoveFrist()
        {
            Current = Head;
        }

        /**/
        /// <summary>
        /// 移动到最后一个数据
        /// </summary>
        public void MoveLast()
        {
            Current = Tail;
        }
        /**/
        /// <summary>
        /// 判断是否为空链表
        /// </summary>
        public bool IsNull()
        {
            if (ListCountValue == 0)
                return true;
            else
                return false;
        }

        /**/
        /// <summary>
        /// 判断是否为到达尾部
        /// </summary>
        public bool IsEof()
        {
            if (Current == Tail)
                return true;
            else
                return false;
        }
        /**/
        /// <summary>
        /// 判断是否为到达头部
        /// </summary>
        public bool IsBof()
        {
            if (Current == Head)
                return true;
            else
                return false;

        }

        public Objects GetCurrentValue()
        {
            return Current.goods;
        }

        /**/
        /// <summary>
        /// 取得链表的数据个数
        /// </summary>

        public int ListCount
        {
            get
            {
                return ListCountValue;
            }
        }

        /**/
        /// <summary>
        /// 清空链表
        /// </summary>

        public void Clear()
        {
            MoveFrist();
            while (!IsNull())
            {
                //若不为空链表,从尾部删除
                Delete();
            }
        }

        /**/
        /// <summary>
        /// 在当前位置前插入数据
        /// </summary>

        public void Insert(Objects DataValue)
        {
            ListNode NewNode = new ListNode(DataValue);
            if (IsNull())
            {
                //为空表，则添加
                Append(DataValue);
                return;
            }

            if (IsBof())
            {
                //为头部插入
                NewNode.Next = Head;
                Head.Previous = NewNode;
                Head = NewNode;
                Current = Head;
                ListCountValue += 1;
                return;
            }
            //中间插入
            NewNode.Next = Current;
            NewNode.Previous = Current.Previous;
            Current.Previous.Next = NewNode;
            Current.Previous = NewNode;
            Current = NewNode;
            ListCountValue += 1;
        }

        /**/
        /// <summary>
        /// 进行升序插入
        /// </summary>

        public void InsertAscending(Objects InsertValue)
        {
            //参数：InsertValue 插入的数据
            //为空链表
            if (IsNull())
            {
                //添加
                Append(InsertValue);
                return;
            }
            //移动到头
            MoveFrist();
            if ((InsertValue.Number < GetCurrentValue().Number))
            {
                //满足条件，则插入，退出
                Insert(InsertValue);
                return;
            }
            while (true)
            {
                if (InsertValue.Number < GetCurrentValue().Number)
                {
                    //满族条件，则插入，退出
                    Insert(InsertValue);
                    break;
                }

                if (IsEof())
                {
                    //尾部添加
                    Append(InsertValue);
                    break;
                }
                //移动到下一个指针
                MoveNext();
            }
        }
        /**/
        /// <summary>
        /// 进行降序插入
        /// </summary>

        /**/
        /*货物入库*/
        public void InsertUnAscending(Objects InsertValue)
        {
            //参数：InsertValue 插入的数据
            //为空链表
            if (IsNull())
            {
                //添加
                Append(InsertValue);
                return;
            }
            //移动到头
            MoveFrist();
            if (InsertValue.Number > GetCurrentValue().Number)
            {
                //满足条件，则插入，退出
                Insert(InsertValue);
                return;
            }
            while (true)
            {
                if (InsertValue.Number > GetCurrentValue().Number)
                {
                    //满足条件，则插入，退出
                    Insert(InsertValue);
                    break;
                }

                if (IsEof())
                {
                    //尾部添加
                    Append(InsertValue);
                    break;
                }
                //移动到下一个指针
                MoveNext();
            }
        }
        //根据名字查询货物
        public Objects FindObjects(string name)
        {
            ListNode lnode = Head;
            if (IsNull())
            {
                return null;
            }
            else if (IsEof())
            {
                return null;
            }
            else
                while (lnode.goods.Name != name)
                {
                    if (lnode.Next == null)
                    {
                        Current = lnode;
                        return null;
                    }
                    lnode = lnode.Next;
                }
            Current = lnode;
            return lnode.goods;
        }
        //根据编号查询货物
        public Objects FindObjects(int number)
        {
            ListNode lnode = Head;
            if (IsNull())
            {
                return null;
            }
            else if (IsEof())
            {
                return null;
            }
            else
                while (lnode.goods.Number != number)
                {
                    if (lnode.Next == null)
                    {
                        Current = lnode;
                        return null;
                    }
                    lnode = lnode.Next;
                }
            Current = lnode;
            return lnode.goods;
        }
        /**/
        /*货物出库*/
        //根据名字删除货物
        public Objects DeleteObjects(string name)
        {
            Objects bugs;
            bugs = FindObjects(name);
            Delete();
            return bugs;
        }
        //根据编号删除货物
        public Objects DeleteObjects(int number)
        {
            Objects bugs;
            bugs = FindObjects(number);
            Delete();
            return bugs;
        }
    }
}
