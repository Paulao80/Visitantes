namespace GuaritaVisitantes.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GuaritaVisitantes.DAL.Context.GuaritaVisitantesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GuaritaVisitantes.DAL.Context.GuaritaVisitantesContext";
        }

        protected override void Seed(Context.GuaritaVisitantesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
