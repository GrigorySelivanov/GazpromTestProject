using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContext.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDependenciesBetweenOfferAndProviderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Offers_OfferId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_OfferId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Providers");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Offers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProviderId",
                table: "Offers",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Providers_ProviderId",
                table: "Offers",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Providers_ProviderId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ProviderId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Providers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_OfferId",
                table: "Providers",
                column: "OfferId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Offers_OfferId",
                table: "Providers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
