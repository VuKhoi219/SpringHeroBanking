using System.Data;
using System.Data.Common;
using Account_Assignment.Enity;
using Account_Assignment.MySQLrepository.Interface;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository.MySqlRepository;

public class CheckAccountRepository : ICheckAccountRepository
{
    string _myConnectionString = "server=127.0.0.1;uid=root;" +
                                 "pwd=;database=account-bank";

    public UserAccountBank? CheckAccount(string fieldName, string? fieldValue, string password)
    {
        UserAccountBank? accountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(_myConnectionString);
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
                    accountBank = new UserAccountBank();
                    accountBank.AccountNumber = reader.GetString("account_number");
                    accountBank.UseName = reader.GetString("user_name");
                    accountBank.PassWord = reader.GetString("password");
                    accountBank.Name = reader.GetString("name");
                    accountBank.Status = reader.GetInt32("status");
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

        return accountBank;
    }

    public UserAccountBank? CheckAccountBankByUserName(string? userName, string password)
    {
        return CheckAccount("user_name", userName, password);
    }

    public UserAccountBank? CheckAccountBankByAccountBank(string? accountBank, string password)
    {
        return CheckAccount("account_number", accountBank, password);
    }
}