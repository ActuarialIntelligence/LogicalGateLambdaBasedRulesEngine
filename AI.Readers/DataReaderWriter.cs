using AI.Readers.Interfaces;
using System.Data.SqlClient;

namespace AI.Readers

{

    public class DataReaderWriter : IDataReaderWriter

    {

        public static string _command { get; private set; }

        public DataReaderWriter(string command)

        {

            _command = command;

        }



        public static string _connectionString { get; private set; }

        public static void CsvuDataReaderWriterGetWrite(string command, string connectionString)

        {

            var strW = new StreamWriter("C:\\...\\TestData\\IpTest.csv");

            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            var cmd = new SqlCommand(command);

            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();

            while (reader.Read())

            {

                strW.WriteLine(reader[0].ToString() + "," + reader[1].ToString() + "," + reader[2].ToString() + "," + reader[3].ToString() + "," + reader[4].ToString() + "," + reader[5].ToString() + "," + reader[6].ToString() + "," + reader[7].ToString() + "," + reader[8].ToString() + "," + reader[9].ToString() + "," + reader[10].ToString() + "," + reader[11].ToString() + "," + reader[12].ToString());

            }

            strW.Close();

        }

    }

}