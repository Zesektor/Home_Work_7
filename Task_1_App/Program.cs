using Task_1_Library;

namespace Task_1_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var amzon = new Stock("Amzon", 2000);
            Stock aple = new();

            var logger = new Logger("log.json");

            logger.Track(aple);
        }
    }
}
