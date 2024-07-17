using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface UseAccountBankRepositoryInterface
{

    UserAccountBank depositMoney(UserAccountBank userAccountBank , double transactionAmount);
    UserAccountBank withdrawMoney(UserAccountBank userAccountBank , double transactionAmount);
    UserAccountBank transferMoney(UserAccountBank userAccountBank ,double transactionAmount);

    UserAccountBank CheckBalance(UserAccountBank userAccountBank);
}