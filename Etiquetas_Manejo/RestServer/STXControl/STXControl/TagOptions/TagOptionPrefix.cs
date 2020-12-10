using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    class TagOptionPrefix : ATagOption
    {
        private String _prefix = String.Empty;
        private bool _include = false;

        public TagOptionPrefix()
        {
            this._name = "Prefix";
        }

        public String Prefix
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

        public bool Include
        {
            get
            {
                return this._include;
            }
            set
            {
                this._include = value;
            }
        }
    }
}
