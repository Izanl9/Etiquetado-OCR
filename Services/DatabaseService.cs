using SQLite;
using EtiquetadoAuto.Models;

namespace EtiquetadoAuto.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _conexion;

        public DatabaseService()
        {
            // Busca la ruta segura del móvil para guardar el archivo .db3
            string rutaDb = Path.Combine(FileSystem.AppDataDirectory, "InventarioApp.db3");
            _conexion = new SQLiteAsyncConnection(rutaDb);
            
            // Crea la tabla si no existe
            _conexion.CreateTableAsync<Producto>().Wait();
        }

        // Método para guardar un producto
        public async Task GuardarProducto(Producto producto)
        {
            await _conexion.InsertAsync(producto);
        }

        // Método para ver todos los productos (lo usaremos luego en la pantalla de inventario)
        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _conexion.Table<Producto>().ToListAsync();
        }
    }
}