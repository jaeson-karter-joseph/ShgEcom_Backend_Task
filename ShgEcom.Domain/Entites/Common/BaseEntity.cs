namespace ShgEcom.Domain.Entites.Common
{
    public abstract record BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
