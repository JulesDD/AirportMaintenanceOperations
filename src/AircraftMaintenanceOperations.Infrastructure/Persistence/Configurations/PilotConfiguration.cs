using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftMaintenanceOperations.Infrastructure.Persistence.Configurations;

public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
{
    public void Configure(EntityTypeBuilder<Pilot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Aircraft>()
            .WithOne(a => a.CurrentPilot)
            .HasForeignKey<Aircraft>(x => x.CurrentPilotId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
