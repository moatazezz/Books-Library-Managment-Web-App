using Autofac;
using Autofac.Integration.Mvc;
using BLL.Mapping;
using BLL.Services;
using BLL.VM;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<Repository<Books>>().As<IRepository<Books>>();
            builder.RegisterType<BooksService>().As<IBooksService>();
            builder.RegisterType<UnitOfWork<Books>>().As<IUnitOfWork<Books>>();

            builder.RegisterType<Repository<Categories>>().As<IRepository<Categories>>();
            builder.RegisterType<CategoriesService>().As<ICategoriesService>();
            builder.RegisterType<UnitOfWork<Categories>>().As<IUnitOfWork<Categories>>();

            builder.RegisterType<Repository<BorrowType>>().As<IRepository<BorrowType>>();
            builder.RegisterType<BorrowTypeService>().As<IBorrowTypeService>();
            builder.RegisterType<UnitOfWork<BorrowType>>().As<IUnitOfWork<BorrowType>>();

            builder.RegisterType<Repository<Borrowers>>().As<IRepository<Borrowers>>();
            builder.RegisterType<Service<Borrowers,BorrowersVM>>().As<IService<Borrowers, BorrowersVM>>();
            builder.RegisterType<UnitOfWork<Borrowers>>().As<IUnitOfWork<Borrowers>>();

            builder.RegisterType<Repository<BorrowReturnAction>>().As<IRepository<BorrowReturnAction>>();
            builder.RegisterType<BorrowReturnActionService>().As<IBorrowReturnActionService>();
            builder.RegisterType<UnitOfWork<BorrowReturnAction>>().As<IUnitOfWork<BorrowReturnAction>>();

            builder.RegisterType<Mapping>().As<IMapping>();
            builder.RegisterType<LibraryContext>().InstancePerRequest();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}