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
            var rutaPdf = Path.Combine(FileSystem.CacheDirectory, "Etiquetas_Individuales.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(QuestPDF.Helpers.PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor("#FFFFFF");

                    page.Content().PaddingVertical(1, Unit.Centimetre).Grid(grid =>
                    {
                        grid.VerticalSpacing(15);
                        grid.HorizontalSpacing(15);
                        grid.Columns(2); 

                        foreach (var prod in productos)
                        {
                            // ¡ESTA ES LA MAGIA! Repetimos la etiqueta según la cantidad
                            for (int i = 0; i < prod.Cantidad; i++)
                            {
                                grid.Item().Border(1).BorderColor("#BDBDBD").Padding(10).Column(col =>
                                {
                                    col.Item().Text(prod.Nombre).Bold().FontSize(14);
                                    col.Item().Text($"CÓDIGO: {prod.Codigo}").FontSize(10).FontColor("#616161");
                                    // Ponemos "1 de 1" o simplemente quitamos la cantidad total para no confundir
                                    col.Item().AlignRight().Text($"Unidad {i + 1}/{prod.Cantidad}").FontSize(8).Italic();
                                });
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