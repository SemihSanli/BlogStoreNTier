using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogStore.DataAccessLayer.Migrations
{
    public partial class AddSlugColumnAndGenerateValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Önce Slug kolonunu ekle
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            // 2. Mevcut makaleler için slug oluştur
            migrationBuilder.Sql(@"
                UPDATE Articles 
                SET Slug = LOWER(
                    REPLACE(
                        REPLACE(
                            REPLACE(
                                REPLACE(
                                    REPLACE(
                                        REPLACE(
                                            REPLACE(
                                                REPLACE(
                                                    REPLACE(
                                                        REPLACE(
                                                            REPLACE(
                                                                REPLACE(
                                                                    REPLACE(
                                                                        REPLACE(ArticleTitle, ' ', '-'),
                                                                    'ı', 'i'),
                                                                'ğ', 'g'),
                                                            'ü', 'u'),
                                                        'ş', 's'),
                                                    'ö', 'o'),
                                                'ç', 'c'),
                                            'İ', 'i'),
                                        'Ğ', 'g'),
                                    'Ü', 'u'),
                                'Ş', 's'),
                            'Ö', 'o'),
                        'Ç', 'c'),
                    '.', '')
                )
                WHERE Slug IS NULL OR Slug = '';
            ");

            // 3. Özel karakterleri temizle
            migrationBuilder.Sql(@"
                UPDATE Articles 
                SET Slug = REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Slug, '!', ''), '?', ''), ',', ''), ':', ''), ';', '')
                WHERE Slug LIKE '%[!?,:;]%';
            ");

            // 4. Birden fazla tire varsa tek tire yap
            migrationBuilder.Sql(@"
                UPDATE Articles 
                SET Slug = REPLACE(REPLACE(REPLACE(Slug, '---', '-'), '--', '-'), '--', '-')
                WHERE Slug LIKE '%-%';
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Articles");
        }
    }
}