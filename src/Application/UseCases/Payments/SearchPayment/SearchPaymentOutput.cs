namespace Application.UseCases.Payments.SearchPayment
{
    public class SearchPaymentOutput
    {
        public Guid Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Holder { get; set; } = string.Empty;
        public int Number { get; set; }
        public DateTime Expiration { get; set; }
        public int CVV { get; set; }
        public bool Default { get; set; } = false;
    }
}
