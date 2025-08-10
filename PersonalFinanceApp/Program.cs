namespace PersonalFinanceApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // TODO
            // Initialize IdGenerator with the highest ID in the database
            Transaction.IdGenerator = 1;
            Application.Run(new Form1());
        }
    }
}