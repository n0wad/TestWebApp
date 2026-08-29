using System.ComponentModel.DataAnnotations;

namespace TestWebService.Models
{
    public class OrderRequest
    {
        [Display(Name = "Город отправителя")]
        public required string SenderCity { get; set; }

        [Display(Name = "Адрес отправителя")]
        public required string SenderAddress { get; set; }

        [Display(Name = "Город получателя")]
        public required string ReceiverCity { get; set; }

        [Display(Name = "Адрес получателя")]
        public required string ReceiverAddress { get; set; }

        [Display(Name = "Вес груза")]
        [Range(0.01, 10000)]
        public decimal Weight { get; set; }

        [Display(Name = "Дата забора груза")]
        [Required]
        public DateTime PickupDate { get; set; }
    }
}
