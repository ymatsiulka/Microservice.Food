using Microservice.Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Food.Infrastructure.Persistence.Configuration;

public sealed class OrderProductEntityTypeConfiguration : IEntityTypeConfiguration<OrderProductEntity>
{
    public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
    {
        builder.ToTable("OrderProduct");
    }
}