using Microsoft.Maui.Controls;

namespace EtiquetadoAuto;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();


        MainPage = new AppShell();
    }
}