using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private IList<T> list;

    public Box()
    {
        this.list = new List<T>();
    }
    
    public void Add(T element)
    {
        list.Add(element);
    }

    public T Remove()
    {
        T element = this.list.LastOrDefault();
        this.list.RemoveAt(this.list.Count - 1);

        return element;
    }

    public int Count => this.list.Count;
}

