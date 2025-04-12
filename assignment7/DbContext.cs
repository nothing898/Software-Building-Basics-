using Microsoft.EntityFrameworkCore;

namespace Homework1
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 配置连接字符串，请根据你的 MySQL 配置进行修改
            var connectionString = "server=localhost;port=3306;database=OrderDb;user=root;password=@QJgzdxwswj39;";
            // 使用 Pomelo MySQL Provider 自动检测服务器版本
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 为 Order 指定主键
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            // 为 OrderDetails 指定主键
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => od.OrderDetailsId);

            // 配置一对多关系：一个 Order 拥有多个 OrderDetails
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetailsList)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
