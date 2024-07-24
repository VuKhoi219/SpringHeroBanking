using Account_Assignment.Enity;

namespace Account_Assignment.MySQLrepository;

public interface IUserAccountBankRepository
{
    UserAccountBank DepositMoney(UserAccountBank userAccountBank, double transactionAmount);
    UserAccountBank WithdrawMoney(UserAccountBank userAccountBank, double transactionAmount);
    UserAccountBank TransferMoney(UserAccountBank userAccountBank, double transactionAmount);

    UserAccountBank CheckBalance(UserAccountBank userAccountBank);
}