using Task_1_Library;

namespace Task_2
{
    [TrackingEntity]
    public class Metal
    {
        [TrackingProperty]
        public string Name { get; set; }

        [TrackingProperty]
        public int Weight { get; set; }

        [TrackingProperty]
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, Price: {Price}";
        }
    }
}
