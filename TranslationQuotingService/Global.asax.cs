namespace TranslationQuotingService
{
    using System;
    using Microsoft.Practices.Unity;
    using Business;

    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }

    public class Global : System.Web.HttpApplication, IContainerAccessor
    {
        private static IUnityContainer container;
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
            private set
            {
                container = value;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get
            {
                return Container;
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IManageQuote, ManageQuote>();
            Container = container;
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