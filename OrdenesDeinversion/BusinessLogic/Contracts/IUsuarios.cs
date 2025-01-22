using OrdenesDeinversion.Models.Auth;

namespace OrdenesDeinversion.BusinessLogic.Contracts
{
    public interface IUsuarios
    {
        Task<bool> GetUsuario(UserLoginModel loginModel);
    }
}
