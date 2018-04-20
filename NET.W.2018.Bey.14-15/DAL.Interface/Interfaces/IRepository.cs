using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Describes base repository logic
    /// </summary>
    /// <typeparam name="TModel">Type repository element</typeparam>
    public interface IRepository<TModel>
    {
       /// <summary>
        /// Finds one element by id
        /// </summary>
        /// <param name="id">Element id</param>
        /// <returns><value>Element if it is found</value>
        /// <value>null - other wise</value></returns>
        TModel Get(int id);

        /// <summary>
        /// Finds one element 
        /// </summary>
        /// <param name="model">Element</param>
        /// <returns><value>Element if it is found</value>
        /// <value>null - other wise</value></returns>
        TModel Get(TModel model);

        /// <summary>
        /// Adds new element to repository
        /// </summary>
        /// <param name="model">Element</param>
        /// <returns><value>Element if it is added</value>
        /// <value>Null - other wise</value></returns>
        TModel Add(TModel model);

        /// <summary>
        /// Updates element from repository
        /// </summary>
        /// <param name="model">Element</param>
        /// <returns><value>Element if it is updated</value>
        /// <value>Null - other wise</value></returns>
        TModel Update(TModel model);

        /// <summary>
        /// Gets all elements from repository
        /// </summary>
        /// <returns>Enumeration of elements</returns>
        IEnumerable<TModel> GetAllElements();
    }
}