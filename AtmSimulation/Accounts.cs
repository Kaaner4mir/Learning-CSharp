interface IAccount
{
    int Id { get; set; }
    string Owner { get; set; }
    string AccountName { get; set; }
    string Currency { get; set; }
}
class MyAccounts : IAccount
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string AccountName { get; set; }
    public string Currency { get; set; }

    public string Branch { get; set; }
    public decimal Balance { get; set; }
}
class CreditCards
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string AccountName { get; set; }
    public string Currency { get; set; }
    public decimal Limit { get; set; }        
    public decimal CurrentDebt { get; set; }  
}
class ThirdParyAccount : IAccount
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public string AccountName { get; set; }
    public string Currency { get; set; }
}