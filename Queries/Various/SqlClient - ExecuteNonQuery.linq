<Query Kind="Program">
  <NuGetReference>System.Data.SqlClient</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    //ExecuteNonQuery();
    
    ExecuteQuery();
}


private void ExecuteNonQuery()
{
    var connectionString = @"Data Source=he0ifp6r12.database.windows.net;Initial Catalog=AvmsPlus-Pre;Persist Security Info=True;User ID=faa_dev1;Password=24nl0EMOwsZA3j2ZUZEhq8eCscLNXIH4qGk4";
    using (var connection = new SqlConnection(connectionString))
    {
        var cmd = connection.CreateCommand();
        cmd.CommandText = "UPDATE dbo.Application SET Notes = @notes WHERE ApplicationGuid = @applicationId";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("applicationId", "87998F22-7FBA-4DE7-8C54-9A839CB44D56"));
        cmd.Parameters.Add(new SqlParameter("notes", "notes notes"));
        if (connection.State != ConnectionState.Open) connection.Open();
        var response = cmd.ExecuteNonQuery();
    }
}

private void ExecuteQuery()
{
    var connectionString = @"Data Source=amxjinl30w.database.windows.net;Initial Catalog=AvmsPlus-Prod;Persist Security Info=True;User ID=valtech_dshah;Password=4DMoWr8J7s6F0BP8UvZ6f5sreoksdQ25C7Bg";
    using (var connection = new SqlConnection(connectionString))
    {
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT ApplicationGuid FROM dbo.Application";
        cmd.CommandType = CommandType.Text;
        if (connection.State != ConnectionState.Open) connection.Open();
        var list = new List<Guid>();
        using (var reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                list.Add(Guid.Parse(reader[0].ToString()));
            }
        }
        list.Count().Log();        
    }
}