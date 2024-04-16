using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P238MovieAPi.Entities;

namespace P238MovieAPi.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
        }
    }
}
