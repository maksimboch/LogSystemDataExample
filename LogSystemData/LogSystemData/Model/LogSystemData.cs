using System;
using System.Collections.Generic;

namespace LogSystemData.Model
{
    public class LogSystemData
    {
        public int HotelId { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime TimestampUtc { get; set; }
    }
}