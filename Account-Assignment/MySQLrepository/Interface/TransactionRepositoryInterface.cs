using Account_Assignment.Enity;

namespace Account_Assignment.MySQLrepository.Interface;

public interface ITransactionRepository
{
    List<UserAccountBank> TransactionHistoryByAccountBank(string? accountNumber);
    List<UserAccountBank> TransactionHistory();
}