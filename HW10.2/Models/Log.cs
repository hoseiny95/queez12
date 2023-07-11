namespace HW10._2.Models
{
    public class Log
    {
        public Log(string url)
        {
            timestamp = DateTime.Now;

            Url = url;

        }
        public DateTime timestamp { get; set; }
        public string Url { get; set; }
        public int resultStatusCode { get; set; }
        public override string ToString()

        {

            return resultStatusCode.ToString() + " : " + timestamp + " : " + Url;

        }




    }



}

