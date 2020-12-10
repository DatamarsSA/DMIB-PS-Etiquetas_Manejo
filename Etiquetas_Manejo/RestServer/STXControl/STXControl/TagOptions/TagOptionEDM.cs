using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    class TagOptionEDM : ATagOption
    {
        private int _repeat = 1;

        public TagOptionEDM()
        {
            this._name = "EDM";
        }

        public int Repeat
        {
            get
            {
                return this._repeat;
            }
            set
            {
                this._repeat = value;
            }
        }
    }
}
