using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class Atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conta_corrente_agencia_AgenciaId",
                table: "conta_corrente");

            migrationBuilder.DropForeignKey(
                name: "FK_conta_corrente_cliente_ClienteId",
                table: "conta_corrente");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "conta_corrente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgenciaId",
                table: "conta_corrente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_conta_corrente_agencia_AgenciaId",
                table: "conta_corrente",
                column: "AgenciaId",
                principalTable: "agencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_conta_corrente_cliente_ClienteId",
                table: "conta_corrente",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_conta_corrente_agencia_AgenciaId",
                table: "conta_corrente");

            migrationBuilder.DropForeignKey(
                name: "FK_conta_corrente_cliente_ClienteId",
                table: "conta_corrente");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "conta_corrente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgenciaId",
                table: "conta_corrente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_conta_corrente_agencia_AgenciaId",
                table: "conta_corrente",
                column: "AgenciaId",
                principalTable: "agencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_conta_corrente_cliente_ClienteId",
                table: "conta_corrente",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
