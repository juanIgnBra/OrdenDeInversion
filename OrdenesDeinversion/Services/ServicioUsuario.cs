using Microsoft.EntityFrameworkCore;
using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Auth;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services.Entity;

namespace OrdenesDeinversion.Services
{
    public class ServicioUsuario : Service<Usuarios>, IServicioUsuario
    {
        private readonly ILogger<ServicioUsuario> _logger;
        public ServicioUsuario(ILogger<ServicioUsuario> logger, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._logger = logger;
        }

        public async Task<bool> GetValidacionUsuario(UserLoginModel loginModel)
        {
            bool resp = false;
            try
            {
                resp = await Task.Run(() => base.GetAll().Any(x => x.Username.ToUpper() == loginModel.Username.ToUpper() && x.Password.ToUpper() == loginModel.Password.ToUpper()));
            }
            catch (Exception ex)
            {
                _logger.LogError("error servicio: GetValidacionUsuario. " + "mensaje error: " + ex.Message);
                throw;
            }
            return resp;
        }
    }
}
