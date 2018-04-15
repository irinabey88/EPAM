using System;

namespace Matrix.Interfaces
{
    public interface IMatrix<T>
    {
        int Size { get; }       

        event EventHandler<ElementEventArgs<T>> ElementChaned;  
    }
}