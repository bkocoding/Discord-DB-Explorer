using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discord_DB_Explorer.Module.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permissions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sunucular",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sunucular", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Emojiler",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmojiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmojiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isGIF = table.Column<bool>(type: "bit", nullable: false),
                    SunucuID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emojiler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emojiler_Sunucular_SunucuID",
                        column: x => x.SunucuID,
                        principalTable: "Sunucular",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Kanallar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SunucuID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KanalAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanallar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kanallar_Sunucular_SunucuID",
                        column: x => x.SunucuID,
                        principalTable: "Sunucular",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SunucuUyeleri",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SunucuID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KullaniciID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RolID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunucuUyeleri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SunucuUyeleri_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SunucuUyeleri_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_SunucuUyeleri_Sunucular_SunucuID",
                        column: x => x.SunucuID,
                        principalTable: "Sunucular",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "EmojiKullanici",
                columns: table => new
                {
                    FavoruiteEmojisID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmojiKullanici", x => new { x.FavoruiteEmojisID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_EmojiKullanici_Emojiler_FavoruiteEmojisID",
                        column: x => x.FavoruiteEmojisID,
                        principalTable: "Emojiler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmojiKullanici_Kullanicilar_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KanalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KullaniciID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Kanallar_KanalID",
                        column: x => x.KanalID,
                        principalTable: "Kanallar",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Mesajlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmojiKullanici_UsersID",
                table: "EmojiKullanici",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Emojiler_SunucuID",
                table: "Emojiler",
                column: "SunucuID");

            migrationBuilder.CreateIndex(
                name: "IX_Kanallar_SunucuID",
                table: "Kanallar",
                column: "SunucuID");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_KanalID",
                table: "Mesajlar",
                column: "KanalID");

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_KullaniciID",
                table: "Mesajlar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_SunucuUyeleri_KullaniciID",
                table: "SunucuUyeleri",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_SunucuUyeleri_RolID",
                table: "SunucuUyeleri",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_SunucuUyeleri_SunucuID",
                table: "SunucuUyeleri",
                column: "SunucuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmojiKullanici");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "SunucuUyeleri");

            migrationBuilder.DropTable(
                name: "Emojiler");

            migrationBuilder.DropTable(
                name: "Kanallar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Sunucular");
        }
    }
}
