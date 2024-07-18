using System.Data;
using System.Data.Common;
using System.Net.Sockets;
using Account_Assignment.Eniti;
using MySqlConnector;


namespace Account_Assignment.MySQLrepository;

public class AdminAccountBankRepository : AdminAccountBankRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    // hiển thị danh sách
    public List<UserAccountBank> finAllUser()
    {
        List<UserAccountBank> userAccountBanks = new List<UserAccountBank>();

        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where status != -1 ", conn);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                UserAccountBank userAccountBank = new AdminAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.UseName = reader.GetString("user_name");
                userAccountBank.PassWord = reader.GetString("password");
                userAccountBank.Name = reader.GetString("name");
                userAccountBank.Phone = reader.GetString("phone");
                userAccountBank.Status = reader.GetInt32("status");
                userAccountBanks.Add(userAccountBank);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return userAccountBanks;
    }

    // hiển thị theo thông tín cá nhân
    public UserAccountBank finByField(string fieldName, string fieldValue)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            string query =
                $"Select id , account_number,user_name,name,phone,balance,status from user_account where {fieldName} = @fieldValue;";
            MySqlCommand sqlCommand = new MySqlCommand(query, conn);
            sqlCommand.Parameters.AddWithValue("@fieldValue", fieldValue);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                userAccountBank = new UserAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.UseName = reader.GetString("user_name");
                userAccountBank.Name = reader.GetString("name");
                userAccountBank.Phone = reader.GetString("phone");
                userAccountBank.Balance = reader.GetDouble("balance");
                userAccountBank.Status = reader.GetInt32("status");
                conn.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return userAccountBank;
    }

    public UserAccountBank finByUserName(string userName)
    {
        return finByField("user_name", userName);
    }

    public UserAccountBank finByAccountNumber(string accountNumber)
    {
        return finByField("account_number", accountNumber);
    }

    public UserAccountBank finByPhone(string phone)
    {
        return finByField("phone", phone);
    }

    // mở , khóa tài khoản
    public void lockOrUnlock(String accountNumber, int choice)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            // log acc 
            if (choice == 1)
            {
                MySqlCommand sqlCommand =
                    new MySqlCommand("UPDATE user_account SET status = 0 WHERE account_number = @accountNumber;", conn);
                sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Khóa tài khoản thành công ");
            }
            else if (choice == 2)
            {
                MySqlCommand sqlCommand =
                    new MySqlCommand("UPDATE user_account SET status = 1 WHERE account_number = @accountNumber;", conn);
                sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Mở tài khoản người dùng thành công ");
            }

            conn.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}