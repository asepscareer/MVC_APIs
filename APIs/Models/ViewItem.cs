using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIs.Models
{
    public class ViewItem
    {
        public int Id { get; set; }
        [Display(Name = "Item's Name")]
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        [Display(Name = "ID Supplier")]
        public int SupplierID { get; set; }
        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Name { get; set; }
    }
}