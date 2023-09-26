namespace Lab_4.Models
{
    internal class Test
    {
        public string Name { get; set; }
        public bool IsPassed { get; set; }

        public Test(string name, bool isPassed)
        {
            this.Name = name;
            this.IsPassed = isPassed;
        }

        public Test()
        {
            this.IsPassed = false;
            this.Name = "Linal";
        }

        public override string ToString()
        {
            return $"Name: {this.Name} IsPassed: {this.IsPassed}";
        }
        

    }
}
