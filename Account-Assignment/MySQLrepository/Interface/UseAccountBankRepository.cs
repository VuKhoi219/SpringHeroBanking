using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface UseAccountBankRepository
{
    UserAccountBank save(UserAccountBank userAccountBank);
    UserAccountBank editPersonalInformation(UserAccountBank userAccountBank);
    UserAccountBank changePassword(UserAccountBank userAccountBank);
    UserAccountBank depositMoney(UserAccountBank userAccountBank);
    UserAccountBank withdrawMoney(UserAccountBank userAccountBank);
    UserAccountBank transferMoney(UserAccountBank userAccountBank);
    List<UserAccountBank> transactionHistory();
}