using Account_Assignment.Eniti;

namespace Account_Assignment.MySQLrepository;

public interface LoginRepositoryInterface
{
    UserAccountBank checkAccount(String userName , string password);
}