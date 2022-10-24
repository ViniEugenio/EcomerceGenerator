namespace EcommerceGenerator.Domain.Entites
{
    public abstract class BaseEntity
    {

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;

    }
}
