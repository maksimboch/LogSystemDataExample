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

        public List<Model.LogSystemData> GenerateLogData()
        {
            List<Model.LogSystemData> result = new List<Model.LogSystemData>();
            int logDataCount = _random.Next( 0, 7 );
            if ( logDataCount == 0 ) return result;

            while ( logDataCount > 0 )
            {
                Model.LogSystemData logData = new Model.LogSystemData
                {
                    HotelId = _random.Next( 1, 222 ),
                    Warning = GetRandomWarning(),
                    Error = GetRandomError(),
                    TimestampUtc = DateTime.UtcNow,
                    AdditionalInfo = null
                };

                bool shouldSendWarning = DateTime.Now.Second % 3 == 0;

                if ( shouldSendWarning )
                {
                    logData.Error = null;
                }
                else
                {
                    logData.Warning = null;
                    logData.AdditionalInfo = GetAdditionalInfo( logData.Error );
                }
                
                result.Add( logData );
                logDataCount--;
            }
            
            return result;
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
            "OutOfMemoryException",
            "IndexOutOfRangeException",
            "ArgumentNullException",
            "DivideByZeroException",
            "RatePlan not found",
            "RoomType not found"
        };

        private string GetAdditionalInfo( string error )
        {
            if ( string.IsNullOrWhiteSpace( error ) )
            {
                return null;
            }
            else if ( error == "OutOfMemoryException" )
            {
                return
                    "Description: The application requested process termination through System.Environment.FailFast(string message).\r\n" +
                    "Message: Out of Memory: Insufficient memory to continue the execution of the program.\r\nStack:\r\n   " +
                    "at System.Environment.FailFast(System.String)\r\n   at Airbrake.OutOfMemoryException.Program.ThrowExample()\r\n   " +
                    "at Airbrake.OutOfMemoryException.Program.Main(System.String[])";
            }
            else if ( error == "IndexOutOfRangeException" )
            {
                return
                    "Unhandled Exception:\r\nSystem.IndexOutOfRangeException: Index was outside the bounds of the array." +
                    "\r\nat GFG.Main (System.String[] args) <0x40bdbd50 + 0x00067> in :0\r\n[ERROR] " +
                    "FATAL UNHANDLED EXCEPTION: System.IndexOutOfRangeException: Index was outside the bounds " +
                    "of the array.\r\nat GFG.Main (System.String[] args) <0x40bdbd50 + 0x00067> in :0 ";
            }
            else if ( error == "ArgumentNullException" )
            {
                return "System.ArgumentNullException: Value cannot be null." +
                       "\r\nParameter name: roomTypeId";
            }
            else if ( error == "DivideByZeroException" )
            {
                return "Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.\r\n   " +
                       "at Program.Main() in ... Program.cs:line 11";
            }
            else
            {
                return null;
            }
        }
    }
}