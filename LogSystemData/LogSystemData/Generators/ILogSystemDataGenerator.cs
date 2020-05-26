using System.Collections.Generic;

namespace LogSystemData.Generators
{
    public interface ILogSystemDataGenerator
    {
        List<Model.LogSystemData> GenerateLogData();
    }
}