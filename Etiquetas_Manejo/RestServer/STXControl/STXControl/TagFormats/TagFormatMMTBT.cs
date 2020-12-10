using ProductionData;
using STXControl.TagOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    class TagFormatMMTBT : ATagFormat
    {
        public TagFormatMMTBT(DMProductionOrder order)
        {
            if (order != null)
                this._order = order;
            this._multiplier = 2;
            TagOptionT1PF t1pf = new TagOptionT1PF();
            this._options.Add(t1pf);
            TagOptionT2SF t2sf = new TagOptionT2SF();
            if (int.Parse(this._order.Properties.AuthorisationTypeId) == 1)
            {
                t2sf.Position = 4;
            }
            this._options.Add(t2sf);
            this._dt.Columns.Add(new DataColumn(this._columnName, System.Type.GetType("System.String")));
        }

        protected override void generateOutput()
        {
            try
            {
                this._dt.Clear();
                this._result.Clear();
                int counter = this.countActiveOptions();

                foreach (CreateOrderIdentifiers dp in this._order.Identifiers)
                {
                    String[] temp;
                    String flockNo;
                    String runningNo;
                    String formattedTag;
                    String formattedTagBarcode;

                    temp = dp.FormattedTag.Split(' ');

                    flockNo = temp[1];
                    runningNo = temp[2];
                    if (temp.Length == 4)
                    {
                        runningNo += " " + temp[3];
                    }

                    if (int.Parse(this._order.Properties.AuthorisationTypeId) == 1)
                    {
                        formattedTag = dp.FormattedTag.Substring(3, dp.FormattedTag.Length - 3).Trim();
                    }
                    else
                    {
                        formattedTag = dp.FormattedTag.Trim();
                    }

                    formattedTagBarcode = dp.FormattedTag.Replace(" ", string.Empty);

                    for (int i = 0; i < this._multiplier; i++)
                    {
                        this.addValue(flockNo.Trim());
                        this.addValue(runningNo.Trim());
                    }

                    for (int i = 0; i < this._multiplier; i++)
                    {
                        this.addValue(formattedTag); // formattedTag without trimming
                    }

                    foreach (ATagOption op in this._options)
                    {
                        if (op.Active)
                        {
                            if (op.Position >= this._result.Count)
                                break;
                            
                            this.insertValue(op.Position + op.Offset, formattedTagBarcode);
                            op.Offset += this._multiplier * 3 + counter;
                        }
                    }
                }
                this.resetOptionOffset();
                foreach (String row in this._result)
                {
                    this._dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void resetOptionOffset()
        {
            foreach (ATagOption op in this._options)
            {
                op.Offset = 0;
            }
        }
    }
}
