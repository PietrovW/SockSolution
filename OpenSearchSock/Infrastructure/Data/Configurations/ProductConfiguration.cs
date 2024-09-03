using OpenSearchSock.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OpenSearchSock.Infrastructure.Data.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.EAN).IsRequired();
        builder.Property(x => x.Name).IsRequired();
    }
}
