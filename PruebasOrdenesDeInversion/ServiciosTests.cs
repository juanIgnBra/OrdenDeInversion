



using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using OrdenesDeinversion.BusinessLogic.Contracts;
using OrdenesDeinversion.BusinessLogic.Implementations;
using OrdenesDeinversion.DAL;
using OrdenesDeinversion.Models.Entity.Dominio;
using OrdenesDeinversion.Models.Negocio;
using OrdenesDeinversion.Services;



namespace PruebasOrdenesDeInversion
{
    [TestFixture]
    public class ServiciosTests
    {
        private Mock<IServicioOrdenesDeInversion> _mockServicioOrdenesDeInversion;
        private ConsultarOrdenDeInversion _consultarOrdenDeInversion;

        [SetUp]
        public void Setup()
        {
            _mockServicioOrdenesDeInversion = new Mock<IServicioOrdenesDeInversion>();
            _consultarOrdenDeInversion = new ConsultarOrdenDeInversion(_mockServicioOrdenesDeInversion.Object);
        }

        [Test]
        public async Task GetOperacion_DeberiaLlamarGetOrdenDeInversion_CuandoIdEsValido()
        {
            // Arrange
            var id = 1;
            var ordenDeInversion = new OrdenesDeInversion { IdDeLaOrden = id };
            _mockServicioOrdenesDeInversion
                .Setup(s => s.GetOrdenDeInversion(It.IsAny<int>()))
                .ReturnsAsync(ordenDeInversion);

            // Act
            var resultado = await _consultarOrdenDeInversion.GetOperacion(id);

            // Assert
            _mockServicioOrdenesDeInversion.Verify(s => s.GetOrdenDeInversion(id), Times.Once);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(id, resultado?.IdDeLaOrden);
        }

    }
}

