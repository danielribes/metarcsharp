using System;

namespace metar 
{
    class DayTime : IParser
    {

        public string Parse(string code)
        {
            return CreateDateTime(code);
        }

        private string CreateDateTime(string dateAndTime)
        {
            string day = dateAndTime.Substring(0,2);
            string hour = dateAndTime.Substring(2,2);
            string minutes = dateAndTime.Substring(4,2);

            return day +", " + hour + ":" + minutes + " UTC";
        }
    }
}