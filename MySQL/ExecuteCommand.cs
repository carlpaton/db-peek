namespace DbPeek.MySQL
{
    class ExecuteCommand : MySQLContext
    {
        public ExecuteCommand(string connectionString) : base(connectionString)
        {

        }

        public new void Execute(string sql) 
        {
            base.Execute(sql);
        }
    }
}
