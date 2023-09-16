namespace Sunstone.Application
{
    public class CreateViewModel
    {
        public Guid Id { get; set; }

        public CreateViewModel(Guid id)
        {
            Id = id;
        }
    }
}
