using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClasses
{
    //外部类
    public class Outer
    {
        //外部类的默认构造器
        public Outer() { }
        
        //外部类的非静态方法
        public void Show()
        {
            Console.WriteLine("成功引用与嵌套类同名的外部类非静态方法");
        }

        //外部类的静态方法
        public static void OuterStaticMethod()
        {
            Console.WriteLine("成功引用外部类的静态方法");
        }

        //嵌套类、内部类
        //声明为公共类，可在作用域外引用
        public class Nested
        {
            //嵌套类的默认构造器
            public Nested()
            {
                Console.WriteLine("成功创建嵌套类的实例");
            }

            //嵌套类与外部类同名的非静态方法
            public void Show()
            {

                Console.WriteLine("这是嵌套类与外部类同名的非静态方法");

                //创建外部类的对象以引用外部类非静态方法
                Outer outer = new Outer();
                outer.Show();

                //引用外部类的静态成员时可省略类名
                OuterStaticMethod();
            }
        }

        //外部类用于创建嵌套类对象的方法
        public void CreateNC()
        {
            Nested nc = new Nested();
        }
    }
}