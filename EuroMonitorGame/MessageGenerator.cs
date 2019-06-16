using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorGame
{
    public class MessageGenerator : IMessageGenerator
    {
        private INumberGame _numberGame;
        public MessageGenerator(INumberGame numberGame)
        {
            _numberGame = numberGame;
        }
        public string GetMainMessage()
        {
            return $"Please enter a number less than  {_numberGame.Comparer}";
        }

        public string GetResultMessage()
        {

            if (!_numberGame.IsNumberValid())
            {
                return $"Invalid number range! Number must be between 0 and {_numberGame.Comparer}";
            }
            else
            {
                return $" The number required to get to {_numberGame.Comparer} is {_numberGame.Calculate()}";
            }
        }
    }


    public interface IMessageGenerator
    {
        string GetMainMessage();
        string GetResultMessage();
    }
}
