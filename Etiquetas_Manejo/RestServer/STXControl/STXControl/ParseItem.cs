using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace STXControl
{
    public class ParseItem
    {
        private char _itemSplitter = ';';
        private char _valueSplitter = ':';
        private string _line = string.Empty;
        private string _pattern = string.Empty;
        private int _authority = 0;
        private string[] _country;
        private string[] _regio;
        private string[] _flockNo;
        private string[] _checkDigit;
        private string[] _runningNo;

        public ParseItem(string line)
        {
            this._line = line;
            this.generateItem();
        }

        private void generateItem()
        {
            try
            {
                string[] values = this._line.Split(this._itemSplitter);
                this._authority = int.Parse(values[0]);
                this._pattern = values[1];
                this._country = values[2].Split(this._valueSplitter);
                this._regio = values[3].Split(this._valueSplitter);
                this._flockNo = values[4].Split(this._valueSplitter);
                this._runningNo = values[5].Split(this._valueSplitter);
                this._checkDigit = values[6].Split(this._valueSplitter);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Authority
        {
            get
            {
                return this._authority;
            }
        }

        public string Pattern
        {
            get
            {
                return this._pattern;
            }
        }

        public int CountryIndex
        {
            get
            {
                return int.Parse(this._country[0]);
            }
        }

        public int CountryLength
        {
            get
            {
                return int.Parse(this._country[1]);
            }
        }

        public int RegioIndex
        {
            get
            {
                return int.Parse(this._regio[0]);
            }
        }

        public int RegioLength
        {
            get
            {
                return int.Parse(this._regio[1]);
            }
        }

        public int FlockNoIndex
        {
            get
            {
                return int.Parse(this._flockNo[0]);
            }
        }

        public int FlockNoLength
        {
            get
            {
                return int.Parse(this._flockNo[1]);
            }
        }

        public int RunningNoIndex
        {
            get
            {
                return int.Parse(this._runningNo[0]);
            }
        }

        public int RunningNoLength
        {
            get
            {
                return int.Parse(this._runningNo[1]);
            }
        }

        public int CheckDigitIndex
        {
            get
            {
                return int.Parse(this._checkDigit[0]);
            }
        }

        public int CheckDigitLength
        {
            get
            {
                return int.Parse(this._checkDigit[1]);
            }
        }
    }
}
