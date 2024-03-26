using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("tickets")]
[Index("ClassificationId", Name = "tickets_classification_id_foreign")]
[Index("PlaceId", Name = "tickets_place_id_foreign")]
[Index("RequestTypeId", Name = "tickets_request_type_id_foreign")]
[Index("ResponseTypeId", Name = "tickets_response_type_id_foreign")]
[Index("SenderTypeId", Name = "tickets_sender_type_id_foreign")]
[Index("UserId", Name = "tickets_user_id_foreign")]
public partial class Ticket
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("rate")]
    public short Rate { get; set; }

    [Column("classification_id")]
    public long ClassificationId { get; set; }

    [Column("request_type_id")]
    public long RequestTypeId { get; set; }

    [Column("place_id")]
    public long PlaceId { get; set; }

    [Column("response_type_id")]
    public long? ResponseTypeId { get; set; }

    [Column("sender_type_id")]
    public long SenderTypeId { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("response_notes")]
    public string? ResponseNotes { get; set; }

    [Column("other_request")]
    [StringLength(300)]
    public string? OtherRequest { get; set; }

    [Column("other_classification")]
    [StringLength(300)]
    public string? OtherClassification { get; set; }

    [Column("sender_name")]
    [StringLength(200)]
    public string? SenderName { get; set; }

    [Column("sender_email")]
    [StringLength(200)]
    public string? SenderEmail { get; set; }

    [Column("sender_phone")]
    [StringLength(200)]
    public string? SenderPhone { get; set; }

    [Column("user_id")]
    public string? UserId { get; set; }

    [Column("deleted_at", TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
