using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroMonitorGame
{
    public class NumberGame : INumberGame
    {
        private int _numberToCompare;

        public static readonly int _comparer = 5;

        public int Comparer
        {
            get { return _comparer; }
            set { value = _comparer; }
        }

        public int _difference;
        public int NumberToCompare
        {
            get
            {
                return _numberToCompare;
            }
            set
            {
                _numberToCompare = value;
            }
        }


        public int Calculate()
        {
            _difference = _comparer -_numberToCompare;

            return _difference;
        }

        public bool IsNumberValid()
        {
            if (_numberToCompare > _comparer || _numberToCompare < 0)
            {
                return false;
            }
            return true;
        }
    }

    public interface INumberGame
    {
        int Calculate();
        bool IsNumberValid();
        int NumberToCompare { get; set; }

        int Comparer { get; set; }
    }
}
