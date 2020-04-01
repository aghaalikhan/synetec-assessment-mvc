using Autofac;
using Autofac.Integration.Mvc;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using System.Reflection;

namespace InterviewTestTemplatev2.App_Start
{
    public static class IoCConfig
    {
        public static ContainerBuilder ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterInstance(new EmployeesDbContext());
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<BonusPoolService>().As<IBonusPoolService>().SingleInstance();
            return builder;
        }
    }
}