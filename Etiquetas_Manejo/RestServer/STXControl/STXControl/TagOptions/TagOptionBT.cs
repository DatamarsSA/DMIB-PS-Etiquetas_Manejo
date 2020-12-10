using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    class TagOptionBT : ATagOption
    {
        private int _repeat = 1;
        private bool _space = false;

        public TagOptionBT()
        {
            this._name = "Tag Button2";
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

        public bool Space
        {
            get
            {
                return this._space;
            }
            set
            {
                this._space = value;
            }
        }
    }
}
