namespace Application.UseCases.Addresses.SearchAddress
{
    public class SearchAddressOutput
    {
        public Guid Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public bool Default { get; set; } = false;
    }
}
