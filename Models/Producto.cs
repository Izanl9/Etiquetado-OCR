namespace EtiquetadoAuto.Models
{
    public class Producto
    {
        public string Nombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        
        // Añadimos estos para que Inventory.razor no de error
        public string Codigo { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}