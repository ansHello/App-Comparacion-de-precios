namespace ComparacionPrecios.Views;

public partial class VHome : ContentPage
{
    public VHome()
    {
        InitializeComponent();
    }

    private async void Buscar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VBuscarProducto());
    }

    private async void Escanear_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VEscanearCodigo());
    }
}