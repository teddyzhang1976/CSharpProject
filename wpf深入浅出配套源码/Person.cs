using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApplication1
{
    public class Person
    {
        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble,typeof(RoutedEventHandler),typeof(Person));

        //为界面添加路由侦听
        public static void AddNameChangedHandle(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if(null!=e)
            {
                e.AddHandler(NameChangedEvent, h);
            }
        }
        //移除侦听
        public static void RemoveNameChangedHandle(DependencyObject d,RoutedEventHandler h)
        {
            UIElement e = d as UIElement;
            if(null!=e)
            {
                e.RemoveHandler(NameChangedEvent,h);
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
