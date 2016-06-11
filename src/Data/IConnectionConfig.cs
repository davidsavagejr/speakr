using System.Data.Common;

namespace Data
{
    public interface IConnectionConfig
    {
        string ConnectionString { get; }
    }
}