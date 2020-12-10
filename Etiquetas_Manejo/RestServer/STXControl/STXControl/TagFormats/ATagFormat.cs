using ProductionData;
using STXControl.TagOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    public abstract class ATagFormat
    {
        protected String _columnName = "Tagline";
        protected List<ATagOption> _options = new List<ATagOption>();
        protected List<String> _result = new List<String>();
        protected DataTable _dt = new DataTable();
        protected DMProductionOrder _order = null;
        protected int _multiplier = 0;


        public void insertValue(int index, String value)
        {
            try
            {
                int count = this._result.Count;
                if(index >= 0 && index < count)
                {
                    this._result.Insert(index, value);
                }else if(index == count)
                {
                    this._result.Add(value);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int countActiveOptions()
        {
            try
            {
                int counter = 0;
                foreach(ATagOption op in this._options)
                {
                    if (op.Active)
                    {
                        op.Offset = counter;
                        counter++;
                    }
                }
                return counter;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void addValue(String value)
        {
            try
            {
                this._result.Add(value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ATagOption> getOptions()
        {
            try
            {
                return this._options;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Multiplier
        {
            get
            {
                return this._multiplier;
            }
            set
            {
                if (value > 0 && value <= 6)
                {
                    this._multiplier = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Multiplier can only be 2 or 4!");
                }
            }
        }

        public List<String> print()
        {
            if(this._order != null)
                this.generateOutput();
            return this._result;
        }
        public DataTable getSource()
        {
            if(this._order != null)
                this.generateOutput();
            return this._dt;
        }

        abstract protected void generateOutput();
    }
}
