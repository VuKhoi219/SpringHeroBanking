using System.Data;
using System.Data.Common;
using System.Diagnostics.SymbolStore;
using Account_Assignment.Eniti;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository;

public class CheckAccountRepository : CheckAccountRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    public UserAccountBank checkAccount(string fieldName, string fieldValue, string password)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            string query =
                $"Select account_number,user_name,password,name,status from user_account where {fieldName} = @fieldValue ";
            MySqlCommand sqlCommand = new MySqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@fieldValue", fieldValue);
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

    public UserAccountBank checkAccountBankByUserName(string userName, string password)
    {
        return checkAccount("user_name", userName, password);
    }

    public UserAccountBank checkAccountBankByAccountBank(string accountBank, string password)
    {
        return checkAccount("account_number", accountBank, password);
    }
}