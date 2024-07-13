using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface AdminAccountBankRepository
{
    List<AdminAccountBank> finAllUser();
    List<AdminAccountBank> transactionHistory();
    AdminAccountBank finByName(String name);
    AdminAccountBank finById(long id);
    AdminAccountBank finByPhone(String phone);
    AdminAccountBank lockOrUnlock(long id);
    AdminAccountBank transactionHistoryByid(long id);
    AdminAccountBank save(AdminAccountBank adminAccountBankRepository);
    AdminAccountBank update(AdminAccountBank adminAccountBankRepository);
    AdminAccountBank editPersonalInformation(AdminAccountBank adminAccountBankRepository);
    AdminAccountBank changePassword(AdminAccountBank adminAccountBankRepository);
}