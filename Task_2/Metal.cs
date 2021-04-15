namespace Task_2
{
    public class Metal
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, Price: {Price}";
        }
    }
}
