namespace EcommerceGenerator.Application.ViewModels
{
    public class ResponseViewModel
    {

        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public object Data { get; set; }

        public void AddError(string Message)
        {
            Errors.Add(Message);
        }

        public void AddMessage(string Message)
        {
            this.Message = Message;
        }

        public string GetMessage()
        {
            return Message;
        }

        public bool IsValid()
        {
            return !Errors.Any();
        }

        public void AddData(object Data)
        {
            this.Data = Data;
        }

    }
}
