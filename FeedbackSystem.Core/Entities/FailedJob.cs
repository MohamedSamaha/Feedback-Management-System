﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FeedbackSystem.Core.Entities;

[Table("failed_jobs")]
[Index("Uuid", Name = "failed_jobs$failed_jobs_uuid_unique", IsUnique = true)]
public partial class FailedJob
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("uuid")]
    [StringLength(191)]
    public string Uuid { get; set; } = null!;

    [Column("connection")]
    public string Connection { get; set; } = null!;

    [Column("queue")]
    public string Queue { get; set; } = null!;

    [Column("payload")]
    public string Payload { get; set; } = null!;

    [Column("exception")]
    public string Exception { get; set; } = null!;

    public DateTime FailedAt { get; set; }
}
