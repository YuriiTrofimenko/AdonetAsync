using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace AdonetAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            /* for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Fib(i));
            } */
            /* Console.WriteLine(Fib(46));
            Console.WriteLine(Fib(42));
            Console.WriteLine(Fib(20)); */
            
            /* new Thread(() => { Console.WriteLine(Fib(46)); }).Start();
            new Thread(() => { Console.WriteLine(Fib(42)); }).Start();
            new Thread(() => { Console.WriteLine(Fib(20)); }).Start();
            Console.WriteLine("The End"); */

            using (SqlConnection connection = new SqlConnection(@"Data Source=192.168.0.106,1433;Initial Catalog=BigDB;Integrated Security=False;user id=sa;password=Passw0rd%"))
            {
                connection.Open();
                Console.WriteLine(LongDbTask(connection));
            }
        }
        static long Fib (long n) {
            // 0 -> 1
            // 1 -> 1
            // 2 -> 2
            // 3 -> 3
            // 4 -> 5
            // 5 -> 8
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
        
        static int LongDbTask(SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            // command.CommandText = "SELECT * FROM [Product] WHERE [price] = 50.99 OR [quantity] = 70";
            command.CommandText = "sp_select_products";
            command.CommandType = CommandType.StoredProcedure;
            int totalCount = 0;
            for (int i = 0; i < 1; i++)
            {
                totalCount += (int)command.ExecuteScalar();
            }
            return totalCount;
        }
    }
}