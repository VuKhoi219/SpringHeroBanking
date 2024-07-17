using System.Data;
using System.Data.Common;
using Account_Assignment.Eniti;
using MySqlConnector;

namespace Account_Assignment.MySQLrepository;

public class UserAccountBankRepository : UseAccountBankRepositoryInterface
{
    string myConnectionString = "server=127.0.0.1;uid=root;" +
                                "pwd=;database=account-bank";

    public UserAccountBank depositMoney(UserAccountBank userAccountBank ,double transactionAmount )
    {
        MySqlTransaction transaction = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            transaction = conn.BeginTransaction();
            MySqlCommand sqlCommand =
                new MySqlCommand("UPDATE user_account SET balance = @transactionAmount + balance WHERE account_number = @accountNumber  ",conn);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@transactionAmount",transactionAmount);
            sqlCommand.Parameters.AddWithValue("@accountNumber", userAccountBank.AccountNumber);
            sqlCommand.Transaction = transaction;
            sqlCommand.ExecuteNonQuery();
            // làm việc với bẳng transaction histiry
            MySqlCommand sqlCommand1 =
                new MySqlCommand(
                    "INSERT INTO  transaction_history(id,account_number,transaction_history,transaction_history_content,created_at)VALUES (@id,@accountNumber,@transactionHistory,@transactionHistoryContent,@createdAt)"
                    );
            sqlCommand1.Connection = conn;
            // userAccountBank.CreatedAt = DateTime.Now; ngày thời gian mới nhất
            sqlCommand1.Parameters.AddWithValue("@id", userAccountBank.Id);
            sqlCommand1.Parameters.AddWithValue("@accountNumber",userAccountBank.AccountNumber);
            sqlCommand1.Parameters.AddWithValue("@transactionHistory", userAccountBank.TransactionHistory);
            sqlCommand1.Parameters.AddWithValue("@transactionHistoryContent",
                userAccountBank.TransactionHistoryContent);
            sqlCommand1.Parameters.AddWithValue("@createdAt",userAccountBank.CreatedAt);
            sqlCommand1.Transaction = transaction;
            sqlCommand1.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
            Console.WriteLine("Giao dịch thành công");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }
        return userAccountBank;
    } // đã hoàn thành

    public UserAccountBank withdrawMoney(UserAccountBank userAccountBank ,double transactionAmount)
    {
        MySqlTransaction transaction = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            transaction = conn.BeginTransaction();
            MySqlCommand sqlCommand =
                new MySqlCommand("UPDATE user_account SET balance =balance - @transactionAmount  WHERE account_number = @accountNumber and balance >= @transactionAmount ",conn);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@transactionAmount",transactionAmount);
            sqlCommand.Parameters.AddWithValue("@accountNumber", userAccountBank.AccountNumber);
            sqlCommand.Transaction = transaction;
            int check = sqlCommand.ExecuteNonQuery();
            if (check == 0)
            {
                Console.WriteLine("Số dư tài khoản không đủ để thực hiện giao dịch");
                transaction.Rollback();
                return userAccountBank;
            }
            // làm việc với bẳng transaction histiry
            MySqlCommand sqlCommand1 =
                new MySqlCommand(
                    "INSERT INTO  transaction_history(id,account_number,transaction_history,transaction_history_content,created_at)VALUES (@id,@accountNumber,@transactionHistory,@transactionHistoryContent,@createdAt)"
                    );
            sqlCommand1.Connection = conn;
            // userAccountBank.CreatedAt = DateTime.Now; ngày thời gian mới nhất
            sqlCommand1.Parameters.AddWithValue("@id", userAccountBank.Id);
            sqlCommand1.Parameters.AddWithValue("@accountNumber",userAccountBank.AccountNumber);
            sqlCommand1.Parameters.AddWithValue("@transactionHistory", userAccountBank.TransactionHistory);
            sqlCommand1.Parameters.AddWithValue("@transactionHistoryContent",
                userAccountBank.TransactionHistoryContent);
            sqlCommand1.Parameters.AddWithValue("@createdAt",userAccountBank.CreatedAt);
            sqlCommand1.Transaction = transaction;
            sqlCommand1.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
            Console.WriteLine("Giao dịch thành công");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }
        return userAccountBank;
        
    } // hoàn thành 

    public UserAccountBank transferMoney(UserAccountBank userAccountBank,double transactionAmount)
    {
        MySqlTransaction transaction = null;
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            transaction = conn.BeginTransaction();
            // thực hiện giao dịch
            MySqlCommand sqlCommand =
                new MySqlCommand("UPDATE user_account SET balance =balance - @transactionAmount  WHERE account_number = @accountNumber and balance >= @transactionAmount ",conn);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@transactionAmount",transactionAmount);
            sqlCommand.Parameters.AddWithValue("@accountNumber", userAccountBank.senderAccount);
            sqlCommand.Transaction = transaction;
            int check= sqlCommand.ExecuteNonQuery();
            if (check == 0) // check tài khoản có đủ tền không nếu check = 0 thì sẽ thoát
            {
                Console.WriteLine("Số dư tài khoản không đủ để thực hiện giao dịch");
                transaction.Rollback();
                return userAccountBank;
            }
            MySqlCommand sqlCommand1 =
                new MySqlCommand("UPDATE user_account SET balance =balance + @transactionAmount  WHERE account_number = @accountNumber and status =1 ",conn);
            sqlCommand1.Connection = conn;
            sqlCommand1.Parameters.AddWithValue("@transactionAmount",transactionAmount);
            sqlCommand1.Parameters.AddWithValue("@accountNumber", userAccountBank.recipientAccount);
            sqlCommand1.Transaction = transaction;
            int check2 = sqlCommand1.ExecuteNonQuery();
            if (check2 == 0) // check tài khoản có đủ tền không nếu check = 0 thì sẽ thoát
            {
                Console.WriteLine("Số tài khoản không tồn tài");
                transaction.Rollback();
                return userAccountBank;
            }
            // thực hiện thm lịch sử giao dịch
            MySqlCommand sqlCommand2 =
                new MySqlCommand(
                    "INSERT INTO  transaction_history(id,account_number,transaction_history,transaction_history_content,created_at)VALUES (@id,@accountNumber,@transactionHistory,@transactionHistoryContent,@createdAt)"
                    );
            sqlCommand2.Connection = conn;
            sqlCommand2.Parameters.AddWithValue("@id", userAccountBank.Id);
            sqlCommand2.Parameters.AddWithValue("@accountNumber",userAccountBank.senderAccount);
            sqlCommand2.Parameters.AddWithValue("@transactionHistory", userAccountBank.TransactionHistory);
            sqlCommand2.Parameters.AddWithValue("@transactionHistoryContent",
                userAccountBank.TransactionHistoryContent);
            sqlCommand2.Parameters.AddWithValue("@createdAt",userAccountBank.CreatedAt);
            sqlCommand2.Transaction = transaction;
            sqlCommand2.ExecuteNonQuery();
            MySqlCommand sqlCommand3 =
                new MySqlCommand(
                    "INSERT INTO  transaction_history(id,account_number,transaction_history,transaction_history_content,created_at)VALUES (@id,@accountNumber,@transactionHistory,@transactionHistoryContent,@createdAt)"
                );
            sqlCommand3.Connection = conn;
            sqlCommand3.Parameters.AddWithValue("@id", userAccountBank.Id);
            sqlCommand3.Parameters.AddWithValue("@accountNumber",userAccountBank.recipientAccount);
            sqlCommand3.Parameters.AddWithValue("@transactionHistory", userAccountBank.TransactionHistory2);
            sqlCommand3.Parameters.AddWithValue("@transactionHistoryContent",
                userAccountBank.TransactionHistoryContent);
            sqlCommand3.Parameters.AddWithValue("@createdAt",userAccountBank.CreatedAt);
            sqlCommand3.Transaction = transaction;
            sqlCommand3.ExecuteNonQuery();
            transaction.Commit();
            conn.Close();
            Console.WriteLine("Giao dịch thành công");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
            throw;
        }
        return userAccountBank;
    } // hooàn thành 

    public UserAccountBank CheckBalance(UserAccountBank userAccountBank)
    {
        try
        {
            MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();
            MySqlCommand sqlCommand = new MySqlCommand("Select balance from user_account where account_number = @accountNumber ;", conn);
            sqlCommand.Parameters.AddWithValue("@accountNumber", userAccountBank.AccountNumber);
            sqlCommand.Connection = conn;
            DbDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                userAccountBank = new UserAccountBank();
                userAccountBank.Balance = reader.GetDouble("balance");
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
        
    } // hoaàn thành 
    
}