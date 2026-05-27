using ComparacionPrecios.Services;

namespace ComparacionPrecios.Views;

public partial class VLogin : ContentPage
{
    private readonly DatabaseService _databaseService;
    public VLogin()
	{
		InitializeComponent();
        _databaseService = new DatabaseService();
    }

    private async void btnIngresar_Clicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text?.Trim().ToLower();
        string password = txtPassword.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, llena todos los campos.", "OK");
            return;
        }

        // Buscamos al usuario en la base de datos local SQLite
        var usuario = await _databaseService.ObtenerUsuarioPorEmailAsync(email);

        // Validamos si el usuario existe y si la contraseña coincide
        if (usuario != null && usuario.Password == password)
        {
            // Redirección exitosa cambiando la página raíz al AppShell
            if (Application.Current?.Windows.Count > 0)
            {
                Application.Current.Windows[0].Page = new NavigationPage(new VHome());
            }
        }
        else
        {
            // Si no existe o la clave está mal
            await DisplayAlert("Acceso Denegado", "Correo o contraseña incorrectos.", "OK");
        }
    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VRegistrarUsuario());
    }
}