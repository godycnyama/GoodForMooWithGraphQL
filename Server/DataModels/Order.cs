using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate.Types;

namespace GoodForMoo.Server.DataModels
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Tax { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Total { get; set; }
        [Required]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [UseSelection]
        [UseFiltering]
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [Required]
        [MaxLength(20)]
        public string Currency { get; set; }
        [MaxLength(50)]
        public string OrderStatus { get; set; }

    }
}
