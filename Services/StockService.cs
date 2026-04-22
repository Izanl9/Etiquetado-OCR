using Firebase.Database;
using Firebase.Database.Query;
using EtiquetadoAuto.Models;

namespace EtiquetadoAuto.Services;

public class StockService
{
    private readonly FirebaseClient _fb = new FirebaseClient("https://TU-PROYECTO.firebaseio.com/");

    public async Task ProcesarEscaneo(string code)
    {
        bool esSalida = code.StartsWith("LOG-");
        string idLimpio = esSalida ? code.Replace("LOG-", "") : code;
        int cambio = esSalida ? -1 : 1;

        var p = (await _fb.Child("Stock").OnceAsListAsync<Product>())
                .FirstOrDefault(x => x.Object.Id == idLimpio);

        if (p != null) {
            await _fb.Child("Stock").Child(p.Key).PatchAsync(new { Quantity = p.Object.Quantity + cambio });
        } else if (!esSalida) {
            await _fb.Child("Stock").PostAsync(new Product { Id = idLimpio, Quantity = 1, LastUpdate = DateTime.Now });
            // Si es entrada nueva, mandamos a imprimir
            await new PrinterService().Imprimir("Entrada", idLimpio);
        }
    }

    public async Task<List<Product>> GetStock() => 
        (await _fb.Child("Stock").OnceAsListAsync<Product>()).Select(x => x.Object).ToList();
}