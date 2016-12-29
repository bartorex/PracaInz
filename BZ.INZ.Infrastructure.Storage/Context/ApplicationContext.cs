using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model = BZ.INZ.Domain.Model;

namespace BZ.INZ.Infrastructure.Storage.Context {
    public class ApplicationContext : DbContext {
        public DbSet<Model.Query.Detail.JobOffer> JobOffers { get; set; }
        public DbSet<Model.Query.Detail.Employer> Employers { get; set; }

        //public ApplicationContext() : base("ApplicationStorage") { }

        //protected override void OnModelCreating(DbModelBuilder builder) {
        //    builder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(builder);
        //}
    }
}
