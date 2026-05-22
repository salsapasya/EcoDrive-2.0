using EcoDrive_vol2.Views;

namespace EcoDrive_vol2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new FormLogin());
        }
    }
}