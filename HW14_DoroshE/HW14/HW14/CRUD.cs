using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class CRUD
    {
        public void Select(string connectionString, string tableName)
        {
            using (SqlConnection con = new(connectionString))
            {
                try
                {
                    SqlCommand cm = new($"SELECT * FROM {tableName}", con);

                    con.Open();
                    cm.ExecuteNonQuery();
                    SqlDataReader dr = cm.ExecuteReader();

                    List<string> columns = GetDataReaderColumnNames(dr);

                    while (dr.Read())
                    {
                        foreach (string column in columns)
                        {
                            Console.Write($"{column}: {dr[$"{column}"]}\t");
                        }
                        Console.WriteLine();
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Got an error, " + ex.Message);
                }
            }
        }

        public void Insert(string connectionString, string query)
        {
            using (SqlConnection con = new(connectionString))
            {
                try
                {
                    SqlCommand cm = new(query, con);

                    con.Open();
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Successfully inserted data.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Got an error, " + ex.Message);
                }
            }
        }

        public void Update(string connectionString, string query)
        {
            using (SqlConnection con = new(connectionString))
            {
                try
                {
                    SqlCommand cm = new(query, con);
                    con.Open();
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Successfully updated row.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Got an error, " + ex.Message);
                }
            }
        }

        public void Delete(string connectionString, string table, string column, string value)
        {
            using (SqlConnection con = new(connectionString))
            {
                try
                {
                    string query = $"DELETE FROM {table} WHERE {column} = '{value}';";
                    SqlCommand cm = new(query, con);
                    con.Open();
                    cm.ExecuteNonQuery();

                    Console.WriteLine("Row successfully deleted.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Got an error, " + ex.Message);
                }
            }
        }
        List<string> GetDataReaderColumnNames(IDataReader rdr)
        {
            var columnNames = new List<string>();
            for (int i = 0; i < rdr.FieldCount; i++)
                columnNames.Add(rdr.GetName(i));
            return columnNames;
        }
    }
}
