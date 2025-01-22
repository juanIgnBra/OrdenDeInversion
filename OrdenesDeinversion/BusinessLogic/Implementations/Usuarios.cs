using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.Models.Auth;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services;

namespace OrdenesDeinversion.BusinessLogic.Implementations
{
    public class Usuarios : IUsuarios
    {
        private readonly IServicioUsuario servicioUsuario;
        public Usuarios(IServicioUsuario servicioUsuario)
        {
            this.servicioUsuario = servicioUsuario;
        }

        public Task<bool> GetUsuario(UserLoginModel loginModel)
        {
            try
            {
                return this.servicioUsuario.GetValidacionUsuario(loginModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
