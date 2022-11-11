namespace EcommerceGenerator.Application.Validations.Messages
{
    public static class ClientMessages
    {

        public readonly static string EmptyClientName = "Por favor informe o nome do cliente";
        public readonly static string EmptyClientHost = "Por favor informe um ambiente válido para o cliente";
        public readonly static string ClientDuplicatedName = "Já existe um cliente com este nome";
        public readonly static string ClientDuplicatedHost = "Já existe um cliente com este ambiente";
        public readonly static string SuccessRegisterClient = "Cliente cadastrado com sucesso!";
        public readonly static string ErrorRegisteringClient = "Não foi possível cadastrar o cliente";
        public readonly static string NotFoundedClient = "O cliente não foi encontrado";
        public readonly static string SuccessDeleteClient = "O cliente foi excluído com sucesso";
        public readonly static string ErrorDeleteClient = "Não foi possível excluir o cliente";
        public readonly static string SuccessUpdateClient = "O cliente foi alterado com sucesso";
        public readonly static string ErrorUpdateClient = "Não foi possível alterar o cliente";
        public readonly static string ErrorUpdateOutdatedClient = "Não foi possível atualizar o cliente";
        public readonly static string SuccessUpdatedOutdatedClient = "Cliente atualizado com sucesso";
        public readonly static string DatabaseUpdated = "O cliente já está atualizado";
        public readonly static string AllClientsUpdates = "Todos os clientes já estão atualizado";
        public readonly static string ErrorUpdatedOutdatedClients = "Não foi possível atualizar os clientes";
        public readonly static string SucessUpdatedOutdatedClients = "Todos os clientes foram atualizados";

    }
}
