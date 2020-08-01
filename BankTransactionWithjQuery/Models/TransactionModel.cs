
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactionWithjQuery.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(12,ErrorMessage = "Maximum 12 characters only.")]
        public string AccountNumber { get; set; }


        [Column(TypeName = "nvarchar(100)")]    
        [DisplayName("Benificiary Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string BenificiaryName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "This Field is required.")]
        public string BankName { get; set; }


        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("SWIFT Code")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11,ErrorMessage = "Maximum 11 characters only.")]
        public string SwiftCode { get; set; }


        [DisplayName("Amount")]
        [Required(ErrorMessage = "This Field is required.")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
