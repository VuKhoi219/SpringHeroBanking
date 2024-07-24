using Account_Assignment.Enity;

namespace Account_Assignment.MySQLrepository.Interface;

public interface ICommonFunctionsRepository
{
    UserAccountBank Save(UserAccountBank adminAccountBank);
    UserAccountBank EditPersonalInformation(UserAccountBank adminAccountBank,string? accountNumber);
    UserAccountBank ChangePassword(UserAccountBank adminAccountBank,string? accountNumber,String password);
}