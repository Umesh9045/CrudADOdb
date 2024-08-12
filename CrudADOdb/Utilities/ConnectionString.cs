namespace CrudADOdb.Utilities
{
    public static class ConnectionString
    {
        private static string cs = "server = WJLP-3581\\SQLEXPRESS; Database= CrudADOdb; Trusted_Connection=True";

        public static string dbcs { get => cs; }
    }
}
