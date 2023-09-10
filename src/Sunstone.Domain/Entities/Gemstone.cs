namespace Sunstone.Domain
{
    internal class Gemstone
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; private set; }
        public Colors Color { get; private set; }

        public Gemstone(string name, decimal carat, decimal clarity, Colors color)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("name cannot be empty or null.");

            if (carat <= 0)
                throw new DomainException("carat cannot be under or equal to zero.");

            if (clarity <= 0)
                throw new DomainException("clarity cannot be under or equal to zero.");

            if (IsColorEnum(color) is false)
                throw new DomainException("color cannot be different from preset colors.");

            Name = name;
            Color = color;
        }

        /// <summary>
        /// Solution found in
        /// https://www.oreilly.com/library/view/c-cookbook/0596003390/ch04s04.html
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool IsColorEnum(Colors color)
        {
            if ((color & Colors.All) == color)
                return (true);
            else
                return (false);
        }
    }
}
