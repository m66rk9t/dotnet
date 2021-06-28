using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeEnumerator<TItem>: IEnumerator<TItem> where TItem :IComparable<TItem>
    {
        //存储二叉树的引用
        private Tree<TItem> tree = null;
        //存储Current属性返回值
        private TItem nodeValue = default(TItem);
        //存储节点值的队列
        private Queue<TItem> data = null;
        private bool disposedValue;

        //初始化字段
        public TreeEnumerator(Tree<TItem> item)
        {
            this.tree = item;
        }
        
        //指向下一项
        bool IEnumerator.MoveNext()
        {
            //填充队列
            if(this.data==null)
            {
                this.data = new Queue<TItem>();
                Pop(this.data, this.tree);
            }

            //出队
            if(this.data.Count>0)
            {
                this.nodeValue = this.data.Dequeue();
                return true;
            }

            return false;
        }

        //访问当前指向的数据项
        TItem IEnumerator<TItem>.Current
        {
            get
            {
                if(this.data==null)
                {
                    throw new InvalidOperationException("调用Current前先调用一次Move方法");
                }

                return this.nodeValue;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        

        //填充队列的方法
        private void Pop(Queue<TItem> QData,Tree<TItem> tree)
        {
            if(tree.LeftTree!=null)
            {
                Pop(QData, tree.LeftTree);
            }

            QData.Enqueue(tree.NodeData);

            if(tree.RightTree!=null)
            {
                Pop(QData, tree.RightTree);
            }
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~TreeEnumerator()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
