using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.DATA.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    username = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    message = table.Column<string>(nullable: false),
                    channelid = table.Column<long>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.id);
                    table.ForeignKey(
                        name: "FK_Message_Channel_channelid",
                        column: x => x.channelid,
                        principalTable: "Channel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User_username",
                        column: x => x.username,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userChannel",
                columns: table => new
                {
                    idChannel = table.Column<long>(nullable: false),
                    userTag = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userChannel", x => new { x.idChannel, x.userTag });
                    table.ForeignKey(
                        name: "FK_userChannel_Channel_idChannel",
                        column: x => x.idChannel,
                        principalTable: "Channel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userChannel_User_userTag",
                        column: x => x.userTag,
                        principalTable: "User",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_channelid",
                table: "Message",
                column: "channelid");

            migrationBuilder.CreateIndex(
                name: "IX_Message_username",
                table: "Message",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_userChannel_userTag",
                table: "userChannel",
                column: "userTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "userChannel");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
