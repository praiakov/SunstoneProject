namespace Sunstone.Domain
{
    public class Gemstone
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public Colors Color { get; set; }

        public Gemstone(string name, Colors color)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("name cannot be empty or null.");
         
            if (IsColorEnum(color) is false)
                throw new DomainException("color cannot be different from preset colors.");

            Name = name;
            Color = color;
            Created = DateTime.Now;
        }

        /// <summary>
        /// Solution found in
        /// https://www.oreilly.com/library/view/c-cookbook/0596003390/ch04s04.html
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static bool IsColorEnum(Colors color)
        {
            if ((color & Colors.All) == color)
                return (true);
            else
                return (false);
        }
    }
}
