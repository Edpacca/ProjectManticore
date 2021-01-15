using System.Collections.Generic;

namespace ManticoreViewer
{
    public interface IFileDeserialiser
    {
        List<object> Deserialise(string filePath);
    }
}
