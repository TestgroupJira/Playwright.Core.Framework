# Playwright C# Core Framework

Este es un **Framework de Automatización Base** construido con .NET 10.0, Playwright y NUnit. Está diseñado siguiendo el patrón **Page Object Model (POM)** y una arquitectura de **Capa de Infraestructura** para facilitar la creación de pruebas robustas, escalables y mantenibles.

## Tecnologías Incluidas
* **Motor:** [Playwright for .NET](https://playwright.dev/dotnet/)
* **Test Runner:** [NUnit 3](https://nunit.org/)
* **Reportabilidad:** [Allure Report](https://allurereport.org/)
* **Configuración:** JSON dinámico.
* **Evidencia:** Captura automática de Traces y Screenshots ante fallos.

---

## Estructura del Proyecto Core
* **`Base/`**: Contiene el `PlaywrightSetup` (ciclo de vida global) y el `BaseTest`.
* **`Config/`**: Manejo de archivos de configuración.
* **`Fixtures/`**: Gestión de contextos de navegador, páginas y observabilidad.
* **`Utils/`**: Herramientas de apoyo como lectores de CSV, JSON y Helpers de navegador.
* **`Pages/`**: Repositorio de Page Objects (Selectores y Acciones).

---

## Instalación y Configuración

### 1. Clonar el repositorio bash

git clone [https://github.com/tu-usuario/PW.Core.git](https://github.com/tu-usuario/PW.Core.git)
cd PW.Core

### 2. Instalar Dependencias

dotnet restore

### 3. Instalar navegadores de PW

powershell bin/Debug/net10.0/playwright.ps1 install

### 4. Ejecucion de pruebas

dotnet test