using System.ComponentModel.DataAnnotations;

namespace TestWebService.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Номер заказа")]
        public string OrderNumber { get; set; }

        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; }

        [Display(Name = "Адрес отправителя")]
        public string SenderAddress { get; set; }

        [Display(Name = "Город получателя")]
        public string ReceiverCity { get; set; }

        [Display(Name = "Адрес получателя")]
        public string ReceiverAddress { get; set; }

        [Display(Name = "Вес груза")]
        public decimal Weight { get; set; }

        [Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }
    }
}
