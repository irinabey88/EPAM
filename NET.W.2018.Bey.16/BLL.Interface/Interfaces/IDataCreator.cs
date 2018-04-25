using System.Xml.Linq;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface describes data creating
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TResult">Result type</typeparam>
    public interface IDataCreator<in TSource, out TResult>
    {
        /// <summary>
        /// Create result data type from input data type
        /// </summary>
        /// <param name="data">Input data</param>
        /// <returns></returns>
        TResult Create(TSource data);
    }
}