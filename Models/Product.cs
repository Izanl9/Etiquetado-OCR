namespace EtiquetadoAuto.Models;

public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = "Producto Nuevo";
    public int Quantity { get; set; }
    public DateTime LastUpdate { get; set; }
}