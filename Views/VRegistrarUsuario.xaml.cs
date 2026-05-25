using ComparacionPrecios.Models;
using ComparacionPrecios.Services;

namespace ComparacionPrecios.Views;

public partial class VRegistrarUsuario : ContentPage
{
    private readonly DatabaseService _databaseService;
    public VRegistrarUsuario()
	{
		InitializeComponent();
        _databaseService = new DatabaseService();
    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        // Validamos campos vacíos
        if (string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
            string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
            string.IsNullOrEmpty(txtPassword.Text))
        {
            await DisplayAlert("Campos Incompletos", "Por favor, llena todo el formulario.", "OK");
            return;
        }

        string emailIngresado = txtEmail.Text.Trim().ToLower();

        // Verificar si el correo ya está registrado localmente para evitar duplicados
        var usuarioExistente = await _databaseService.ObtenerUsuarioPorEmailAsync(emailIngresado);
        if (usuarioExistente != null)
        {
            await DisplayAlert("Error", "Este correo electrónico ya está registrado.", "OK");
            return;
        }

        // Instanciamos el modelo con los datos de la interfaz
        var nuevoUsuario = new Usuario
        {
            Cedula = txtCedula.Text.Trim(),
            Nombre = txtNombre.Text.Trim(),
            Apellido = txtApellido.Text.Trim(),
            Email = emailIngresado,
            Password = txtPassword.Text, // Nota: Para producción, se recomienda encriptar (Hashing)
            Rol = "Cliente"
        };

        // Guardamos en la base de datos local de SQLite
        int resultado = await _databaseService.RegistrarUsuarioAsync(nuevoUsuario);

        if (resultado > 0)
        {
            await DisplayAlert("¡Éxito!", "Usuario creado correctamente en la base de datos local.", "OK");
            // Regresamos a la pantalla de Login
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo guardar el usuario localmente.", "OK");
        }
    }
}