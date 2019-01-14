<Query Kind="Program" />

void Main()
{
    var conn = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SFA.Apprenticeships.Data.AvmsPlus;Data Source=(localdb)\ProjectsV13;");
    conn.Open();
    using (SqlCommand command = new SqlCommand(
                "select top 10 * from Vacancy",
                conn))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine($"{reader.GetValue(i)}");
                }
                Console.WriteLine();
            }
        }
    }
}


