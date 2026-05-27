using ComparacionPrecios.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ComparacionPrecios
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // 1. Envolvemos la vista de Login en una NavigationPage para permitir flujo secuencial
            var paginaNavegacion = new NavigationPage(new VHome());

            // 2. Retornamos una nueva ventana que contiene nuestra página de navegación
            return new Window(paginaNavegacion);
        }
    }
}