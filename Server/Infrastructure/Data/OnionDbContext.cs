using Microsoft.EntityFrameworkCore;
using OnionServer.Domain.Models;

namespace OnionServer.Infrastructure.Data
{
    public class OnionDbContext : DbContext
    {
        public OnionDbContext(DbContextOptions<OnionDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasKey(cliente => cliente.NumeroDoc);

            modelBuilder.Entity<Pedido>()
                .HasOne(pedido => pedido.Cliente)
                .WithMany(cliente => cliente.Pedidos)
                .HasForeignKey(pedido => pedido.ClienteNumeroDoc);


            modelBuilder.Entity<PedidoProduto>()
                .HasKey(pedidoProduto => new { pedidoProduto.PedidoId, pedidoProduto.ProdutoId });

            modelBuilder.Entity<PedidoProduto>()
                .HasOne(pedidoProduto => pedidoProduto.Pedido)
                .WithMany(pedido => pedido.PedidosProdutos)
                .HasForeignKey(pedidoProduto => pedidoProduto.PedidoId);

            modelBuilder.Entity<PedidoProduto>()
                .HasOne(pedidoProduto => pedidoProduto.Produto)
                .WithMany(produto => produto.PedidosProdutos)
                .HasForeignKey(pedidoProduto => pedidoProduto.ProdutoId);


            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);
        }
    }
}
