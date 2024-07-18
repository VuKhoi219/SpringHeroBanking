using System.Data;
using System.Data.Common;
using System.Diagnostics.SymbolStore;
using Account_Assignment.Eniti;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository;

public class LoginRepository : LoginRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    public UserAccountBank checkAccount(String userName, string password)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand =
                new MySqlCommand(
                    "Select account_number,user_name,password,name,status from user_account where user_name = @userName ",
                    conn);
            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                string hashedPassword = reader.GetString("password");
                bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                if (passwordMatch)
                {
                    userAccountBank = new UserAccountBank();
                    userAccountBank.AccountNumber = reader.GetString("account_number");
                    userAccountBank.UseName = reader.GetString("user_name");
                    userAccountBank.PassWord = reader.GetString("password");
                    userAccountBank.Name = reader.GetString("name");
                    userAccountBank.Status = reader.GetInt32("status");
                }
                else
                {
                    Console.WriteLine("sai mật khẩu");
                }
                // sqlCommand.ExecuteNonQuery();
            }

            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return userAccountBank;
    }
}