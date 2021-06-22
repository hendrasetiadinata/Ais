using System.Data;

namespace Ais.Models
{
    public interface IReporting
    {
        string Barcode { get; set; }
        int Delivered { get; set; }
        int Jumlah { get; set; }
        int OnHold { get; set; }
        int Packing { get; set; }
        int Ready { get; set; }
        int Sent { get; set; }
        decimal TotalHarga { get; set; }

        DataTable GenerateData();
        DataTable ShowReport(DataTable source);
        int[] SortAndGetPositiveNumber(int[] value);
    }
}