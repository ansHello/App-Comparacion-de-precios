using ComparacionPrecios.Models;
using ComparacionPrecios.Services;

namespace ComparacionPrecios.Views;

public partial class VBuscarProducto : ContentPage
{
    private DatabaseService _db;

    public VBuscarProducto()
    {
        InitializeComponent();
        _db = new DatabaseService();
    }

    private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            listaProductos.ItemsSource = null;
            return;
        }

        var lista = await _db.BuscarProductoPorNombreAsync(e.NewTextValue);
        listaProductos.ItemsSource = lista;
    }
}