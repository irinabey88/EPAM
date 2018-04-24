using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface describes data receiving
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public interface IDataReceiver<out T>
    {
        /// <summary>
        /// Get list data element
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetData();
    }
}