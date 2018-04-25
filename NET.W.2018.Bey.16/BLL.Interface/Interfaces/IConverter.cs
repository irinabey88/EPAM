namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Convert data in diffrent formats
    /// </summary>
    /// <typeparam name="TResult">Type result data</typeparam>
    public interface IConverter<out TResult>
    {
        TResult Convert();
    }
}