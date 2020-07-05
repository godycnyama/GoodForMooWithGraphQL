using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodForMoo.Server.DataModels
{
    public class OrderDetailInput
    {
        public OrderDetailInput()
        {

        }
        public int ProductID { get; set; }
        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        [MaxLength(20)]
        public string Currency { get; set; }
        [Required]
        [MaxLength(20)]
        public string UnitOfMeasure { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
