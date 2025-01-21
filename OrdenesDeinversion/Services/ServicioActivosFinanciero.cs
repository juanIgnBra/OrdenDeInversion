
using Microsoft.EntityFrameworkCore;
using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Services.Entity;
using System;

namespace OrdenesDeinversion.Services
{
    public class ServicioActivosFinanciero : Service<Activos>, IServicioActivosFinanciero
    {

        private readonly ILogger<ServicioActivosFinanciero> _logger;
        public ServicioActivosFinanciero(ILogger<ServicioActivosFinanciero> logger, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._logger = logger;
        }

        public async Task<Activos?> VerificarServicioFinanciero(string ticker)
        {
            IQueryable<Activos?> activos = new List<Activos>().AsQueryable();
            try
            {
                activos = base.GetAll().Where(x => x.Ticker.ToUpper() == ticker.ToUpper());        
            }
            catch (Exception ex) 
            {
                _logger.LogError("error servicio: VerificarServicioFinanciero. " + "mensaje error: " + ex.Message);
                throw;
            }
            return await activos.FirstOrDefaultAsync();
        }
    }
}
