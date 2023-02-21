namespace API_with_EF_2022.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public bool FreshWater { get; set; }
        public bool SaltWater { get; set; }

    }
}
