using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class GenericInsert
    {
        //泛型方法将数据插入二叉树
        public static void Insert<TItem>(ref Tree<TItem> tree,params TItem[] data)where TItem:IComparable<TItem>
        {
            foreach (TItem value in data)
            {
                if (tree == null)
                {
                    tree = new Tree<TItem>(value);
                }
                else
                {
                    tree.Insert(value);
                }
            }
        }
    }
}
