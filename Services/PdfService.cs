using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using EtiquetadoAuto.Models;

namespace EtiquetadoAuto.Services
{
    public class PdfService
    {
        public PdfService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public string GenerarEtiquetas(List<Producto> productos)
        {
            // AGRUPACIÓN: Sumamos elementos con el mismo nombre antes de imprimir
            var productosAgrupados = productos
                .GroupBy(p => p.Nombre.Trim().ToLower())
                .Select(g => new Producto
                {
                    Nombre = g.First().Nombre, // Mantenemos el nombre original del primero
                    Codigo = g.First().Codigo,
                    Cantidad = g.Sum(p => p.Cantidad) // Sumamos todas las cantidades
                })
                .ToList();

            var rutaPdf = Path.Combine(FileSystem.CacheDirectory, "Etiquetas_Consolidadas.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    // . . . (resto de la configuración del PDF)

                    page.Content().PaddingVertical(0.5f, Unit.Centimetre).Table(table =>
                    {
                        // Definimos 2 columnas de igual ancho
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(9, Unit.Centimetre); // Columna 1
                            columns.ConstantColumn(9, Unit.Centimetre); // Columna 2
                        });

                        foreach (var prod in productosAgrupados)
                        {
                            for (int i = 0; i < prod.Cantidad; i++)
                            {
                                table.Cell().Padding(5).Element(Block); // Usamos un bloque para cada etiqueta

                                // Definición del bloque de la etiqueta
                                void Block(IContainer container)
                                {
                                    container
                                        .ShowEntire() // ¡EVITA QUE SE CORTE POR LA MITAD!
                                        .Border(0.5f)
                                        .BorderColor("#BDBDBD")
                                        .Padding(10)
                                        .Column(col =>
                                        {
                                            col.Item().Text(prod.Nombre.ToUpper()).Bold().FontSize(12);
                                            col.Item().Text($"CÓDIGO: {prod.Codigo}").FontSize(9).FontColor("#616161");
                                            col.Item().AlignRight().Text($"{i + 1} / {prod.Cantidad}").FontSize(8).Italic();
                                        });
                                }
                            }
                        }
                    });
                });
            })
            .GeneratePdf(rutaPdf);

            return rutaPdf;
        }
    }
}