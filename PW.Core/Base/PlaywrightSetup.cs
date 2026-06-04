using Microsoft.Playwright;
using PW.Core.Config;

namespace PW.Core
{
    // Configurar el entorno de pruebas antes de cada test
    [SetUpFixture]
    public class PlaywrightSetup
    {
        // Declarar las variables para Playwright y Browser
        public static IPlaywright PlaywrightInstance { get; private set; } = null!;
        public static IBrowser Browser { get; private set; } = null!;

        // Configurar el entorno de pruebas antes de todos los tests
        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            // Allure: Limpiar el directorio de resultados de Allure antes de ejecutar las pruebas
            var rootPath = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, @"..\..\..\")
            );

            var allurePath = Path.Combine(
                rootPath,
                "Artifacts",
                "AllureResults"
            );

            if (Directory.Exists(allurePath))
            {
                Directory.Delete(allurePath, true);
            }

            Directory.CreateDirectory(allurePath);
            // Allure: Fin limpiar el directorio de resultados de Allure antes de ejecutar las pruebas

            // Iniciar playwright antes de todos los tests
            PlaywrightInstance = await Playwright.CreateAsync();

            // Leer el tipo de navegador desde la configuración
            var settings = ConfigReader.GetConfig;
            string browserName = settings.Browser.ToLower();

            // Definir opciones de lanzamiento para el navegador
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true, // Ejecutar en modo no headless para ver las pruebas en acción
                SlowMo = 0, // Agregar una pausa de 2 segundos entre cada acción para observar mejor las pruebas
                Args = new[] { "--start-maximized" } // Iniciar el navegador maximizado
            };

            // Iniciar el navegador antes de todos los tests
            Browser = browserName switch
            {
                "firefox" => await PlaywrightInstance.Firefox.LaunchAsync(launchOptions),
                "webkit" => await PlaywrightInstance.Webkit.LaunchAsync(launchOptions),
                "chromium" or _ => await PlaywrightInstance.Chromium.LaunchAsync(launchOptions)
            };

        }

        // Limpiar el entorno de pruebas después de todos los tests
        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            // Cerrar el navegador después de todos los tests
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
            // Cerrar Playwright después de todos los tests
            PlaywrightInstance.Dispose();
        }


    }
}
