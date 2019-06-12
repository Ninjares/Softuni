using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class MyClass
    {
        public string Name { get; set; }

        public MyClass()
        {
            Name = "";
        }

        public MyClass(string name)
        {
            this.Name = name;
        }
    }



    //class MyClass<T>
    //{
    //    private List<T> innerArr;

    //    public void Add<TItem>(TItem item) where TItem : T
    //    {
    //        innerArr.Add(item);
    //    }
    //}
}
