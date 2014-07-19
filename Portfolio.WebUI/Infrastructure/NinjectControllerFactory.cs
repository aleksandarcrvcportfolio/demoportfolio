using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Abstract;

namespace Portfolio.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var mock = new Mock<IProjectRepository>();
            mock.Setup(m => m.Products).Returns(new List<Project> {
                new Project { Name = "Sample mvc", Category = "MVC" },
                new Project { Name = "Sample sharepoint", Category = "Sharepoint" },
                new Project { Name = "Sample WPF", Category = "WPF" }
                }.AsQueryable());
            ninjectKernel.Bind<IProjectRepository>().ToConstant(mock.Object);
        }
    }
}