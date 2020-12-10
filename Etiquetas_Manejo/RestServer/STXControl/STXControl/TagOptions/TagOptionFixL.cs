using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    class TagOptionFixL : ATagOption
    {
        private int _length = 5;

        public TagOptionFixL()
        {
            this._name = "Fixed Length";
        }

        public int Length
        {
            get
            {
                return this._length;
            }
            set
            {
                this._length = value;
            }
        }

        public string formatRunningNo(String runningNo)
        {
            try
            {
                String zeros = string.Empty;

                for (int i = 0; i < this._length; i++)
                    zeros += "0";

                return Convert.ToUInt64(runningNo).ToString(zeros).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
