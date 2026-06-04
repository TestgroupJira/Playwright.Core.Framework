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
            //Allure: Para el trace después de cada test utilizando el método del fixture
            string tracePath = Path.Combine(
                "../../../Artifacts/AllureResults/Trace",
                $"Trace.zip");

            await Context.Tracing.StopAsync(new()
            {  
                Path = tracePath
            });
           
            Allure.Net.Commons.AllureApi.AddAttachment(
                "Trace",
                "application/zip",
                tracePath
            );
            //Allure: Fin trace

            // Cerrar el contexto después de cada test utilizando el método del fixture
            await Fixture.CerrarContext();
        }
    }
}