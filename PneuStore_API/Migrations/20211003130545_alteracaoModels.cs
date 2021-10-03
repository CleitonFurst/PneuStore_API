using Microsoft.EntityFrameworkCore.Migrations;

namespace PneuStore_API.Migrations
{
    public partial class alteracaoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cart_cartId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Cart_CartId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedido_PedidoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "cartId",
                table: "Pedido",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_cartId",
                table: "Pedido",
                newName: "IX_Pedido_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartNome",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Produtos_ProdutoId",
                table: "Pedido",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Cart_CartId",
                table: "Produtos",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Produtos_ProdutoId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Usuarios_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Cart_CartId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_UsuarioId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "CartNome",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Pedido",
                newName: "cartId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ProdutoId",
                table: "Pedido",
                newName: "IX_Pedido_cartId");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cart_cartId",
                table: "Pedido",
                column: "cartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Cart_CartId",
                table: "Produtos",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedido_PedidoId",
                table: "Produtos",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
