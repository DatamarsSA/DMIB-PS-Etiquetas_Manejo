using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.TagOptions
{
    public abstract class ATagOption
    {
        protected String _name = String.Empty;
        protected int _offset = 0;
        protected int _position = 0;
        protected bool _active = false;

        public String Name
        {
            get
            {
                return this._name;
            }
        }

        public int Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }

        public int Offset
        {
            get
            {
                return this._offset;
            }
            set
            {
                this._offset = value;
            }
        }

        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                this._active = value;
            }
        }
    }
}
