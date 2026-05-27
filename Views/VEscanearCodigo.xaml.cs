using ComparacionPrecios.Services;

namespace ComparacionPrecios.Views;

public partial class VEscanearCodigo : ContentPage
{
    private DatabaseService _db;

    public VEscanearCodigo()
    {
        InitializeComponent();
        _db = new DatabaseService();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var producto = await _db.BuscarProductoPorCodigoBarrasAsync(codigoEntry.Text);

        if (producto != null)
        {
            resultadoLabel.Text =
                $"Producto: {producto.Nombre}\nPrecio: ${producto.Precio}";
        }
        else
        {
            resultadoLabel.Text = "Producto no encontrado";
        }
    }
}