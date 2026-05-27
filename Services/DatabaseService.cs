using ComparacionPrecios.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ComparacionPrecios.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            // Ruta de la base de datos local
            string rutaBaseDatos = Path.Combine(FileSystem.AppDataDirectory, "calcular_precios_local.db3");

            // Conexión SQLite
            _database = new SQLiteAsyncConnection(rutaBaseDatos);

            // TABLAS
            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Producto>().Wait();
        }


        public async Task<int> RegistrarUsuarioAsync(Usuario usuario)
        {
            return await _database.InsertAsync(usuario);
        }

        public async Task<Usuario> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _database.Table<Usuario>()
                                  .Where(u => u.Email == email)
                                  .FirstOrDefaultAsync();
        }

        public async Task<List<Producto>> BuscarProductoPorNombreAsync(string nombre)
        {
            return await _database.Table<Producto>()
                                  .Where(p => p.Nombre.ToLower().Contains(nombre.ToLower()))
                                  .ToListAsync();
        }

        public async Task<Producto> BuscarProductoPorCodigoBarrasAsync(string codigo)
        {
            return await _database.Table<Producto>()
                                  .Where(p => p.CodigoBarras == codigo)
                                  .FirstOrDefaultAsync();
        }
    }
}