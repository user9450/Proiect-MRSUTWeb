using System.Data.Entity;
using Domain.Entities.Orders;
using System.Reflection.Emit;
using eUseControl.Domain.Entities.Orders;

namespace eUseControl.BusinessLogic.DBModel
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("eUseControl")
        {
            Database.SetInitializer<OrderContext>(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            base.OnModelCreating(modelBuilder); // Apelarea metodei de bază
        }
    }
}