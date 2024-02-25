namespace VentasUpdate
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string? arguments1;
            string? arguments2;

            if (args.Length > 0)
            {
                arguments1 = args[0];
                arguments2 = args[1];
            }
            else 
            {
                arguments1 = "";
                arguments2 = "";
            }
            


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(arguments1, arguments2));
        }
    }
}