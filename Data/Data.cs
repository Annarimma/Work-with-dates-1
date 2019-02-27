using System;

namespace Data
{
    class Date
    {
        public struct YMD
        {
            public uint year;
            public uint month;
            public uint day;
        };

        public string dataString;

        public YMD  ymd;

        public Date()
        {

        }

        public void Init(uint year, uint month, uint day)
        {
            ymd.year = year;
            ymd.month = month;
            ymd.day = day;
        }

        public void Init(DateTime data)
        {
            ymd.year = Convert.ToUInt32(data.Year);
            ymd.month = Convert.ToUInt32(data.Month);
            ymd.day = Convert.ToUInt32(data.Day);
        }

        public void Init(string data)
        {
            dataString = data;
        }
    }
}