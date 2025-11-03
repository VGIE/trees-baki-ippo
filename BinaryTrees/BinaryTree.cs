
using System;
namespace BinaryTrees
{

    public class BinaryTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BinaryTreeNode<TKey, TValue> RootNode;

        public override string ToString()
        {
            if (RootNode == null)
                return null;
            else return RootNode.ToString(0);
        }

        public int Count()
        {
            if (RootNode == null)
                return 0;
            return RootNode.Count();
        }

        public int Height()
        {
            if (RootNode == null)
                return 0;
            return RootNode.Height();
        }

        public TValue Get(TKey key)
        {
            if (RootNode == null)
                throw new Exception("Empty tree");
            else
            {
                return RootNode.Get(key);
            }
        }

        public void Add(TKey key, TValue value)
        {
            BinaryTreeNode<TKey, TValue> newNode = new BinaryTreeNode<TKey, TValue>(key, value);
            if (RootNode == null)
                RootNode = newNode;
            else
                RootNode.Add(newNode);
        }

        public void Remove(TKey key)
        {
            if (RootNode != null)
                RootNode = RootNode.Remove(key);
        }

        public TKey[] Keys()
        {
            if (RootNode == null)
                return null;
            int count = RootNode.Count();
            TKey[] keys = new TKey[count];
            RootNode.KeysToArray(keys, 0);
            return keys;
        }

        public TValue[] Values()
        {
            if (RootNode == null)
                return null;
            int count = RootNode.Count();
            TValue[] values = new TValue[count];
            RootNode.ValuesToArray(values, 0);
            return values;
        }

        private BinaryTreeNode<TKey, TValue> AddBalanced(TKey[] keys, TValue[] values, int start, int end)
        {
            int center;
            BinaryTreeNode<TKey, TValue> node;

            if (start > end)
                return null;

            center = (start + end) / 2;
            node = new BinaryTreeNode<TKey, TValue>(keys[center], values[center]);

            node.LeftChild = AddBalanced(keys, values, start, center - 1);
            node.RightChild = AddBalanced(keys, values, center + 1, end);

            return node;
            
        }

        public void Balance()
        {
            if (RootNode == null)
                return;
            TKey[] keys = Keys();
            TValue[] values = Values();

            RootNode = AddBalanced(keys, values, 0, keys.Length - 1);
        }
    }
}