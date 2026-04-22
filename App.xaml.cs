public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // IMPORTANTE: Aquí debe decir AppShell
        MainPage = new AppShell();
    }
}