using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApiMicrosoft.Models
{
    public class OrderHistory
    {
        [Column(TypeName = "DateTime")]
        public DateTime DateTime { get; set; }
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int OrderId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string ClientCode { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string StockCode { get; set; }
      
        [Column(TypeName = "nvarchar(20)")]
        public string MarketSegment { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TradingAccount { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Exchange { get; set; }
  
        [Column(TypeName = "int")]
        public int Price { get; set; }


        [Column(TypeName = "int")]
        public int Quantity { get; set; }


        [Column(TypeName = "int")]
        public int RemainingQty { get; set; }
   
        [Column(TypeName = "nvarchar(20)")]
        public string OrderType { get; set; }

 
        [Column(TypeName = "nvarchar(20)")]
        public string BuySell { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Message { get; set; }
    }
}
