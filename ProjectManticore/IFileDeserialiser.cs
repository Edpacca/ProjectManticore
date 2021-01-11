using System.Collections.Generic;

namespace ProjectManticore
{
    public interface IFileDeserialiser
    {
        List<object> Deserialise(string filePath);
    }
}
