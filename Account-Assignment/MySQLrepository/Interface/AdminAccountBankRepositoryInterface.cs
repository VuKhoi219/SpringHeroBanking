using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface AdminAccountBankRepositoryInterface
{
    List<UserAccountBank> finAllUser();
    UserAccountBank finByName(String name);
    UserAccountBank finByAccountNumber(String accountNumber);
    UserAccountBank finByPhone(String phone);
    void lockOrUnlock(String accountNumber, int choice);

}