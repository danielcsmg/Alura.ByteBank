using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.ByteBank.Dados.Migrations
{
    public partial class PopularBancoByteBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `agencia` VALUES (null,123,'Agencia Central','Rua: Pedro Alvares Cabral,63','1447c0e7-c328-47e0-a39f-116e5ab597b3');");
            migrationBuilder.Sql("INSERT INTO `agencia` VALUES(null,321, 'Agencia Flores', 'Rua: Odete Roitman, 84', 'a05e08ca-e501-4719-87c4-a7f95c7f8f15');");
            
            migrationBuilder.Sql("INSERT INTO `cliente` VALUES (null,'307.522.040-09','André Silva','Developer','531e5270-8a80-4a2c-8b20-f10182f728fc');");
            migrationBuilder.Sql("INSERT INTO `cliente` VALUES (null,'510.711.260-91','João Pedro','Developer','20cd1c01-5fbf-40b7-b41b-0341bd38fc32');");
            migrationBuilder.Sql("INSERT INTO `cliente` VALUES (null,'224.182.250-70','José Neves','Atleta De Poker','20cd1c01-5fbf-40b7-b41b-0341bd38fc32');");

            migrationBuilder.Sql("INSERT INTO `conta_corrente` VALUES(null,4159, 1, 1, 300, '1001b6f8-4fdb-44dd-a63d-850e6bf5e1d3', '00000000-0000-0000-0000-000000000000');");
            migrationBuilder.Sql("INSERT INTO `conta_corrente` VALUES(null,1789, 2, 2, 400, 'fd3a2250-27d9-48f4-ae89-9eea10a93396', '00000000-0000-0000-0000-000000000000');");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM `cliente` where id<>null ");
            migrationBuilder.Sql("Delete FROM `agencia` where id<>null ");
            migrationBuilder.Sql("Delete FROM `conta_corrente` where id<>null ");
            
        }
    }
}

//migrationBuilder.Sql("ALTER TABLE tabela AUTO_INCREMENT = 1; ");