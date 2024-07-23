using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface CheckAccountRepositoryInterface
{
    public UserAccountBank checkAccount(string fieldName, string fieldValue, string password);
}