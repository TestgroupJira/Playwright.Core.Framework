using Microsoft.Playwright;

namespace PW.Core.Utils;

public class Utilidades
{
    // Método para tomar screenshots y guardarlos en la carpeta de artefactos correspondiente a la ejecución actual
    public static async Task _screenshot(IPage _ipage, string nombreArchivo, string testEjecutado, string FH2)
    {
        // Construir la ruta completa para guardar el screenshot utilizando el nombre de ejecución y el nombre del archivo
        var rootPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, @"..\..\..\")
        );
        // Ruta para la carpeta de screenshots dentro de los artefactos de la ejecución actual
        var screenshotsPath = Path.Combine(rootPath, "Artifacts", testEjecutado, "Screenshots");
        
        // Tomar la captura de pantalla y guardarla en la ruta especificada con un nombre único
        await _ipage.ScreenshotAsync(new PageScreenshotOptions { 
            Path = screenshotsPath + "\\" + FH2 + "_" + nombreArchivo
        });
    }

    /*
    Ejemplo de uso del método _screenshot dentro de un test:
    
    [Test]
    public async Task MiTest()
    {
        === Generar un nombre de ejecución único para esta prueba utilizando la fecha y hora actual ===
        var testEjecutado = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_MiTest";

        === Crear una carpeta para almacenar los artefactos de esta ejecución utilizando el nombre generado ===
        await Utilidades._crear_Artifacts(Page, testEjecutado);

        === Incrementar el contador de ejecución para diferenciar los screenshots dentro de la misma ejecución ===
        secEjecucion++;
        
        === Generar un nombre único para los screenshots utilizando el contador de ejecución y la fecha y hora actual ===
        var FH2 = secEjecucion.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

        === Tomar un screenshot en un punto específico del test utilizando el método _screenshot ===
        await Utilidades._screenshot(Page, "Paso1.png", testEjecutado, FH2);
    }
     */

    // Método para crear la estructura de carpetas para almacenar los artefactos de cada ejecución
    public static async Task _crear_Artifacts(IPage _ipage, string testEjecutado)
    {
        // Construir la ruta raíz del proyecto para luego construir las rutas de los artefactos
        var rootPath = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, @"..\..\..\")
        );

        // Crear la carpeta para almacenar los screenshots de esta ejecución utilizando el nombre generado
        var screenshotsPath1 = Path.Combine(rootPath, "Artifacts", testEjecutado, "Screenshots");
        if (!Directory.Exists(screenshotsPath1))
        {
            Directory.CreateDirectory(screenshotsPath1);
        }

        // Crear la carpeta para almacenar los resultados de Allure de esta ejecución utilizando el nombre generado
        var allureResultsPath2 = Path.Combine(rootPath, "Artifacts", testEjecutado, "Allure-results");
        if (!Directory.Exists(allureResultsPath2))
        {
            Directory.CreateDirectory(allureResultsPath2);
        }
    }
}
