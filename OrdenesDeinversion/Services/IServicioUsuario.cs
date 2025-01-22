using OrdenesDeinversion.Models.Auth;
using OrdenesDeinversion.Models.Entity.Dominio;

namespace OrdenesDeinversion.Services
{
    public interface IServicioUsuario
    {
        Task<bool> GetValidacionUsuario(UserLoginModel loginModel);
    }
}
