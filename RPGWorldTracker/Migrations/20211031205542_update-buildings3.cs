using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGWorldTracker.Migrations
{
    public partial class updatebuildings3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_Campaign_CampaignId",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Campaign_CampaignId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CampaginId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CampaginId",
                table: "Home");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Home",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Campaign_CampaignId",
                table: "Home",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Campaign_CampaignId",
                table: "Store",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_Campaign_CampaignId",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Campaign_CampaignId",
                table: "Store");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Store",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CampaginId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Home",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CampaginId",
                table: "Home",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Campaign_CampaignId",
                table: "Home",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Campaign_CampaignId",
                table: "Store",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
