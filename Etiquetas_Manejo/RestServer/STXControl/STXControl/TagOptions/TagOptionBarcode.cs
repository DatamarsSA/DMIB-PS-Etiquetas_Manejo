using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    class TagOptionBarcode : ATagOption
    {
        private string _barcodeNr;
        private string _barcodeRunningNr;
        private string _prefix;
        private bool _isLeadingPrefix;
        private bool _isLeadingRegion;
        private string _firstRunningNo;
        private long _counter;
        private int _multiplier;
        private int _region;

        public TagOptionBarcode()
        {
            this._name = "Barcode";
            this._position = 20;
            this._prefix = string.Empty;
            this._isLeadingPrefix = false;
            this._isLeadingRegion = false;
            this._counter = 0;
            this._region = -1;
            this._multiplier = 1;
        }

        public string BarcodeNr
        {
            get
            {
                return this._barcodeNr;
            }
            set
            {
                this._barcodeNr = string.Empty;

                if (this._isLeadingPrefix)
                    this._barcodeNr = this._prefix;

                if (this._isLeadingRegion && this._region != -1)
                    this._barcodeNr += this._region;
                
                this._barcodeNr += value;
            }
        }

        public string RunningBarcodeNr
        {
            get
            {
                return this._barcodeRunningNr;
            }
            set
            {
                this._barcodeRunningNr = value;
            }
        }

        public string FirstRunningBarcodeNr
        {
            get
            {
                return this._firstRunningNo;
            }
            set
            {
                this._firstRunningNo = value;
            }
        }

        public int Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        public long Counter
        {
            set
            {
                this._counter = value;
            }
        }

        public int Multiplier
        {
            set
            {
                this._multiplier = value;
            }
        }

        //public void decBarcodeRunningNr()
        //{
        //    try
        //    {
        //        String zeros = string.Empty;

        //        for (int i = 0; i < this._barcodeRunningNr.Length; i++)
        //            zeros += "0";

        //        this._counter--;
        //        long temp = this._position * this._counter + 1;
        //        if (this._multiplier == 2 && this._position == 20)
        //            temp += 10;
                
        //        this._barcodeRunningNr = temp.ToString(zeros);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public void decBarcodeRunningNr()
        {
            try
            {
                String zeros = string.Empty;

                for (int i = 0; i < this._barcodeRunningNr.Length; i++)
                    zeros += "0";

                this._counter--;
                long temp = 0;

                if (this._counter < 0)
                    temp = long.Parse(this._firstRunningNo);
                else
                    temp = long.Parse(this._firstRunningNo) + (this._counter * this._position);
                
                if (this._multiplier == 2 && this._position == 20)
                    temp += 10;

                this._barcodeRunningNr = temp.ToString(zeros).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Prefix
        {
            get
            {
                return this._prefix;
            }
            set
            {
                this._prefix = value;
            }
        }

        public bool LeadingPrefix
        {
            get
            {
                return this._isLeadingPrefix;
            }
            set
            {
                this._isLeadingPrefix = value;
            }
        }

        public bool LeadingRegio
        {
            get
            {
                return this._isLeadingRegion;
            }
            set
            {
                this._isLeadingRegion = value;
            }
        }
    }
}
