using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using EtiquetadoAuto.Models;

namespace EtiquetadoAuto.Services
{
    public class PdfService
    {
        public PdfService()
        {
            // QuestPDF requiere aceptar su licencia gratuita para proyectos pequeños/educativos
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public string GenerarEtiquetas(List<Producto> productos)
        {
            var rutaPdf = Path.Combine(FileSystem.CacheDirectory, "Etiquetas_Inventario.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    
                    // ¡AQUÍ ESTÁ EL ARREGLO! Especificamos de dónde viene el Color
                    page.PageColor(QuestPDF.Helpers.Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("Etiquetas de Inventario")
                        .SemiBold().FontSize(20).FontColor(QuestPDF.Helpers.Colors.BlueDarken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Grid(grid =>
                    {
                        grid.VerticalSpacing(15);
                        grid.HorizontalSpacing(15);
                        grid.Columns(2); // Ponemos 2 etiquetas por fila

                        foreach (var prod in productos)
                        {
                            grid.Item().Border(1).BorderColor(QuestPDF.Helpers.Colors.GreyLighten1).Padding(15).Column(col =>
                            {
                                col.Item().Text(prod.Nombre).Bold().FontSize(16);
                                col.Item().Text($"CÓDIGO: {prod.Codigo}").FontColor(QuestPDF.Helpers.Colors.GreyDarken2);
                                col.Item().PaddingTop(5).Text($"CANTIDAD: {prod.Cantidad}").FontSize(14).SemiBold();
                            });
                        }
                    });
                });
            })
            .GeneratePdf(rutaPdf);

            return rutaPdf;
        }
    }
}