using Account_Assignment.Enity;

namespace Account_Assignment.MySQLrepository.Interface;

public interface ICheckAccountRepository
{
    public UserAccountBank? CheckAccount(string fieldName, string? fieldValue, string password);
    public UserAccountBank? CheckAccountBankByUserName(string? userName, string password);
    public UserAccountBank? CheckAccountBankByAccountBank(string? accountBank, string password);
}