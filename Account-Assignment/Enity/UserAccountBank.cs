namespace Account_Assignment.Eniti;

public class UserAccountBank 
{
    public int Id { get; set; }
    public String UseName { get; set; }
    public String PassWord { get; set; }
    public String Phone { get; set; }
    public double Balance { get; set; }
    public double transactionAmount { get; set; }
    public string TransactionHistory { get; set; }
    public int Status { get; set; }
}