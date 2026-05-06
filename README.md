# EtiquetadoAuto - Gestión de Inventario y OCR

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![MAUI](https://img.shields.io/badge/MAUI-Blazor_Hybrid-purple)
![Android](https://img.shields.io/badge/Plataforma-Android-3DDC84?logo=android)

EtiquetadoAuto es una aplicación móvil nativa para Android construida con **.NET MAUI y Blazor Hybrid**. Su objetivo es automatizar la entrada de mercancía leyendo albaranes de entrega a través de la cámara, detectando automáticamente los productos y sus cantidades usando Inteligencia Artificial (OCR), y generando etiquetas individuales listas para imprimir.

---

## Características Principales

* ** Escaneo con IA (OCR):** Utiliza Google ML Kit Vision para leer el texto de los albaranes directamente desde la cámara del móvil.
* ** Extracción Inteligente:** Procesa el texto detectado para separar automáticamente el nombre del producto y la cantidad recibida.
* ** Almacenamiento Local Offline:** Guarda el inventario de forma persistente y rápida en el propio dispositivo usando **SQLite** (no requiere internet).
* ** Generación de Etiquetas PDF:** Crea un documento PDF al instante con **QuestPDF**, generando una etiqueta individual por cada unidad de producto, lista para enviar a la impresora del almacén.
* ** Interfaz Rápida:** Construida con componentes web (HTML/CSS/Bootstrap) dentro de Blazor para una experiencia fluida y adaptable.

---

## Tecnologías Usadas

* **Framework:** .NET 8 (MAUI Blazor Hybrid)
* **Lenguaje:** C#, HTML, CSS, Razor
* **Base de Datos:** `sqlite-net-pcl` (SQLite)
* **Visión Artificial:** `Xamarin.Google.MLKit.Vision`
* **Generación PDF:** `QuestPDF`

---

##  Cómo ejecutar el proyecto

### Requisitos previos
* Tener instalado [Visual Studio 2022](https://visualstudio.microsoft.com/) (con la carga de trabajo de .NET MAUI) o JetBrains Rider.
* SDK de .NET 8.
* Un emulador de Android o un dispositivo físico conectado con el modo desarrollador activado.

### Instalación y Compilación
1. Clona este repositorio:
   ```bash
   git clone [https://github.com/TU_USUARIO/EtiquetadoAuto.git](https://github.com/TU_USUARIO/EtiquetadoAuto.git)
