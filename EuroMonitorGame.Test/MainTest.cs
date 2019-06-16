using EuroMonitorGame.IocContainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace EuroMonitorGame.Test
{
    [TestClass]
    public class MainTest : DI_TEST
    {

        [TestMethod]
        public void Input_Must_Be_Greater_Than_Or_Equals_Zero_And_Must_Be_Less_Than_the_Comaprer()
        {
            var service = this.GetService<INumberGame>();
            var result = service.IsNumberValid();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DI_For_Objects_With_Unity()
        {
            var numberService = this.GetService<INumberGame>();
            var messageService = this.GetService<IMessageGenerator>();
            Assert.IsNotNull(numberService);
            Assert.IsNotNull(messageService);
        }

        [TestMethod]
        public void Test_Valid_Numbers()
        {
            var container = UnityConfig.GetUnityContainer();
            var numberGame = (INumberGame)container.Resolve(typeof(INumberGame));
            var messageGenerator = (IMessageGenerator)container.Resolve(typeof(IMessageGenerator),
                             new ResolverOverride[]
                             {
                              new ParameterOverride("numberGame", numberGame)
                             });
            int[] numberstoCompare = new int[] {0, 1, 2, 3, 4, 5 };

            foreach (var item in numberstoCompare)
            {
                numberGame.NumberToCompare = item;
                Assert.AreEqual(numberGame.Calculate() >= 0 , numberGame.Calculate() <= numberGame.Comparer);

            }

        }
    }
}
