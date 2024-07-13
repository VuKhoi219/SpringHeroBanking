namespace Account_Assignment.Eniti;

public class AdminAccountBank : UserAccountBank
{
    public void show()
    {
        Console.WriteLine("id = "+base.Id);
        Console.WriteLine("password = " + base.PassWord);
        Console.WriteLine("Name" + base.UseName);
    }
}