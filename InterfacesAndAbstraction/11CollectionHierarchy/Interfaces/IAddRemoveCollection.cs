﻿namespace _11CollectionHierarchy.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
