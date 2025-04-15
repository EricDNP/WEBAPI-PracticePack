using Domain.Interfaces.Common;

namespace Domain.Entities
{
    public class BaseEntity : IBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Deleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }
}
