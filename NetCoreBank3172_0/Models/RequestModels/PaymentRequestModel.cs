﻿namespace NetCoreBank3172_0.Models.RequestModels
{
    public class PaymentRequestModel
    {
        public string CardNumber { get; set; }
        public string CardUserName { get; set; }
        public string CVC { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public decimal ShoppingPrice { get; set; }

    }
}
