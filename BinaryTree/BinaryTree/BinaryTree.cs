using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Tree<TItem>: IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        //节点值
        public TItem NodeData{ get; set; }
        //左子树
        public Tree<TItem> LeftTree { get; set; }
        //右子树
        public Tree<TItem> RightTree { get; set; }

        //默认构造器构造二叉树
        public Tree()
        {
            this.NodeData = default(TItem);
            this.LeftTree = null;
            this.RightTree = null;
        }

        //非默认构造器构造二叉树
        public Tree(TItem nodeValue)
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }

        //将数据插入树
        public void Insert(TItem newValue)
        {
            TItem item = this.NodeData;
            if(item.CompareTo(newValue)>0)
            {
                if(this.LeftTree==null)
                {
                    this.LeftTree = new Tree<TItem>(newValue);
                }
                else
                {
                    this.LeftTree.Insert(newValue);
                }
            }
            else
            {
                if(this.RightTree==null)
                {
                    this.RightTree = new Tree<TItem>(newValue);
                }
                else
                {
                    this.RightTree.Insert(newValue);
                }
            }
        }
        
        //泛型方法将数据插入二叉树
        public void Insert<T>(ref Tree<T> tree, params T[] data) where T : IComparable<T>
        {
            foreach (T value in data)
            {
                if (tree == null)
                {
                    tree = new Tree<T>(value);
                }
                else
                {
                    tree.Insert(value);
                }
            }
        }

        //遍历二叉树
        public string WalkTree()
        {
            string result = "";

            if(this.LeftTree!=null)
            {
                result = this.LeftTree.WalkTree();
            }

            result += String.Format($"{this.NodeData}");

            if(this.RightTree!=null)
            {
                result += this.RightTree.WalkTree();
            }

            return result;
        }

        //泛型接口方法的实现，返回一个枚举器对象
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return new TreeEnumerator<TItem>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
