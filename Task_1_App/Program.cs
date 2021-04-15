using Task_1_Library;
using Task_2;

namespace Task_1_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var silver = new Metal {Name = "Silver", Weight = 2000, Price = 200.5};

            var logger = new Logger("log.json");

            logger.Track(silver);
        }
    }
}
