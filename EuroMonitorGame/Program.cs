using EuroMonitorGame.IocContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace EuroMonitorGame
{
    class Program
    {
        private static IMessageGenerator _messageGenerator { get; set; }
        private static INumberGame _numberGame { get; set; }
        static void Main(string[] args)
        {
            var container = UnityConfig.GetUnityContainer();
            _numberGame = (INumberGame)container.Resolve(typeof(INumberGame));
            _messageGenerator = (IMessageGenerator)container.Resolve(typeof(IMessageGenerator),
                           new ResolverOverride[]
                           {
                              new ParameterOverride("numberGame", _numberGame)
                           });

            while (true)
            {
                Console.WriteLine(_messageGenerator.GetMainMessage());

                int number = -1;
                int.TryParse(Console.ReadLine().Trim(), out number);
                _numberGame.NumberToCompare = number;


                Console.WriteLine(_messageGenerator.GetResultMessage());
                Console.WriteLine(" Type quit to end game or press any key to continue");

                string playAgainString = Console.ReadLine().Trim();

                if (playAgainString.ToLower().Equals("quit"))
                {
                    break;
                }
            }

        }
    }
}
