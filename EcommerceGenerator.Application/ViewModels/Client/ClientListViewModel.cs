namespace EcommerceGenerator.Application.ViewModels.Client
{
    public class ClientListViewModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DataBase { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool UpdatedDatabase { get; set; }

    }
}
