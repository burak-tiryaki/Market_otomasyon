using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_otomasyon.Model
{
    public class Product
    {
        public int id { get; set; }
        public string barcode { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updateTime { get; set; }
        public string name { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public int revenue { get; set; }
    }
}
