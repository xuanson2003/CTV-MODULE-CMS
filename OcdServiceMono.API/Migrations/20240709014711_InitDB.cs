using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcdServiceMono.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cms_posts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Tiêu đề"),
                    desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Mô tả ngắn"),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Nội dung"),
                    view = table.Column<int>(type: "integer", nullable: false, comment: "Lượt xem"),
                    is_hot = table.Column<bool>(type: "boolean", nullable: false, comment: "Là tin nổi bật"),
                    source = table.Column<int>(type: "integer", nullable: false, comment: "Nguồn của bài viết"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Tình trạng của bài viết (true: Hoạt động, false: Không hoạt động)"),
                    avatar = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Đường dẫn ảnh đại diện"),
                    status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Trạng thái của tin bài (da_duyet: Đã duyệt, chua_duyet: Chưa duyệt, ...)"),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cms_posts", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cms_posts");
        }
    }
}
