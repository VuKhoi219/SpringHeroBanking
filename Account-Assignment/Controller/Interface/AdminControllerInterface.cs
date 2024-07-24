using Account_Assignment.Enity;

namespace Account_Assignment.Controller.Interface;

public interface IAdminControllerInterface
{
    void UserList();
    void TransactionHistoryList();
    void DisplayByPersonalInfo(UserAccountBank? userAccountBank);
    void SearchUsersByName();
    void SearchUsersByAccountNumber();
    void SearchUsersByPhoneNumber();
    void AddNewUser();
    void LockAndUnlockUserAccount();
    void SearchTransactionHistoryByAccountNumber();
    void ChangeAccountInformation();
    void ChangePasswordInformation();
}