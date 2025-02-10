using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShgEcom.Domain.Entites.Common
{
    public abstract record BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("created_at")] 
        public DateTime CreatedAt { get; set; }

        [BsonElement("updated_at")] 
        public DateTime UpdatedAt { get; set; }

        [BsonElement("is_deleted")]  
        public bool IsDeleted { get; set; }

        // Constructor for setting default values
        protected BaseEntity()
        {
            Id = Guid.NewGuid();  // Automatically generate a new ObjectId for the entity
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
