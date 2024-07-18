using System.Data;
using System.Data.Common;
using Account_Assignment.Eniti;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository;

public class CommonFunctionRepository : CommonFunctionsRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";
    public UserAccountBank save(UserAccountBank userAccountBank)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand =
                new MySqlCommand(
                    "INSERT INTO  user_account(id,account_number,password,user_name,name,phone,balance,status)VALUES (@id,@accountNumber,@password,@userName,@name,@phone,@balance,@status);");
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@id", userAccountBank.Id);
            sqlCommand.Parameters.AddWithValue("@accountNumber", userAccountBank.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@password", userAccountBank.PassWord);
            sqlCommand.Parameters.AddWithValue("@userName", userAccountBank.UseName);
            sqlCommand.Parameters.AddWithValue("@name", userAccountBank.Name);
            sqlCommand.Parameters.AddWithValue("@phone", userAccountBank.Phone);
            sqlCommand.Parameters.AddWithValue("@balance", userAccountBank.Balance);
            sqlCommand.Parameters.AddWithValue("@status", userAccountBank.Status);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine("Lưu thành công");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return userAccountBank;
    } // hoàn thành

    public UserAccountBank editPersonalInformation(UserAccountBank  userAccountBank, string accountNumber)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand =
                new MySqlCommand(
                    "UPDATE user_account SET name = @name, phone = @phone WHERE account_number = @accountNumber ",
                    conn);
            sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
            sqlCommand.Parameters.AddWithValue("@name", userAccountBank.Name);
            sqlCommand.Parameters.AddWithValue("@phone", userAccountBank.Phone);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Lưu thành công");
            conn.Close();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
        }

        return userAccountBank;
            
    } // hoàn thành

    public UserAccountBank changePassword(UserAccountBank userAccountBank, string accountNumber, string password)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            
            string hashedPassword = null;

            using (MySqlCommand getPasswordSqlCommand = new MySqlCommand(
                    "SELECT password FROM user_account WHERE account_number = @accountNumber",conn))
            {
                getPasswordSqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
                using (DbDataReader reader = getPasswordSqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashedPassword = reader.GetString("password");
                    }
                }
            }


            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if (passwordMatch)
            {
                using (MySqlCommand sqlCommand =
                       new MySqlCommand(
                           "UPDATE user_account SET password = @newPassword WHERE account_number = @accountNumber",
                           conn))
                {
                    sqlCommand.Parameters.AddWithValue("@accountNumber", accountNumber);
                    sqlCommand.Parameters.AddWithValue("@passWord", password);
                    sqlCommand.Parameters.AddWithValue("@newPassword", userAccountBank.PassWord);
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Lưu thành công");
                }
            }
            else
            {
                Console.WriteLine("Lỗi mật khẩu");
            }
            conn.Close();
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
        }

        return userAccountBank;
    } // hoàn thành
}