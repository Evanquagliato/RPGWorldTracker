using Microsoft.EntityFrameworkCore.Migrations;

namespace RPGWorldTracker.Migrations
{
    public partial class inint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Kingdom",
                columns: table => new
                {
                    KingdomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourcesEconomy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricalEvents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Threats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdom", x => x.KingdomId);
                    table.ForeignKey(
                        name: "FK_Kingdom_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KingdomKingdom",
                columns: table => new
                {
                    AlliesKingdomId = table.Column<int>(type: "int", nullable: false),
                    EnemiesKingdomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KingdomKingdom", x => new { x.AlliesKingdomId, x.EnemiesKingdomId });
                    table.ForeignKey(
                        name: "FK_KingdomKingdom_Kingdom_AlliesKingdomId",
                        column: x => x.AlliesKingdomId,
                        principalTable: "Kingdom",
                        principalColumn: "KingdomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KingdomKingdom_Kingdom_EnemiesKingdomId",
                        column: x => x.EnemiesKingdomId,
                        principalTable: "Kingdom",
                        principalColumn: "KingdomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Geography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourcesEconomy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Government = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricalEvents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Threats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Defenses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KingdomId = table.Column<int>(type: "int", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Town_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Town_Kingdom_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Kingdom",
                        principalColumn: "KingdomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WealthLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExteriorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownId = table.Column<int>(type: "int", nullable: true),
                    CampaginId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_Home_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Home_Town_TownId",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfStore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodsForSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExteriorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownId = table.Column<int>(type: "int", nullable: true),
                    CampaginId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_Town_TownId",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TownTown",
                columns: table => new
                {
                    AlliesTownId = table.Column<int>(type: "int", nullable: false),
                    RivalsTownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownTown", x => new { x.AlliesTownId, x.RivalsTownId });
                    table.ForeignKey(
                        name: "FK_TownTown_Town_AlliesTownId",
                        column: x => x.AlliesTownId,
                        principalTable: "Town",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TownTown_Town_RivalsTownId",
                        column: x => x.RivalsTownId,
                        principalTable: "Town",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    HomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Home_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Home",
                        principalColumn: "HomeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Store_JobId",
                        column: x => x.JobId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_CampaignId",
                table: "Character",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_HomeId",
                table: "Character",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_JobId",
                table: "Character",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Home_CampaignId",
                table: "Home",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Home_TownId",
                table: "Home",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Kingdom_CampaignId",
                table: "Kingdom",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_KingdomKingdom_EnemiesKingdomId",
                table: "KingdomKingdom",
                column: "EnemiesKingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_CampaignId",
                table: "Store",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_TownId",
                table: "Store",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_CampaignId",
                table: "Town",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_KingdomId",
                table: "Town",
                column: "KingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_TownTown_RivalsTownId",
                table: "TownTown",
                column: "RivalsTownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "KingdomKingdom");

            migrationBuilder.DropTable(
                name: "TownTown");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "Kingdom");

            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
