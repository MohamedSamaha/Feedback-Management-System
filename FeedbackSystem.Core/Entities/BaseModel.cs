using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Core.Entities
{
	public class BaseModel
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at", TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }
        [Column("created_by")]
        public string? CreatedBy { get; set; }
        [Column("updated_by")]
        public string? UpdatedBy { get; set; }
        [Column("deleted_by")]
        public string? DeletedBy { get; set; }
	}
}