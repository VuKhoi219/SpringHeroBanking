using System.Data;
using System.Data.Common;
using Account_Assignment.Eniti;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository;

public class TransactionRepository : TransactionRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    public List<UserAccountBank> transactionHistoryByAccountBank(string accountNumber)
    {
        List<UserAccountBank> userAccountBanks = new List<UserAccountBank>();
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand =
                new MySqlCommand("Select * from transaction_history where account_number = @accountNumber ORDER BY id;",
                    conn);
            sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                UserAccountBank userAccountBank = new AdminAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                Console.WriteLine(userAccountBank.Id);
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.TransactionHistory = reader.GetString("transaction_history");
                userAccountBank.TransactionHistoryContent = reader.GetString("transaction_history_content");
                userAccountBank.CreatedAt = reader.GetDateTime("created_at");
                userAccountBanks.Add(userAccountBank);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return userAccountBanks;
    }

    public List<UserAccountBank> transactionHistory()
    {
        List<UserAccountBank> userAccountBanks = new List<UserAccountBank>();

        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from transaction_history  ", conn);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                AdminAccountBank adminAccountBank = new AdminAccountBank();
                adminAccountBank.Id = reader.GetInt32("id");
                adminAccountBank.AccountNumber = reader.GetString("account_number");
                adminAccountBank.TransactionHistory = reader.GetString("transaction_history");
                adminAccountBank.TransactionHistoryContent = reader.GetString("transaction_history_content");
                adminAccountBank.CreatedAt = reader.GetDateTime("created_at");
                userAccountBanks.Add(adminAccountBank);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return userAccountBanks;
    }
}