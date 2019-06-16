using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace EuroMonitorGame.IocContainer
{
    public class UnityRegistrationModule : IContainerRegistrationModule<IUnityContainer>
    {

        // Register dependencies in unity container
        public void Register(IUnityContainer container)
        {
            // register service locator
            container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
        }
    }
}
