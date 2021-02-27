using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asa.ApartmentManagement.Persistence.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(nullable: true),
                    ApartmentCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "ExpensCategory",
                columns: table => new
                {
                    ExpensCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensCategoryName = table.Column<string>(nullable: true),
                    FormulaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensCategory", x => x.ExpensCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apartment_Area = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Apartment_Number = table.Column<int>(nullable: false),
                    Apartment_BuildingId = table.Column<int>(nullable: false),
                    Area = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Number = table.Column<int>(nullable: true),
                    BuidingId = table.Column<int>(nullable: true),
                    BuildingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartment_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_Building_Apartment_BuildingId",
                        column: x => x.Apartment_BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expense_Amount = table.Column<int>(nullable: false),
                    Expense_From = table.Column<DateTime>(nullable: false),
                    Expense_To = table.Column<DateTime>(nullable: false),
                    FormulaType = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    ExpensCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_ExpensCategory_ExpensCategoryId",
                        column: x => x.ExpensCategoryId,
                        principalTable: "ExpensCategory",
                        principalColumn: "ExpensCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    ChargeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(nullable: false),
                    CalculateDateTime = table.Column<DateTime>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.ChargeId);
                    table.ForeignKey(
                        name: "FK_Charge_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupantCount = table.Column<int>(nullable: false),
                    IsOwner = table.Column<bool>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PayerId);
                    table.ForeignKey(
                        name: "FK_Person_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChargeItem",
                columns: table => new
                {
                    ChargeItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayerId = table.Column<int>(nullable: false),
                    ExpensId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    ChargeId = table.Column<int>(nullable: false),
                    ChargeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeItem", x => x.ChargeItemId);
                    table.ForeignKey(
                        name: "FK_ChargeItem_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "ChargeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargeItem_Charge_ChargeId1",
                        column: x => x.ChargeId1,
                        principalTable: "Charge",
                        principalColumn: "ChargeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChargeItem_Expense_ExpensId",
                        column: x => x.ExpensId,
                        principalTable: "Expense",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargeItem_Person_PayerId",
                        column: x => x.PayerId,
                        principalTable: "Person",
                        principalColumn: "PayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTenant",
                columns: table => new
                {
                    OwnerTenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupantCount = table.Column<int>(nullable: true),
                    IsOwner = table.Column<bool>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTenant", x => x.OwnerTenantId);
                    table.ForeignKey(
                        name: "FK_OwnerTenant_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "ApartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerTenant_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingId",
                table: "Apartment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Apartment_BuildingId",
                table: "Apartment",
                column: "Apartment_BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ApartmentId",
                table: "Charge",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeItem_ChargeId",
                table: "ChargeItem",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeItem_ChargeId1",
                table: "ChargeItem",
                column: "ChargeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeItem_ExpensId",
                table: "ChargeItem",
                column: "ExpensId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeItem_PayerId",
                table: "ChargeItem",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpensCategoryId",
                table: "Expense",
                column: "ExpensCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTenant_ApartmentId",
                table: "OwnerTenant",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTenant_PersonId",
                table: "OwnerTenant",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ApartmentId",
                table: "Person",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargeItem");

            migrationBuilder.DropTable(
                name: "OwnerTenant");

            migrationBuilder.DropTable(
                name: "Charge");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "ExpensCategory");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
