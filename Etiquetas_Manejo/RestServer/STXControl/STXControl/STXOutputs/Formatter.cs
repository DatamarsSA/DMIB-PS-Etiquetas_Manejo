using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STXControl.STXOutputs
{
    public class Formatter
    {
        private Species _species;
        private Driver _driver;

        public Formatter(Species species, Driver driver)
        {
            this._species = species;
            this._driver = driver;
        }

        public Species Species
        {
            get
            {
                return this._species;
            }
            set
            {
                this._species = value;
            }
        }

        public Driver OutputControlName
        {
            get
            {
                return this._driver;
            }
            set
            {
                this._driver = value;
            }
        }
    }
}
