using Microsoft.Data.SqlClient;

namespace ADO.NetMotSakila_GOhman
{
    internal class SakilaQuerys
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void FilmsByName(string firstName, string lastName)
        {
            var connection = new SqlConnection(connectionString);
            string query = $"SELECT film.title FROM film INNER JOIN film_actor ON film.film_id=film_actor.film_id INNER JOIN actor ON film_actor.actor_id=actor.actor_id WHERE first_name LIKE '{firstName}' AND last_name LIKE '{lastName}'";
            var command = new SqlCommand(query, connection);

            connection.Open();
            var rec = command.ExecuteReader();
            if (rec.HasRows)
            {
                Console.WriteLine($"Films starring {firstName} {lastName}");
                while (rec.Read())
                {
                    Console.WriteLine("-" + rec[0]);
                }
            }

            else
            {
                Console.WriteLine($"No films with actor {firstName} {lastName}");
            }
            connection.Close();
        }

        public void ListAllActors()
        {
            var connection = new SqlConnection(connectionString);
            string query = "SELECT first_name, last_name FROM actor";
            var command = new SqlCommand(query, connection);

            connection.Open();
            var rec = command.ExecuteReader();
            if (rec.HasRows)
            {
                while (rec.Read())
                {
                    Console.WriteLine(rec[0] + " " + rec[1]); //[0] = first name, [1] = last name
                }
            }
            connection.Close();
        }
    }
}
