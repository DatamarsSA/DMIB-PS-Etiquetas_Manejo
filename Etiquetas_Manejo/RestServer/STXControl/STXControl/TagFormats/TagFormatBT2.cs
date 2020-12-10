using ProductionData;
using STXControl.TagOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    class TagFormatBT2 : ATagFormat
    {
        public TagFormatBT2(DMProductionOrder order)
        {
            this._multiplier = 1;
            if (order != null)
                this._order = order;
            TagOptionFixL fixedL = new TagOptionFixL();
            this._options.Add(fixedL);

            TagOptionPrefix prefix = new TagOptionPrefix();
            this._options.Add(prefix);

            TagOptionBT bt = new TagOptionBT();
            this._options.Add(bt);


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
                    String region;
                    String flockNo;
                    String checkNo = String.Empty;
                    String runningNo;
                    String formattedTag = String.Empty;

                    temp = dp.FormattedTag.Split(' ');
                    region = temp[0];
                    flockNo = temp[1];
                    runningNo = temp[2];
                    if (temp.Length == 4)
                        checkNo = temp[3];

                    foreach(ATagOption op in this._options)
                    {
                        if (op.GetType() == typeof(TagOptionFixL))
                        {
                            TagOptionFixL top = (TagOptionFixL)op;
                            runningNo = top.formatRunningNo(runningNo);
                        }
                        if (op.GetType() == typeof(TagOptionPrefix))
                        {
                            TagOptionPrefix top = (TagOptionPrefix)op;
                            if (top.Include)
                                formattedTag = top.Prefix;
                        }
                        else if (op.GetType() == typeof(TagOptionBT))
                        {
                            TagOptionBT bt = (TagOptionBT)op;
                            this._multiplier = bt.Repeat;
                            if (bt.Space)
                            {
                                if(checkNo.CompareTo(String.Empty) != 0)
                                    formattedTag += flockNo + " " + runningNo + " " + checkNo;
                                else
                                    formattedTag += flockNo + " " + runningNo;
                            }
                            else
                            {
                                if (checkNo.CompareTo(String.Empty) != 0)
                                    formattedTag += flockNo + runningNo + checkNo;
                                else
                                    formattedTag += flockNo + runningNo;
                            }
                        }
                    }                        

                    for (int i = 0; i < this._multiplier; i++)
                    {
                        this.addValue(formattedTag.Trim());
                    }
                }

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
    }
}
