using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FeedbackSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Fullname = table.Column<string>(type: "longtext", nullable: false),
                    Activation = table.Column<short>(type: "smallint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true),
                    UserRole = table.Column<string>(type: "longtext", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    uuid = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    connection = table.Column<string>(type: "longtext", nullable: false),
                    queue = table.Column<string>(type: "longtext", nullable: false),
                    payload = table.Column<string>(type: "longtext", nullable: false),
                    exception = table.Column<string>(type: "longtext", nullable: false),
                    FailedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_failed_jobs_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "floor__numbers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floor__numbers_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    model_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, defaultValueSql: "(NULL)"),
                    model_id = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    filename = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    mime_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    token = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "personal_access_tokens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tokenable_type = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    tokenable_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    token = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    abilities = table.Column<string>(type: "longtext", nullable: true),
                    last_used_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_access_tokens_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place__types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place__types_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    building_id = table.Column<long>(type: "bigint", nullable: false),
                    place_type_id = table.Column<long>(type: "bigint", nullable: false),
                    floor_number_id = table.Column<long>(type: "bigint", nullable: false),
                    wing_id = table.Column<long>(type: "bigint", nullable: false),
                    code = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    content = table.Column<string>(type: "longtext", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "request__types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request__types_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "response_types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_response_types_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sender__types",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sender__types_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    ip_address = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, defaultValueSql: "(NULL)"),
                    user_agent = table.Column<string>(type: "longtext", nullable: true),
                    payload = table.Column<string>(type: "longtext", nullable: false),
                    last_activity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ticket_images",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(type: "longtext", nullable: false),
                    ImageFilePath = table.Column<string>(type: "longtext", nullable: false),
                    TicketId = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true),
                    deleted_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_images", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    rate = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)4),
                    classification_id = table.Column<long>(type: "bigint", nullable: false),
                    request_type_id = table.Column<long>(type: "bigint", nullable: false),
                    place_id = table.Column<long>(type: "bigint", nullable: false),
                    response_type_id = table.Column<long>(type: "bigint", nullable: true, defaultValue: 1L),
                    sender_type_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    response_notes = table.Column<string>(type: "longtext", nullable: true),
                    other_request = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, defaultValueSql: "(NULL)"),
                    other_classification = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, defaultValueSql: "(NULL)"),
                    sender_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValueSql: "(NULL)"),
                    sender_email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValueSql: "(NULL)"),
                    sender_phone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    email_verified_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    password = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false),
                    two_factor_secret = table.Column<string>(type: "longtext", nullable: true),
                    two_factor_recovery_codes = table.Column<string>(type: "longtext", nullable: true),
                    remember_token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "(NULL)"),
                    current_team_id = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "(NULL)"),
                    profile_photo_path = table.Column<string>(type: "longtext", nullable: true),
                    role = table.Column<string>(type: "varchar(191)", maxLength: 191, nullable: false, defaultValue: "user"),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true),
                    deleted_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "wings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name_en = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name_ar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    activation = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wings_id", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "buildings_user_id_foreign",
                table: "buildings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "buildings$buildings_name_ar_unique",
                table: "buildings",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "buildings$buildings_name_en_unique",
                table: "buildings",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "classifications_user_id_foreign",
                table: "classifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "classifications$classifications_name_ar_unique",
                table: "classifications",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "classifications$classifications_name_en_unique",
                table: "classifications",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "failed_jobs$failed_jobs_uuid_unique",
                table: "failed_jobs",
                column: "uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "floor__numbers_user_id_foreign",
                table: "floor__numbers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "floor__numbers$floor__numbers_name_ar_unique",
                table: "floor__numbers",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "floor__numbers$floor__numbers_name_en_unique",
                table: "floor__numbers",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "media_model_type_model_id_index",
                table: "media",
                columns: new[] { "model_type", "model_id" });

            migrationBuilder.CreateIndex(
                name: "password_resets_email_index",
                table: "password_resets",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens_tokenable_type_tokenable_id_index",
                table: "personal_access_tokens",
                columns: new[] { "tokenable_type", "tokenable_id" });

            migrationBuilder.CreateIndex(
                name: "personal_access_tokens$personal_access_tokens_token_unique",
                table: "personal_access_tokens",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "place__types_user_id_foreign",
                table: "place__types",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "place__types$place__types_name_ar_unique",
                table: "place__types",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "place__types$place__types_name_en_unique",
                table: "place__types",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "places_building_id_foreign",
                table: "places",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "places_floor_number_id_foreign",
                table: "places",
                column: "floor_number_id");

            migrationBuilder.CreateIndex(
                name: "places_place_type_id_foreign",
                table: "places",
                column: "place_type_id");

            migrationBuilder.CreateIndex(
                name: "places_user_id_foreign",
                table: "places",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "places_wing_id_foreign",
                table: "places",
                column: "wing_id");

            migrationBuilder.CreateIndex(
                name: "places$places_code_unique",
                table: "places",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "posts_user_id_foreign",
                table: "posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "request__types_user_id_foreign",
                table: "request__types",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "request__types$request__types_name_ar_unique",
                table: "request__types",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "request__types$request__types_name_en_unique",
                table: "request__types",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "response_types_user_id_foreign",
                table: "response_types",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "response_types$response_types_name_ar_unique",
                table: "response_types",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "response_types$response_types_name_en_unique",
                table: "response_types",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sender__types_user_id_foreign",
                table: "sender__types",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "sender__types$sender__types_name_ar_unique",
                table: "sender__types",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sender__types$sender__types_name_en_unique",
                table: "sender__types",
                column: "name_en",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sessions_last_activity_index",
                table: "sessions",
                column: "last_activity");

            migrationBuilder.CreateIndex(
                name: "sessions_user_id_index",
                table: "sessions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "tickets_classification_id_foreign",
                table: "tickets",
                column: "classification_id");

            migrationBuilder.CreateIndex(
                name: "tickets_place_id_foreign",
                table: "tickets",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "tickets_request_type_id_foreign",
                table: "tickets",
                column: "request_type_id");

            migrationBuilder.CreateIndex(
                name: "tickets_response_type_id_foreign",
                table: "tickets",
                column: "response_type_id");

            migrationBuilder.CreateIndex(
                name: "tickets_sender_type_id_foreign",
                table: "tickets",
                column: "sender_type_id");

            migrationBuilder.CreateIndex(
                name: "tickets_user_id_foreign",
                table: "tickets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "users$users_email_unique",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "wings_user_id_foreign",
                table: "wings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "wings$wings_name_ar_unique",
                table: "wings",
                column: "name_ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "wings$wings_name_en_unique",
                table: "wings",
                column: "name_en",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "classifications");

            migrationBuilder.DropTable(
                name: "failed_jobs");

            migrationBuilder.DropTable(
                name: "floor__numbers");

            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "personal_access_tokens");

            migrationBuilder.DropTable(
                name: "place__types");

            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "request__types");

            migrationBuilder.DropTable(
                name: "response_types");

            migrationBuilder.DropTable(
                name: "sender__types");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "ticket_images");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "wings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
