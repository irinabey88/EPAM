namespace Common.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes base repository logic
    /// </summary>
    /// <typeparam name="TModel">Type repository element</typeparam>
    public interface IRepository<TModel>
    {
        /// <summary>
        /// Load all data from repository 
        /// </summary>
        /// <returns>Enumeration of elements</returns>
        IEnumerable<TModel> Load();

        /// <summary>
        /// Finds one element by id
        /// </summary>
        /// <param name="id">Element id</param>
        /// <returns><value>Element if it is found</value>
        /// <value>null - other wise</value></returns>
        TModel Get(string id);

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
        /// Delets element from repository
        /// </summary>
        /// <param name="model">Element</param>
        /// <returns><value>Element if it is deleted</value>
        /// <value>Null - other wise</value></returns>
        TModel Delete(TModel model);

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