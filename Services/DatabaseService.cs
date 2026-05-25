using ComparacionPrecios.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;
        public DatabaseService() 
        {
            // Definimos la ruta donde se guardará el archivo de la base de datos en el móvil
            string rutaBaseDatos = Path.Combine(FileSystem.AppDataDirectory, "calcular_precios_local.db3");

            // Inicializamos la conexión asíncrona
            _database = new SQLiteAsyncConnection(rutaBaseDatos);

            // Creamos la tabla 'Usuario' de forma asíncrona (si ya existe, no la vuelve a crear)
            _database.CreateTableAsync<Usuario>().Wait();
        }
        // Método para registrar/insertar un nuevo usuario
        public async Task<int> RegistrarUsuarioAsync(Usuario usuario)
        {
            return await _database.InsertAsync(usuario);
        }

        // Método para buscar un usuario por su Email (útil para el Login)
        public async Task<Usuario> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _database.Table<Usuario>()
                                  .Where(u => u.Email == email)
                                  .FirstOrDefaultAsync();
        }
    }
}

