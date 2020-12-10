using ProductionData;
using STXControl.TagOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    class TagFormatTST : ATagFormat
    {
        public TagFormatTST(DMProductionOrder order)
        {
            this._multiplier = 2;
            if (order != null)
                this._order = order;

            TagOptionT1PF t1pf = new TagOptionT1PF();
            this._options.Add(t1pf);
            TagOptionT1PM t1pm = new TagOptionT1PM();
            this._options.Add(t1pm);
            TagOptionSample tsample = new TagOptionSample();
            this._options.Add(tsample);
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

                    temp = dp.FormattedTag.Split(' ');

                    flockNo = temp[1];
                    runningNo = temp[2];
                    if (temp.Length == 4)
                    {
                        runningNo += " " + temp[3];
                    }

                    formattedTag = dp.FormattedTag.Replace(" ", string.Empty);

                    for (int i = 0; i < this._multiplier; i++)
                    {
                        this.addValue(flockNo.Trim());
                        this.addValue(runningNo.Trim());
                    }

                    int offset6 = 7;

                    foreach (ATagOption op in this._options)
                    {
                        if (op.Active)
                        {
                            this.insertValue(op.Position + op.Offset, formattedTag);
                            if (this._multiplier == 6)
                            {
                                this.insertValue(op.Position + op.Offset + offset6, formattedTag);
                                offset6++;
                                op.Offset += counter;
                            }
                            op.Offset += this._multiplier * 2 + counter;
                        }
                    }
                }
                this.resetOptionOffset();
                foreach (String row in this._result)
                {
                    this._dt.Rows.Add(row.Trim());
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
