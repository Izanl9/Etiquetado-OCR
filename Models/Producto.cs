using SQLite;

namespace EtiquetadoAuto.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Codigo { get; set; }
    }
}