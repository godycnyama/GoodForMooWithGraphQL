using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoodForMoo.Server.DataModels
{
    public class UpdateOrderInput
    {
        public UpdateOrderInput()
        {

        }
        [Required]
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }
        [Required]
        public string DeliveryDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; }
        [Required]
        public  OrderDetailInput[] OrderDetails { get; set; }

    }
}
