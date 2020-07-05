using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodForMoo.Server.DataModels
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailID { get; set; }
        [Required]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        [Required]
        public int ProductID { get; set; }
        [MaxLength(150)]
        [Required]
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal UnitPrice { get; set; }
        [MaxLength(20)]
        [Required]
        public string Currency { get; set; }
        [MaxLength(20)]
        [Required]
        public string UnitOfMeasure { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
