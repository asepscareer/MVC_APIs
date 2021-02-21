using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIs.Models
{
    [Table("Tb_M_Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Item's Name")]
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        [Display(Name = "ID Supplier")]
        public int SupplierID { get; set; }
        public virtual Supplier supplier { get; set; }
    }
}