using Account_Assignment.Enity;

namespace Account_Assignment.MySQLrepository.Interface;

public interface IAdminAccountBankRepository
{
    List<UserAccountBank> FindAllUser();
    UserAccountBank? FindByField(string fieldName, string fieldValue);
    UserAccountBank? FindByUserName(String userName);
    UserAccountBank? FindByAccountNumber(String accountNumber);
    UserAccountBank? FindByPhone(String phone);
    void LockOrUnlock(String accountNumber, int choice);
}