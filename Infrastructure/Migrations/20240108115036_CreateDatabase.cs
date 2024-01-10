using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Account",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "AccountAddress",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "AccountCheck",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "AccountCredit",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Article",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Bank",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Calendar",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "CalendarAttachment",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "CalendarReceiver",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Category",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "City",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Country",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "CreditPayment",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "CurrencyType",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "EducationField",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "EducationLevel",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "EducationSubField",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "MyQuickAccess",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "MySitePage",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Package",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Post",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "SiteAction",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "SiteMenu",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "State",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Ticket",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "TicketAttachment",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Unit",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "User",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "UserGroup",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "UserGroupPrivilage",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "UserLog",
                startValue: 1000L);

            migrationBuilder.CreateSequence<int>(
                name: "Zone",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CurrencySign = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Discount = table.Column<long>(type: "bigint", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostParentId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_PostParentId",
                        column: x => x.PostParentId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AbbreviatedTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false),
                    UserGroupParentId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_UserGroups_UserGroupParentId",
                        column: x => x.UserGroupParentId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitCount = table.Column<int>(type: "int", nullable: false),
                    IsSlider = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WriterPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WriterImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aparat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canonical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoFollow = table.Column<bool>(type: "bit", nullable: true),
                    NoIndex = table.Column<bool>(type: "bit", nullable: true),
                    PostLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpireDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationSubFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EducationFieldId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationSubFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationSubFields_EducationFields_EducationFieldId",
                        column: x => x.EducationFieldId,
                        principalTable: "EducationFields",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SitePage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitePage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitePage_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostJuncUserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    Assigned = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostJuncUserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostJuncUserGroups_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostJuncUserGroups_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuickAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SitePageId = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickAccess_SitePage_SitePageId",
                        column: x => x.SitePageId,
                        principalTable: "SitePage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    SitePageId = table.Column<long>(type: "bigint", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteActions_SiteActions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SiteActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiteActions_SitePage_SitePageId",
                        column: x => x.SitePageId,
                        principalTable: "SitePage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGroupPrivilages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserGroupId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<long>(type: "bigint", nullable: false),
                    SitePageId = table.Column<long>(type: "bigint", nullable: false),
                    SiteActionId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupPrivilages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupPrivilages_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupPrivilages_SiteActions_SiteActionId",
                        column: x => x.SiteActionId,
                        principalTable: "SiteActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserGroupPrivilages_SitePage_SitePageId",
                        column: x => x.SitePageId,
                        principalTable: "SitePage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupPrivilages_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExtraPhone1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExtraPhone2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExtraPhone3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExtraEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Linkedin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Job = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountalNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    WorkingHoursRate = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReagentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReagentCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DigitalSignatureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResumeUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpacialAccount = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: true),
                    EducationSubFieldId = table.Column<int>(type: "int", nullable: true),
                    EducationLevelId = table.Column<int>(type: "int", nullable: true),
                    EmployeementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_EducationSubFields_EducationSubFieldId",
                        column: x => x.EducationSubFieldId,
                        principalTable: "EducationSubFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExtraPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LocationLat = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LocationLong = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAddresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AccountChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CheckNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    PayTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FrontImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BackImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SignatureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountChecks_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountChecks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountJuncPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountJuncPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountJuncPost_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountJuncPost_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<string>(type: "char(10)", nullable: false),
                    EventTime = table.Column<string>(type: "char(8)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    NotificationDate = table.Column<string>(type: "char(10)", nullable: true),
                    NotificationTime = table.Column<string>(type: "char(8)", nullable: true),
                    HasTwoStepNotification = table.Column<bool>(type: "bit", nullable: true),
                    NotificationSend = table.Column<bool>(type: "bit", nullable: false),
                    TwoStepNotificationSend = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Accounts_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsStar = table.Column<bool>(type: "bit", nullable: false),
                    IsArchive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VerifyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerifyTryCount = table.Column<int>(type: "int", nullable: false),
                    LastVerifyTryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MobileVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    Remain = table.Column<long>(type: "bigint", nullable: false),
                    AccountCheckId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreditType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCredits_AccountChecks_AccountCheckId",
                        column: x => x.AccountCheckId,
                        principalTable: "AccountChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AccountCredits_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarAttachments_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarReceivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarReceivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarReceivers_Accounts_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CalendarReceivers_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketParentId = table.Column<int>(type: "int", nullable: true),
                    TicketText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketCreatorId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TicketPriority = table.Column<int>(type: "int", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Tickets_TicketParentId",
                        column: x => x.TicketParentId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_TicketCreatorId",
                        column: x => x.TicketCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Device = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    AccountCreditId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RefNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExternalInfo1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExternalInfo2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false),
                    IsInPlace = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditPayments_AccountCredits_AccountCreditId",
                        column: x => x.AccountCreditId,
                        principalTable: "AccountCredits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditPayments_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditPayments_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditPayments_CurrencyTypes_CurrencyTypeId1",
                        column: x => x.CurrencyTypeId1,
                        principalTable: "CurrencyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    ModifireId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAttachments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_AccountId",
                table: "AccountAddresses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_CityId",
                table: "AccountAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_CountryId",
                table: "AccountAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_FullName",
                table: "AccountAddresses",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_StateId",
                table: "AccountAddresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_Title",
                table: "AccountAddresses",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_ZoneId",
                table: "AccountAddresses",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChecks_AccountId",
                table: "AccountChecks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChecks_BankId",
                table: "AccountChecks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChecks_CheckNumber",
                table: "AccountChecks",
                column: "CheckNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountCredits_AccountCheckId",
                table: "AccountCredits",
                column: "AccountCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCredits_AccountId",
                table: "AccountCredits",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountJuncPost_AccountId",
                table: "AccountJuncPost",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountJuncPost_PostId",
                table: "AccountJuncPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountalNumber",
                table: "Accounts",
                column: "AccountalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CityId",
                table: "Accounts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyNo",
                table: "Accounts",
                column: "CompanyNo",
                unique: true,
                filter: "[CompanyNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CountryId",
                table: "Accounts",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EducationLevelId",
                table: "Accounts",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EducationSubFieldId",
                table: "Accounts",
                column: "EducationSubFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_NationalCode",
                table: "Accounts",
                column: "NationalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PackageId",
                table: "Accounts",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Phone",
                table: "Accounts",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StateId",
                table: "Accounts",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ZoneId",
                table: "Accounts",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Title",
                table: "Banks",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarAttachments_CalendarId",
                table: "CalendarAttachments",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarReceivers_CalendarId",
                table: "CalendarReceivers",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarReceivers_ReceiverId",
                table: "CalendarReceivers",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_SenderId",
                table: "Calendars",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Code",
                table: "Cities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Title",
                table: "Cities",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Title",
                table: "Countries",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayments_AccountCreditId",
                table: "CreditPayments",
                column: "AccountCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayments_AccountId",
                table: "CreditPayments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayments_CurrencyTypeId",
                table: "CreditPayments",
                column: "CurrencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayments_CurrencyTypeId1",
                table: "CreditPayments",
                column: "CurrencyTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPayments_RefNumber",
                table: "CreditPayments",
                column: "RefNumber",
                unique: true,
                filter: "[RefNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyTypes_Title",
                table: "CurrencyTypes",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationSubFields_EducationFieldId",
                table: "EducationSubFields",
                column: "EducationFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParentId",
                table: "Menu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Code",
                table: "Packages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Title",
                table: "Packages",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostJuncUserGroups_PostId",
                table: "PostJuncUserGroups",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostJuncUserGroups_UserGroupId",
                table: "PostJuncUserGroups",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostParentId",
                table: "Posts",
                column: "PostParentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuickAccess_SitePageId",
                table: "QuickAccess",
                column: "SitePageId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteActions_ParentId",
                table: "SiteActions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteActions_SitePageId",
                table: "SiteActions",
                column: "SitePageId");

            migrationBuilder.CreateIndex(
                name: "IX_SitePage_MenuId",
                table: "SitePage",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Code",
                table: "States",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_States_Title",
                table: "States",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachments_TicketId",
                table: "TicketAttachments",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCreatorId",
                table: "Tickets",
                column: "TicketCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketParentId",
                table: "Tickets",
                column: "TicketParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_AbbreviatedTitle",
                table: "Units",
                column: "AbbreviatedTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Title",
                table: "Units",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPrivilages_MenuId",
                table: "UserGroupPrivilages",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPrivilages_SiteActionId",
                table: "UserGroupPrivilages",
                column: "SiteActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPrivilages_SitePageId",
                table: "UserGroupPrivilages",
                column: "SitePageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPrivilages_UserGroupId",
                table: "UserGroupPrivilages",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserGroupParentId",
                table: "UserGroups",
                column: "UserGroupParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_CreatorId",
                table: "UserLogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CityId",
                table: "Zones",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Code",
                table: "Zones",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Title",
                table: "Zones",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAddresses");

            migrationBuilder.DropTable(
                name: "AccountJuncPost");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "CalendarAttachments");

            migrationBuilder.DropTable(
                name: "CalendarReceivers");

            migrationBuilder.DropTable(
                name: "CreditPayments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PostJuncUserGroups");

            migrationBuilder.DropTable(
                name: "QuickAccess");

            migrationBuilder.DropTable(
                name: "TicketAttachments");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "UserGroupPrivilages");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "AccountCredits");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "SiteActions");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "AccountChecks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SitePage");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "EducationSubFields");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "EducationFields");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropSequence(
                name: "Account");

            migrationBuilder.DropSequence(
                name: "AccountAddress");

            migrationBuilder.DropSequence(
                name: "AccountCheck");

            migrationBuilder.DropSequence(
                name: "AccountCredit");

            migrationBuilder.DropSequence(
                name: "Article");

            migrationBuilder.DropSequence(
                name: "Bank");

            migrationBuilder.DropSequence(
                name: "Calendar");

            migrationBuilder.DropSequence(
                name: "CalendarAttachment");

            migrationBuilder.DropSequence(
                name: "CalendarReceiver");

            migrationBuilder.DropSequence(
                name: "Category");

            migrationBuilder.DropSequence(
                name: "City");

            migrationBuilder.DropSequence(
                name: "Country");

            migrationBuilder.DropSequence(
                name: "CreditPayment");

            migrationBuilder.DropSequence(
                name: "CurrencyType");

            migrationBuilder.DropSequence(
                name: "EducationField");

            migrationBuilder.DropSequence(
                name: "EducationLevel");

            migrationBuilder.DropSequence(
                name: "EducationSubField");

            migrationBuilder.DropSequence(
                name: "MyQuickAccess");

            migrationBuilder.DropSequence(
                name: "MySitePage");

            migrationBuilder.DropSequence(
                name: "Package");

            migrationBuilder.DropSequence(
                name: "Post");

            migrationBuilder.DropSequence(
                name: "SiteAction");

            migrationBuilder.DropSequence(
                name: "SiteMenu");

            migrationBuilder.DropSequence(
                name: "State");

            migrationBuilder.DropSequence(
                name: "Ticket");

            migrationBuilder.DropSequence(
                name: "TicketAttachment");

            migrationBuilder.DropSequence(
                name: "Unit");

            migrationBuilder.DropSequence(
                name: "User");

            migrationBuilder.DropSequence(
                name: "UserGroup");

            migrationBuilder.DropSequence(
                name: "UserGroupPrivilage");

            migrationBuilder.DropSequence(
                name: "UserLog");

            migrationBuilder.DropSequence(
                name: "Zone");
        }
    }
}
