using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using System.Configuration;
using Unity.Resolution;
using Unity.Injection;
using Unity.Builder;

namespace EuroMonitorGame.IocContainer
{
    public abstract class DependencyInjectionServiceLocator<TContainer> : IServiceLocator
    {
        // DI container
        protected TContainer Container { get; private set; }
        protected DependencyInjectionServiceLocator(TContainer container)
        {
            Container = container;
        }

        public virtual T Get<T>()
        {
            return Get<T>(Container);
        }

        // Get service instance based on container specific logic

        protected abstract T Get<T>(TContainer container);

    }

    public interface IServiceLocator
    {
        T Get<T>();
    }
    public interface IContainerRegistrationModule<T>
    {
        void Register(T container);
    }
}
