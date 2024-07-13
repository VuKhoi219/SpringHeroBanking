using System.Data;
using System.Data.Common;
using Account_Assignment.Eniti;
using MySqlConnector;


namespace Account_Assignment.MySQLrepository;

public class AdminRepository : AdminAccountBankRepository
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    public List<AdminAccountBank> finAllUser()
    {
        List<AdminAccountBank> adminAccountBanks = new List<AdminAccountBank>();

        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where status != -1 ",conn);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                AdminAccountBank adminAccountBank = new AdminAccountBank();
                adminAccountBank.Id = reader.GetInt32("id");
                adminAccountBank.PassWord = reader.GetString("password");
                adminAccountBank.UseName = reader.GetString("name");
                adminAccountBank.Phone = reader.GetString("phone");
                adminAccountBank.transactionAmount = reader.GetDouble("transaction_amount");
                adminAccountBank.Status = reader.GetInt32("status");
                adminAccountBanks.Add(adminAccountBank);
            }
            conn.Close();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }

        return adminAccountBanks;
    }

    public List<AdminAccountBank> transactionHistory()
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank finByName(string name)
    {
        List<AdminAccountBank> adminAccountBanks = new List<AdminAccountBank>();
        AdminAccountBank adminAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where name = @name ;",conn);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                adminAccountBank = new AdminAccountBank();
                adminAccountBank.Id = reader.GetInt32("id");
                adminAccountBank.PassWord = reader.GetString("password");
                adminAccountBank.UseName = reader.GetString("name");
                adminAccountBank.Phone = reader.GetString("phone");
                adminAccountBank.transactionAmount = reader.GetDouble("transaction_amount");
                adminAccountBank.Status = reader.GetInt32("status");
                adminAccountBanks.Add(adminAccountBank);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return adminAccountBank;
    }

    public AdminAccountBank finById(long id)
    {
        List<AdminAccountBank> adminAccountBanks = new List<AdminAccountBank>();
        AdminAccountBank adminAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where id = @id ",conn);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();

            adminAccountBank = new AdminAccountBank();
            
            adminAccountBank.Id = reader.GetInt32("id");
            adminAccountBank.PassWord = reader.GetString("password");
            adminAccountBank.Phone = reader.GetString("phone");
            adminAccountBank.transactionAmount = reader.GetDouble("transaction_amount");
            adminAccountBank.Status = reader.GetInt32("status");
            sqlCommand.Parameters.AddWithValue("@id", id);
            adminAccountBanks.Add(adminAccountBank);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return adminAccountBank;
    }

    public AdminAccountBank finByPhone(string phone)
    {
        List<AdminAccountBank> adminAccountBanks = new List<AdminAccountBank>();
        AdminAccountBank adminAccountBank = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select * from user_account where phone = @phone ",conn);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();

            adminAccountBank = new AdminAccountBank();
            adminAccountBank.Id = reader.GetInt32("id");
            adminAccountBank.PassWord = reader.GetString("password");
            adminAccountBank.Phone = reader.GetString("phone");
            adminAccountBank.transactionAmount = reader.GetDouble("transaction_amount");
            adminAccountBank.Status = reader.GetInt32("status");
            sqlCommand.Parameters.AddWithValue("@phone", phone);
            adminAccountBanks.Add(adminAccountBank);
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return adminAccountBank;    }

    public AdminAccountBank lockOrUnlock(long id)
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank transactionHistoryByid(long id)
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank save(AdminAccountBank adminAccountBankRepository)
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank update(AdminAccountBank adminAccountBankRepository)
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank editPersonalInformation(AdminAccountBank adminAccountBankRepository)
    {
        throw new NotImplementedException();
    }

    public AdminAccountBank changePassword(AdminAccountBank adminAccountBankRepository)
    {
        throw new NotImplementedException();
    }
}