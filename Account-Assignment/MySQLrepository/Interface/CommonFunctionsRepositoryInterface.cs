using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface CommonFunctionsRepositoryInterface
{
    UserAccountBank save(UserAccountBank adminAccountBank);
    UserAccountBank editPersonalInformation(UserAccountBank adminAccountBank,String accountNumber);
    UserAccountBank changePassword(UserAccountBank adminAccountBank,String accountNumber,String password);
}