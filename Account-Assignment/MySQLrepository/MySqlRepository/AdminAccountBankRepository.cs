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
    } // Chuyển sang User thành công
    
    public UserAccountBank finByName(string name)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where name = @name ;", conn);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                userAccountBank = new UserAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.UseName = reader.GetString("user_name");
                userAccountBank.PassWord = reader.GetString("password");
                userAccountBank.Name = reader.GetString("name");
                userAccountBank.Phone = reader.GetString("phone");
                userAccountBank.Balance = reader.GetDouble("balance");
                userAccountBank.Status = reader.GetInt32("status");
                // sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return userAccountBank;
    } // Chuyển sang User thành công

    public UserAccountBank finByAccountNumber(String accountNumber)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where account_number = @accountNumber ;", conn);
            sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                userAccountBank = new UserAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.UseName = reader.GetString("user_name");
                userAccountBank.PassWord = reader.GetString("password");
                userAccountBank.Name = reader.GetString("name");
                userAccountBank.Phone = reader.GetString("phone");
                userAccountBank.Balance = reader.GetDouble("balance");
                userAccountBank.Status = reader.GetInt32("status");
                // sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return userAccountBank;
    } // Chuyển sang User thành công

    public UserAccountBank finByPhone(string phone)
    {
        UserAccountBank userAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where phone = @phone ;", conn);
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                userAccountBank = new UserAccountBank();
                userAccountBank.Id = reader.GetInt32("id");
                userAccountBank.AccountNumber = reader.GetString("account_number");
                userAccountBank.UseName = reader.GetString("user_name");
                userAccountBank.PassWord = reader.GetString("password");
                userAccountBank.Name = reader.GetString("name");
                userAccountBank.Phone = reader.GetString("phone");
                userAccountBank.Balance = reader.GetDouble("balance");
                userAccountBank.Status = reader.GetInt32("status");
                // sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return userAccountBank;
    } // Chuyển sang User thành công

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