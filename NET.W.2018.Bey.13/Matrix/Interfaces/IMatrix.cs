using System;

namespace Matrix.Interfaces
{
    public interface IMatrix<T>
    {
        event EventHandler<ElementChanedEventArgs<T>> ElementChaned;

        int Size { get; }
    }
}