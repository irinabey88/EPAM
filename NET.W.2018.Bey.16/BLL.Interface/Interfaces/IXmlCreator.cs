using System.Xml.Linq;

namespace BLL.Interface.Interfaces
{
    public interface IXmlCreator<in T>
    {
        XElement Create(T data);
    }
}