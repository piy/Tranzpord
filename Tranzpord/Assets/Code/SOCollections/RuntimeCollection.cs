using System.Collections.Generic;
using UnityEngine;


public abstract class RuntimeCollection<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T thing)
    {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }

    public void Remove(T thing)
    {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }

    public bool IsNotEmpty()
    {
        if (Items.Count == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}