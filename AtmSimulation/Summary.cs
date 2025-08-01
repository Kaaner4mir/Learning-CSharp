class Summary
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime Time { get; set; }
    public decimal Amount { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {Type} - {Description} | {Time:HH:mm:ss dd/MM/yyyy} | Tutar: {Amount:C2}";
    }
}