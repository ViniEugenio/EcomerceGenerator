namespace EcommerceGenerator.Application.Validations.Messages
{
    public static class UserMessages
    {

        public readonly static string CreateUserSuccess = "Usuário cadastrado com sucesso";
        public readonly static string CreateUserError = "Não foi possível cadastrar o usuário";
        public readonly static string NotFoundUser = "Usuário não encontrado";
        public readonly static string InvalidLogin = "Usuário e/ou senha incorretas";
        public readonly static string LoginError = "Não foi possível logar o usuário";
        public readonly static string LoginSuccess = "Usuário logado com sucesso";
        public readonly static string EmptyUserName = "Por favor informe o nome do usuário";
        public readonly static string EmptyUserEmail = "Por favor informe o email do usuário";
        public readonly static string EmptyIdentifier = "Por favor informe o username do usuário";
        public readonly static string EmptyUserPassword = "Por favor informe a senha do usuário";
        public readonly static string DuplicatedUserEmail = "Já existe outro usuário com este email";
        public readonly static string DuplicatedUserName = "Já existe outro usuário com este 'UserName'";

    }

}
