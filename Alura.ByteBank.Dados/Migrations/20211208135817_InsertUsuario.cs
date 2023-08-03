using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class InsertUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `usuario` VALUES (null,'andre@email.com','andre@email.com','0B267E19390CBE8D406F49C2D287473DDB60014B2E1588F431C6F2409511B8D6');");//senha01
            migrationBuilder.Sql("INSERT INTO `usuario` VALUES(null,'maria@email.com', 'maria@email.com', '8BA689219A79BBFB161F028A1C57CB02BB58241915D8EB53A7B6C347F64A8394');");//senha02
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
