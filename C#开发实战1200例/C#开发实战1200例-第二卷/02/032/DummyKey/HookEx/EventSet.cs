using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HookEx
{
    public sealed class EventKey : Object
    {

    }

    public sealed class EventSet
    {
        //实例化一个键和值类
        private Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        //实例化一个委托
        public Delegate this[EventKey eventKey]
        {
            get
            {
                if (this.m_events.ContainsKey(eventKey))
                {
                    return this.m_events[eventKey];
                }

                return null;
            }
        }

        /// <summary>
        /// 添加键值
        /// </summary>
        public void Add(EventKey eventKey, Delegate handler)
        {
            lock (m_events)
            {
                Delegate d;
                m_events.TryGetValue(eventKey, out d);
                m_events[eventKey] = Delegate.Combine(d, handler);
            }
        }

        /// <summary>
        /// 移除指定的键值
        /// </summary>
        public void Remove(EventKey eventKey, Delegate handler)
        {
            lock (m_events)
            {
                Delegate d;
                if (m_events.TryGetValue(eventKey, out d))
                {
                    d = Delegate.Remove(d, handler);

                    if (d != null)
                        m_events[eventKey] = d;
                    else
                        m_events.Remove(eventKey);
                }
            }
        }

        /// <summary>
        /// 获取与指定键相关的值
        /// </summary>
        public void Raise(EventKey eventKey, Object sender, EventArgs e)
        {
            Delegate d;
            lock (m_events)
            {
                m_events.TryGetValue(eventKey, out d);
            }
            if (d != null)
            {
                d.DynamicInvoke(sender, e);
            }
        }
    }
}
