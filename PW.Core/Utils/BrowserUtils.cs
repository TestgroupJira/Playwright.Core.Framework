using Microsoft.Playwright;

namespace PW.Core.Utils;

public static class BrowserUtils
{
    public static async Task<IPage> CapturarNuevaPagina(IBrowserContext context, Func<Task> accion)
    {
        // Escuchar el evento de nueva página
        var nuevaPaginaListener = context.WaitForPageAsync(new() { Timeout = 30000 });

        // Ejecutar la acción que desencadena la apertura de una nueva página
        await accion();

        // Esperar y retornar nueva página
        var nuevaPagina = await nuevaPaginaListener;
        // Esperar a que la nueva página se cargue completamente
        await nuevaPagina.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        
        return nuevaPagina;
    }
        /*
        === Hacer click en Link que abre una nueva pestaña ===
        var paginaPatente = await BrowserUtils.CapturarNuevaPagina(Context, async () =>
        {
            === Ingresar una patente válida y hacer clic en el botón "Buscar patente" ===
            var botonDescargarSoapVigente = _homePage._botonDescargarSoapVigente;
            await botonDescargarSoapVigente.ClickAsync();
        });

        === Crear una instancia de la página de denuncio utilizando la nueva pestaña ===
        var _patentePage = new PatentePage(paginaPatente);
        */
}

