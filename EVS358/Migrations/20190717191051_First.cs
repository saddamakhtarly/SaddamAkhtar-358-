using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EVS358.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginId = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecurityQuestion = table.Column<string>(type: "varchar(255)", nullable: true),
                    SecurityAnswer = table.Column<string>(type: "varchar(255)", nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhoods_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Neighborhoods_Neighborhoods_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAdvs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PropertyTypeId = table.Column<int>(nullable: false),
                    AdvTypeId = table.Column<int>(nullable: false),
                    AdvStatusId = table.Column<int>(nullable: false),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    PostedById = table.Column<int>(nullable: false),
                    PostedOn = table.Column<DateTime>(nullable: false),
                    StartOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Beds = table.Column<int>(nullable: false),
                    Baths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAdvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_AdvStatus_AdvStatusId",
                        column: x => x.AdvStatusId,
                        principalTable: "AdvStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_AdvTypes_AdvTypeId",
                        column: x => x.AdvTypeId,
                        principalTable: "AdvTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_Users_PostedById",
                        column: x => x.PostedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvs_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAdvsFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisementId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false),
                    PropertyAdvId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAdvsFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAdvsFeatures_PropertyAdvs_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvsFeatures_PropertyFeatures_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "PropertyFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAdvsFeatures_PropertyAdvs_PropertyAdvId",
                        column: x => x.PropertyAdvId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    PropertyAdvId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyArea_PropertyAdvs_PropertyAdvId",
                        column: x => x.PropertyAdvId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyArea_AreaUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "AreaUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(300)", nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PropertyAdvId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImage_PropertyAdvs_PropertyAdvId",
                        column: x => x.PropertyAdvId,
                        principalTable: "PropertyAdvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_CityId",
                table: "Neighborhoods",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_ParentId",
                table: "Neighborhoods",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_AdvStatusId",
                table: "PropertyAdvs",
                column: "AdvStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_AdvTypeId",
                table: "PropertyAdvs",
                column: "AdvTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_NeighborhoodId",
                table: "PropertyAdvs",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_PostedById",
                table: "PropertyAdvs",
                column: "PostedById");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvs_PropertyTypeId",
                table: "PropertyAdvs",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvsFeatures_AdvertisementId",
                table: "PropertyAdvsFeatures",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvsFeatures_FeatureId",
                table: "PropertyAdvsFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAdvsFeatures_PropertyAdvId",
                table: "PropertyAdvsFeatures",
                column: "PropertyAdvId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyArea_PropertyAdvId",
                table: "PropertyArea",
                column: "PropertyAdvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertyArea_UnitId",
                table: "PropertyArea",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_PropertyAdvId",
                table: "PropertyImage",
                column: "PropertyAdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PropertyAdvsFeatures");

            migrationBuilder.DropTable(
                name: "PropertyArea");

            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyFeatures");

            migrationBuilder.DropTable(
                name: "AreaUnits");

            migrationBuilder.DropTable(
                name: "PropertyAdvs");

            migrationBuilder.DropTable(
                name: "AdvStatus");

            migrationBuilder.DropTable(
                name: "AdvTypes");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
