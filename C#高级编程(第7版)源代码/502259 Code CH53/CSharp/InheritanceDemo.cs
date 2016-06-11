using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    public abstract class Base
    {
        public virtual void Foo1()
        {
        }

        public abstract void Bar();

    };

    public class Derived : Base
    {
        public override void Foo1()
        {
            base.Foo1();
        }
        public override void Bar()
        {
        }
    };
}
