using System.Text;
using MotoApp.Entities;

    public class Car:EntityBase
    {
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCoast { get; set; }
    public decimal ListPrice { get; set; }
    public string Type { get; set; }
    public int? NameLength { get; set; }
    public decimal? TotalSales { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new(1024);
        sb.AppendLine($"{Name} ID:{Id}");
        sb.AppendLine($"Color:{Color} Type:{(Type ?? "n /a")}");
        sb.AppendLine($"Cost:{StandardCoast:c}Price:{ListPrice:c}");
        if (NameLength.HasValue)
        {
            sb.AppendLine($"Name Length:{NameLength}");
        }
        if (TotalSales.HasValue)
        {
            sb.AppendLine($"TotalSales:{TotalSales:c}");
        }
        return sb.ToString();
    
    }
}

