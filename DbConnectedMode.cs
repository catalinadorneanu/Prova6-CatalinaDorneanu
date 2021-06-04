using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova6_CatalinaDorneanu
{
    class DbConnectedMode

    {

        const string connectionString = @"Data Source=(localdb)\mssqllocaldb;" +
         "Initial Catalog = ProvaAgenti;" +
         "integrated Security=true;";

        public void Connection(out SqlConnection connection, out SqlCommand command)
        {

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
        }

        public void GetAll()
        {
            Connection(out SqlConnection connection, out SqlCommand command);

            command.CommandText = "SELECT  * from dbo.Agente;";
            SqlDataReader reader = command.ExecuteReader();
            int currentYear = (int)DateTime.Now.Year;
            
            while (reader.Read())
            {
                var nome = reader[1];
                var cognome = reader[2];
                var annoInizio = reader[5];

             

                Console.WriteLine($"Nome: {nome} - Cognome {cognome} - Anni di servizio: {currentYear - ((int)annoInizio)} \n");
            }
            connection.Close();
        }

        public void GetAllByArea()
        {
            Console.WriteLine("Inserisci l'area desiderata (M1, M2):");
            string scelta = Console.ReadLine();

            Connection(out SqlConnection connection, out SqlCommand command);
            int currentYear = (int)DateTime.Now.Year;
            if (scelta.ToUpper() == "M1")
            {
                command.CommandText = "SELECT * from dbo.Agente where AreaGeografica = @AreaGeografica;";
                command.Parameters.AddWithValue("@AreaGeografica", "M1");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    var nome = reader[1];
                    var cognome = reader[2];
                    var annoInizio = reader[5];


                    Console.WriteLine($"Nome: {nome} - Cognome {cognome} - Anni di servizio: {currentYear - ((int)annoInizio)} \n");
                }
            }
            else if (scelta.ToUpper() == "M2")
            {
                command.CommandText = "SELECT * from dbo.Agente where AreaGeografica = @AreaGeografica;";
                command.Parameters.AddWithValue("@AreaGeografica", "M2");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    var nome = reader[1];
                    var cognome = reader[2];
                    var annoInizio = reader[5];


                    Console.WriteLine($"Nome: {nome} - Cognome {cognome} - Anni di servizio: {currentYear - ((int)annoInizio)} \n");
                }
            }
            connection.Close();
        }

        public void GetAllBySeniority()
        {
            Connection(out SqlConnection connection, out SqlCommand command);

            Console.WriteLine("Inserisci anni di servizio:");
            int anniDaUtente = int.Parse(Console.ReadLine());

            command.CommandText = "SELECT  * from dbo.Agente";
           
            SqlDataReader reader = command.ExecuteReader();
            int currentYear = (int)DateTime.Now.Year;
         
            while (reader.Read())
            {
                var nome = reader[1];
                var cognome = reader[2];
                var annoInizio = reader[5];

               int anniDiServizio = currentYear - ((int)annoInizio);
                if (anniDaUtente <= anniDiServizio)
                {
                    Console.WriteLine($"Nome: {nome} - Cognome {cognome} - Anni di servizio: {anniDiServizio} \n");
                }
            }
            connection.Close();
        }
        public void AddAgent()
        {
            Connection(out SqlConnection connection, out SqlCommand command);

            Console.WriteLine("Inserisci nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome: ");
            string cognome = Console.ReadLine();
            string codiceFiscale;
            do
            {
                Console.WriteLine("Inserisci il Codice Fiscale da 16 caratteri:");
                codiceFiscale = Console.ReadLine();
            } while (codiceFiscale.Length != 16);


            if (CfExists(codiceFiscale) == true)
            {
                Console.WriteLine("Agente già presente\n");
                return;
            }
                else
                {

                    Console.WriteLine("Inserisci area geografica di appartenenza (M1 o M2): ");
                    string areaGeografica = Console.ReadLine();
                    Console.WriteLine("Inserisci anno di inizio attività: ");
                    int annoInizio = int.Parse(Console.ReadLine());

                    command.CommandText = "insert into dbo.Agente values (@Nome, @Cognome, @CodiceFiscale, @AreaGeografica, @AnnoInizio)";
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cognome", cognome);
                    command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                    command.Parameters.AddWithValue("@AreaGeografica", areaGeografica);
                    command.Parameters.AddWithValue("@AnnoInizio", annoInizio);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            
        }
    
        private bool CfExists(string codiceFiscale)
        {
            Connection(out SqlConnection connection, out SqlCommand command);
            command.CommandText = "SELECT CodiceFiscale FROM dbo.Agente WHERE CodiceFiscale = @CodiceFiscale;";
            command.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }
    }
}
