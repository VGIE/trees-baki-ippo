namespace Lists;

using Lists;
using System.Collections;
using System.Runtime.InteropServices;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list

        return m_numItems;    
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds

        if (index < 0)
        {
            return default(T);
        }
        
        ListNode<T> current = First;
        int count = 0;

        while (current != null)
        {
            if (count == index)
            {
                return current.Value;
            }
            current = current.Next;
            count++;
        }
        
        return default(T);
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list

        ListNode<T> newNode = new ListNode<T>(value);

        if (First == null)
        {
            First = newNode;
            Last = newNode;
        }
        else
        {
            Last.Next = newNode;
            Last = newNode;
        }

        m_numItems++;
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds

        if (index < 0 || index >= m_numItems)
        {
            return default(T);
        }

        T value = Get(index);

        if (index == 0)
        {
            First = First.Next;

            if (First == null)
            {
                Last = null;
            }
            m_numItems--;
            return value;
        }

        ListNode<T> previus = First;
        for(int i = 0; i < index - 1; i++)
        {
            previus = previus.Next;
        }

        ListNode<T> nodeToEliminated = previus.Next;
        previus.Next = nodeToEliminated.Next;

        if (nodeToEliminated == Last)
        {
            Last = previus;
        }

        m_numItems--;

        return value;
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list

        First = null;
        Last = null;
        m_numItems = 0;
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        ListNode<T> current = First;

        while(current != null)
        {
            yield return current.Value;
            current = current.Next;
        }        
    }
}