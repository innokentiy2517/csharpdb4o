using System.Collections.Generic;
using Perst;

namespace Lab1
{
    public interface IRead<T>
    {
        List<T> Read(FieldIndex fieldIndex);
    }
}