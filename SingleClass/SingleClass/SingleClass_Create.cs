using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleClass
{
    public class SingleClass_Create
    {
        //声明私有静态字段存储唯一实例
        private static SingleClass_Create sc;

        //私有默认构造器构造唯一实例
        private SingleClass_Create() 
        {
            Console.WriteLine("已创建唯一实例");
        }

        //公共静态方法创建唯一实例
        public static SingleClass_Create CreateSC()
        {
            //判断是否已创建实例
            if(sc==null)
            {
                sc = new SingleClass_Create();
            }

            //返回值
            return sc;
        }
    }
}
