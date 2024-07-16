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
                name: "CMS_Cer_Content",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cms_cer_content", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Group_News",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    descible = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    create_by = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cms_group_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Post",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Tiêu đề"),
                    desc = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Mô tả ngắn"),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true, comment: "Nội dung"),
                    view = table.Column<int>(type: "integer", nullable: false, comment: "Lượt xem"),
                    is_hot = table.Column<bool>(type: "boolean", nullable: false, comment: "Là tin nổi bật"),
                    source = table.Column<string>(type: "text", nullable: true, comment: "Nguồn của bài viết"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, comment: "Tình trạng của bài viết (true: Hoạt động, false: Không hoạt động)"),
                    avatar = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Đường dẫn ảnh đại diện"),
                    status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "Trạng thái của tin bài (da_duyet: Đã duyệt, chua_duyet: Chưa duyệt, ...)"),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cms_post", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SM_Department",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SM_Menu",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    parent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    icon = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    sm_menu_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_menu", x => x.id);
                    table.ForeignKey(
                        name: "fk_sm_menu_sm_menu_sm_menu_id",
                        column: x => x.sm_menu_id,
                        principalTable: "SM_Menu",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SM_Permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descible = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SM_Role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descible = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CMS_Group_Posts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cms_group_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_cms_group_posts_cms_group_news_id",
                        column: x => x.id,
                        principalTable: "CMS_Group_News",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cms_group_posts_cms_post_id",
                        column: x => x.id,
                        principalTable: "CMS_Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_File",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    extention = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    size = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    create_by = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ContentId = table.Column<Guid>(name: "ContentId ", type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(name: "PostId ", type: "uuid", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_file", x => x.id);
                    table.ForeignKey(
                        name: "fk_sm_file_cms_cer_content_id",
                        column: x => x.id,
                        principalTable: "CMS_Cer_Content",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sm_file_cms_post_id",
                        column: x => x.id,
                        principalTable: "CMS_Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SM_Accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    pass_word = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    full_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    avatar = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    citizen_card = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    create_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    create_by = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DepartmentId = table.Column<Guid>(name: "DepartmentId ", type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(name: "RoleId ", type: "uuid", nullable: false),
                    created_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản khởi tạo"),
                    created_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày khởi tạo"),
                    updated_by = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true, comment: "Tài khoản cập nhập lần cuối"),
                    updated_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày cập nhập lần cuối"),
                    delete_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "Ngày xóa lần cuối")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sm_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_sm_accounts_sm_department_id",
                        column: x => x.id,
                        principalTable: "SM_Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sm_accounts_sm_role_id",
                        column: x => x.id,
                        principalTable: "SM_Role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_sm_menu_sm_menu_id",
                table: "SM_Menu",
                column: "sm_menu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CMS_Group_Posts");

            migrationBuilder.DropTable(
                name: "SM_Accounts");

            migrationBuilder.DropTable(
                name: "SM_File");

            migrationBuilder.DropTable(
                name: "SM_Menu");

            migrationBuilder.DropTable(
                name: "SM_Permission");

            migrationBuilder.DropTable(
                name: "CMS_Group_News");

            migrationBuilder.DropTable(
                name: "SM_Department");

            migrationBuilder.DropTable(
                name: "SM_Role");

            migrationBuilder.DropTable(
                name: "CMS_Cer_Content");

            migrationBuilder.DropTable(
                name: "CMS_Post");
        }
    }
}
