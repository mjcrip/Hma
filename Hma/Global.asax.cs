using Autofac;
using Autofac.Integration.Web;
using Hma.Core.Interfaces;
using Hma.Core.Services;
using Hma.Infra.Domains.BloggingContext;
using Hma.Infra.Repositories;
using System;

namespace Hma
{
	public class Global : System.Web.HttpApplication, IContainerProviderAccessor
	{
		// Provider that holds the application container.
		static IContainerProvider _containerProvider;

		// Instance property that will be used by Autofac HttpModules
		// to resolve and inject dependencies.
		public IContainerProvider ContainerProvider
		{
			get { return _containerProvider; }
		}
		protected void Application_Start(object sender, EventArgs e)
		{
			// Build up your application container and register your dependencies.
			var builder = new ContainerBuilder();
			builder.RegisterType<BloggingService>().InstancePerLifetimeScope();
			builder.RegisterType<HtmlGeneratorService>().InstancePerLifetimeScope();
			builder.RegisterType<BloggingContext>().InstancePerLifetimeScope();
			builder.RegisterType<BaseContextRepository<BloggingContext>>().As<IEntityContextRepository<IEntityContext>>().InstancePerLifetimeScope();
			// ... continue registering dependencies...

			// Once you're done registering things, set the container
			// provider up with your registrations.
			_containerProvider = new ContainerProvider(builder.Build());
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}