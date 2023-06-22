using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeltExam.Migrations
{
    public partial class UpdateUserMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoupon_Coupons_CouponId",
                table: "UserCoupon");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCoupon_Users_UserId",
                table: "UserCoupon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoupon",
                table: "UserCoupon");

            migrationBuilder.RenameTable(
                name: "UserCoupon",
                newName: "UserCoupons");

            migrationBuilder.RenameIndex(
                name: "IX_UserCoupon_UserId",
                table: "UserCoupons",
                newName: "IX_UserCoupons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCoupon_CouponId",
                table: "UserCoupons",
                newName: "IX_UserCoupons_CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoupons",
                table: "UserCoupons",
                column: "UserCouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoupons_Coupons_CouponId",
                table: "UserCoupons",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoupons_Users_UserId",
                table: "UserCoupons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCoupons_Coupons_CouponId",
                table: "UserCoupons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCoupons_Users_UserId",
                table: "UserCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCoupons",
                table: "UserCoupons");

            migrationBuilder.RenameTable(
                name: "UserCoupons",
                newName: "UserCoupon");

            migrationBuilder.RenameIndex(
                name: "IX_UserCoupons_UserId",
                table: "UserCoupon",
                newName: "IX_UserCoupon_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCoupons_CouponId",
                table: "UserCoupon",
                newName: "IX_UserCoupon_CouponId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCoupon",
                table: "UserCoupon",
                column: "UserCouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoupon_Coupons_CouponId",
                table: "UserCoupon",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "CouponId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCoupon_Users_UserId",
                table: "UserCoupon",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
