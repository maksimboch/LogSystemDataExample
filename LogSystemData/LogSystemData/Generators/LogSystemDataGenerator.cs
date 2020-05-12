using System;
using System.Collections.Generic;
using LogSystemData.Model;

namespace LogSystemData.Generators
{
    public class LogSystemDataGenerator : ILogSystemDataGenerator
    {
        private readonly Random _random;

        public LogSystemDataGenerator()
        {
            _random = new Random();
        }

        public Model.LogSystemData GenerateLogData()
        {
            Model.LogSystemData logData = new Model.LogSystemData
            {
                HotelId = _random.Next( 1, 100 ),
                Warning = GetRandomWarning(),
                Error = GetRandomError()
            };

            bool shouldSendWarning = DateTime.Now.Second % 2 == 0;

            if ( shouldSendWarning )
            {
                logData.Error = null;
            }
            else
            {
                logData.Warning = null;
            }

            return logData;
        }

        private string GetRandomWarning()
        {
            return Warnings.PickRandom();
        }

        private string GetRandomError()
        {
            return Errors.PickRandom();
        }

        private List<string> Warnings = new List<string>()
        {
            "Unable to find hotel availability",
            "Empty Address field",
            "Empty Longitude field",
            "Empty Latitude field",
            "Empty PhoneNumber field",
        };

        private List<string> Errors = new List<string>()
        {
            "Out of memory",
            "HotelId not found",
            "DB not available",
            "RatePlan not found",
            "RoomType not found"
        };
    }
}