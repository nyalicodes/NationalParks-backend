using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShaCompanyName.ShaProjectName.Migrations
{
    [Migration(20210610122100)]
    public class M20210610122100 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Npo_NationalParks")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithColumn("Name").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Established").AsDateTime().Nullable()
                .WithColumn("AddressLine1").AsString().Nullable()
                .WithColumn("AddressLine2").AsString().Nullable()
                .WithColumn("AddressLine3").AsString().Nullable()
                .WithColumn("Suburb").AsString().Nullable()
                .WithColumn("Town").AsString().Nullable()
                .WithColumn("POBox").AsString().Nullable()
                .WithColumn("FullAddress").AsString().Nullable();
        }

    }
}
