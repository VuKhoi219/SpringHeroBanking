using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

namespace Account_Assignment.Controller;

public class AdminHelper : AdminHelperInterface
{
    private AdminRepository _adminRepository = new AdminRepository();
    public void UserList()
    {
        List<AdminAccountBank> adminRepositories = _adminRepository.finAllUser();
        Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}", 
            "Id", "Password", "User name", "Phone", "Balance", "Transaction amount", "Status");
        foreach (var user in adminRepositories)
        {
            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15} ",
                user.Id, user.PassWord, user.UseName, user.Phone, user.Balance, user.transactionAmount,user.Status);
        }
        throw new NotImplementedException();
    }

    public void TransactionHistoryList()
    {
        throw new NotImplementedException();
    }

    public void SearchUsersByName()
    {
        throw new NotImplementedException();
    }

    public void SearchUsersByAccountNumber()
    {
        throw new NotImplementedException();
    }

    public void SearchUsersByPhoneNumber()
    {
        throw new NotImplementedException();
    }

    public void AddNewUser()
    {
        throw new NotImplementedException();
    }

    public void LockAndUnlockUserAccount()
    {
        throw new NotImplementedException();
    }

    public void SearchTransactionHistoryByAccountNumber()
    {
        throw new NotImplementedException();
    }

    public void ChangeAccountInformation()
    {
        throw new NotImplementedException();
    }

    public void ChangePasswordInformation()
    {
        throw new NotImplementedException();
    }
}