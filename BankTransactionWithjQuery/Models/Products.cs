
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BankTransactionWithjQuery.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MinLength(3,ErrorMessage = "Minimum 3 characters only")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        [DisplayName("Product Category")]
        [Required(ErrorMessage = "This Field is required.")]
        public string Category { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        [DisplayName("Product Color")]
        [Required(ErrorMessage = "This Field is required.")]
        public string Color { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "This Field is required.")]
        public decimal UnitDecimal { get; set; }

        [DisplayName("Avialable Quantity")]
        [Required(ErrorMessage = "This Field is required.")]
        public int AvailableQuantity { get; set; }

        [DisplayName("Porduct Create Date")]
        [Required(ErrorMessage = "This Field id required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DisplayName("Valid until")]
        [Required(ErrorMessage = "This Field is required.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
