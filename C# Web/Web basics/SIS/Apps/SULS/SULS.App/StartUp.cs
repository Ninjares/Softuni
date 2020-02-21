namespace SULS.App
{
    using Data;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.Services;
    using System.Collections.Generic;

    public class StartUp : IMvcApplication
    {

        public void Configure(IList<Route> routeTable)
        {
            using (var db = new SULSContext())
            {
                db.Database.EnsureCreated();
            }
        }


        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersServices, UserServices>();
            serviceCollection.Add<IProblemServices, ProblemsServices>();
            serviceCollection.Add<ISubmissonServices, SubmissionServices>();
        }
    }
}