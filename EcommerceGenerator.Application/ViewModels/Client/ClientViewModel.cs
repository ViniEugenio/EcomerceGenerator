namespace EcommerceGenerator.Application.ViewModels.Client
{
    public class ClientViewModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DataBase { get; set; }
        public string Host { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool UpdatedDatabase { get; set; }
        public bool Active { get; set; }

    }
}
