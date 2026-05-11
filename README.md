# EtiquetadoAuto - Gestió d'Inventari i OCR

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![MAUI](https://img.shields.io/badge/maui-blazor_hybrid-purple)
![Android](https://img.shields.io/badge/plataforma-android-3ddc84?logo=android

EtiquetadoAuto és una aplicació mòbil nadiua per a Android construïda amb **.NET MAUI i Blazor Hybrid**. El seu objectiu és automatitzar l'entrada de mercaderia llegint albarans de lliurament a través de la cambra, detectant automàticament els productes i les seves quantitats usant Intel·ligència Artificial (OCR), i generant etiquetes individuals llistes per a imprimir.

---

## Característiques Principals

* **Escaneig amb IA (OCR):** Utilitza Google ML Kit Vision per a llegir el text dels albarans directament des de la cambra del mòbil.
* **Extracció Intel·ligent:** Processa el text detectat per a separar automàticament el nom del producte i la quantitat rebuda.
* **Emmagatzematge Local Offline:** Guarda l'inventari de manera persistent i ràpida en el propi dispositiu usant **SQLite** (no requereix internet).
* **Generació d'Etiquetes PDF:** Crea un document PDF a l'instant amb **QuestPDF**, generant una etiqueta individual per cada unitat de producte, llista per a enviar a la impressora del magatzem.
* **Interfície Ràpida:** Construïda amb components web (HTML/CSS/Bootstrap) dins de Blazor per a una experiència fluida i adaptable.

---

## Tecnologies Usades

* **Framework:** `.NET 8` (MAUI Blazor Hybrid)
* **Llenguatge:** `C#`, `HTML`, `CSS`, `Razor`
* **base de dades:** `sqlite-net-pcl` (SQLite)
* **Visió Artificial:** `Xamarin.Google.MLKit.Vision`
* **Generació PDF:** `QuestPDF`

---

## Com executar el projecte

### Requisits previs
* Tenir instal·lat [Visual Studio 2022](https://visualstudio.microsoft.com/) (amb la càrrega de treball de .NET MAUI) o JetBrains Rider.
* SDK de .NET 8.
* Un emulador d'Android o un dispositiu físic connectat amb el mode desenvolupador activat.

### Instal·lació i Compilació
1. Clona aquest repositori:
 ```*bash
 git cloni [https://github.com/tu_usuario/etiquetadoauto.git](https://github.com/tu_usuario/etiquetadoauto.git)
