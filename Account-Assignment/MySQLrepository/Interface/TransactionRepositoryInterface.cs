using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface TransactionRepositoryInterface
{
    List<UserAccountBank> transactionHistoryByAccountBank(String accountNumber);
    List<UserAccountBank> transactionHistory();
        
}