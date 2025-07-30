class CreditCards : IAccount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Branch { get; set; }
    public string Currency { get; set; }
    public decimal Balance { get; set; }

}