using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ais.Models
{
    public class Reporting : IReporting
    {
        public string Barcode { get; set; }
        public int Jumlah { get; set; }
        public decimal TotalHarga { get; set; }
        public int Ready { get; set; }
        public int OnHold { get; set; }
        public int Delivered { get; set; }
        public int Packing { get; set; }
        public int Sent { get; set; }

        #region SqlQuery Logic
        //create table #tmpt(
	       // id int,
	       // barcode varchar(50),
	       // product_name varchar(50),
	       // price money,
        //    status varchar(10)
        //);

        //insert #tmpt values ('1','1111','APPLE','10','READY')
        //insert #tmpt values ('2','1111','APPLE','20','DELIVERED')
        //insert #tmpt values ('3','1111','APPLE','30','SENT')
        //insert #tmpt values ('4','1111','APPLE','10','ONHOLD')
        //insert #tmpt values ('5','1111','APPLE','20','PACKING')
        //insert #tmpt values ('6','1111','APPLE','40','SENT')
        //insert #tmpt values ('7','1111','APPLE','50','SENT')
        //insert #tmpt values ('8','1122','PINEAPPLE','10','READY')
        //insert #tmpt values ('9','1122','PINEAPPLE','10','DELIVERED')
        //insert #tmpt values ('10','1122','PINEAPPLE','10','PACKING')
        //insert #tmpt values ('11','1122','PINEAPPLE','10','DELIVERED')

        //select barcode, COUNT(*) jumlah,
        //sum(price) as [total harga],
        //sum(case when status = 'READY' then 1 else 0 end) as ready,
        //sum(case when status = 'ONHOLD' then 1 else 0 end) as onhold,
        //sum(case when status = 'DELIVERED' then 1 else 0 end) as delivered,
        //sum(case when status = 'PACKING' then 1 else 0 end) as packing,
        //sum(case when status = 'SENT' then 1 else 0 end) as [sent]
        //        From #tmpt
        //group by barcode

        //drop table #tmpt;
        #endregion

        public Reporting() { }

        public DataTable GenerateData()
        {
            DataTable myTable = new DataTable("Reporting");

            #region Add columns
            myTable.Columns.Add("Id", typeof(int));
            myTable.Columns.Add("Barcode", typeof(string));
            myTable.Columns.Add("Product_Name", typeof(string));
            myTable.Columns.Add("Price", typeof(decimal));
            myTable.Columns.Add("Status", typeof(string));
            #endregion

            #region  Add data rows
            DataRow row = myTable.NewRow();
            row["Id"] = 1;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 10;
            row["Status"] = "READY";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 2;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 20;
            row["Status"] = "DELIVERED";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 3;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 30;
            row["Status"] = "SENT";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 4;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 10;
            row["Status"] = "ONHOLD";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 5;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 20;
            row["Status"] = "PACKING";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 6;
            row["Barcode"] = "1111";
            row["Product_Name"] = "John";
            row["Price"] = 40;
            row["Status"] = "SENT";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 7;
            row["Barcode"] = "1111";
            row["Product_Name"] = "APPLE";
            row["Price"] = 50;
            row["Status"] = "SENT";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 8;
            row["Barcode"] = "1112";
            row["Product_Name"] = "PINEAPPLE";
            row["Price"] = 10;
            row["Status"] = "READY";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 9;
            row["Barcode"] = "1112";
            row["Product_Name"] = "PINEAPPLE";
            row["Price"] = 10;
            row["Status"] = "DELIVERED";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 10;
            row["Barcode"] = "1112";
            row["Product_Name"] = "PINEAPPLE";
            row["Price"] = 10;
            row["Status"] = "PACKING";
            myTable.Rows.Add(row);

            row = myTable.NewRow();
            row["Id"] = 11;
            row["Barcode"] = "1112";
            row["Product_Name"] = "PINEAPPLE";
            row["Price"] = 10;
            row["Status"] = "DELIVERED";
            myTable.Rows.Add(row);
            #endregion

            return myTable;
        }

        private DataTable DisplayData(IEnumerable<Reporting> reportings)
        {
            DataTable myTable = new DataTable("Reporting");

            #region Add columns
            myTable.Columns.Add("barcode", typeof(string));
            myTable.Columns.Add("jumlah", typeof(int));
            myTable.Columns.Add("total harga", typeof(decimal));
            myTable.Columns.Add("ready", typeof(int));
            myTable.Columns.Add("onhold", typeof(int));
            myTable.Columns.Add("delivered", typeof(int));
            myTable.Columns.Add("packing", typeof(int));
            myTable.Columns.Add("sent", typeof(int));
            #endregion

            #region Binding data rows
            foreach (var data in reportings)
            {
                DataRow row = myTable.NewRow();
                row["barcode"] = data.Barcode;
                row["jumlah"] = data.Jumlah;
                row["total harga"] = data.TotalHarga;
                row["ready"] = data.Ready;
                row["onhold"] = data.OnHold;
                row["delivered"] = data.Delivered;
                row["packing"] = data.Packing;
                row["sent"] = data.Sent;
                myTable.Rows.Add(row);
            }
            #endregion

            return myTable;
        }

        public DataTable ShowReport(DataTable source)
        {
            var result = from r in source.Rows.OfType<DataRow>()
                         group r by r["Barcode"] into g
                         select new Reporting()
                         {
                             Barcode = g.Key.ToString(),
                             Jumlah = g.Count(),
                             TotalHarga = g.Sum(x => Convert.ToDecimal(x["Price"])),
                             Ready = g.Sum(x => x["Status"].ToString() == "READY" ? 1 : 0),
                             OnHold = g.Sum(x => x["Status"].ToString() == "ONHOLD" ? 1 : 0),
                             Delivered = g.Sum(x => x["Status"].ToString() == "DELIVERED" ? 1 : 0),
                             Packing = g.Sum(x => x["Status"].ToString() == "PACKING" ? 1 : 0),
                             Sent = g.Sum(x => x["Status"].ToString() == "SENT" ? 1 : 0)
                         };
            var displayData = DisplayData(result);
            return displayData;
        }

        public int[] SortAndGetPositiveNumber(int[] value)
        {
            if (value.Any())
                return value.Where(x => x > 0).OrderBy(x => x).ToArray();

            throw new Exception("Value is null or empty.");
        }
    }
}
