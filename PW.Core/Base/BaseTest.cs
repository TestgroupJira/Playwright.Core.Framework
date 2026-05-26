using Microsoft.Playwright;
using PW.Core;
using PW.Core.Fixtures;

namespace PW.Core.Base
{
    public class BaseTest
    {
        // Declarar las variables para PlaywrightFixture y Page
        protected PlaywrightFixture Fixture;
        protected IBrowserContext Context => Fixture.Context;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            // Inicializar el PlaywrightFixture
            Fixture = new PlaywrightFixture();
            // Crear una nueva página utilizando el método del fixture
            Page = await Fixture.CrearPage(PlaywrightSetup.Browser);
        }

        [TearDown]
        public async Task Teardown()
        {
            // Cerrar el contexto después de cada test utilizando el método del fixture
            await Fixture.CerrarContext();
        }
    }
}