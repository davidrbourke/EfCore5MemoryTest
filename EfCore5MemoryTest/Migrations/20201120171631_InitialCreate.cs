using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore5MemoryTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionPlan",
                columns: table => new
                {
                    ProductionPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPlan", x => x.ProductionPlanId);
                });

            migrationBuilder.CreateTable(
                name: "PlanItem",
                columns: table => new
                {
                    PlanItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkuId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanItem", x => x.PlanItemId);
                    table.ForeignKey(
                        name: "FK_PlanItem_ProductionPlan_ProductionPlanId",
                        column: x => x.ProductionPlanId,
                        principalTable: "ProductionPlan",
                        principalColumn: "ProductionPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanItem_ProductionPlanId",
                table: "PlanItem",
                column: "ProductionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanItem");

            migrationBuilder.DropTable(
                name: "ProductionPlan");
        }
    }
}
