using ProductionData;
using STXControl.TagOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    class TagFormatET : ATagFormat
    {
        public TagFormatET(DMProductionOrder order)
        {
            this._multiplier = 1;
            if (order != null)
                this._order = order;
            TagOptionPrefix prefix = new TagOptionPrefix();
            this._options.Add(prefix);

            TagOptionFixL fixedL = new TagOptionFixL();
            this._options.Add(fixedL);

            TagOptionTFS tfs = new TagOptionTFS();
            this._options.Add(tfs);

            TagOptionBarcode bc = new TagOptionBarcode();
            bc.Position = 10;
            this._options.Add(bc);

            this._dt.Columns.Add(new DataColumn(this._columnName, System.Type.GetType("System.String")));
        }

        protected override void generateOutput()
        {
            try
            {
                this._dt.Clear();
                this._result.Clear();
                int lineMulitplier = 2;
                bool bCheckNo = false;
                bool firstRunningNo = true;

                foreach (CreateOrderIdentifiers dp in this._order.Identifiers)
                {
                    String[] temp;
                    String flockNo;
                    String runningNo;
                    String checkNo = String.Empty;
                    String formattedTag;
                    String barcodeformattedTag;

                    temp = dp.FormattedTag.Split(' ');
                    flockNo = temp[1];
                    runningNo = temp[2];
                    if (temp.Length == 4)
                    {
                        checkNo = temp[3];
                        bCheckNo = true;
                        lineMulitplier = 3;
                    }

                    formattedTag = String.Empty;
                    barcodeformattedTag = flockNo;


                    formattedTag = flockNo;
                    foreach (ATagOption op in this._options)
                    {
                        if (op.Active)
                        {
                            if (op.GetType() == typeof(TagOptionPrefix))
                            {
                                TagOptionPrefix top = (TagOptionPrefix)op;
                                if (top.Include)
                                    if (bCheckNo)
                                        formattedTag = top.Prefix.Substring(2, 1) + flockNo;
                                    else
                                        formattedTag = top.Prefix + flockNo;
                                else
                                    formattedTag = flockNo;
                            }
                            if (op.GetType() == typeof(TagOptionFixL))
                            {
                                TagOptionFixL top = (TagOptionFixL)op;
                                runningNo = top.formatRunningNo(runningNo);
                            }
                            if (op.GetType() == typeof(TagOptionBarcode))
                            {
                                TagOptionBarcode top = (TagOptionBarcode)op;
                                
                                if (firstRunningNo)
                                {
                                    top.FirstRunningBarcodeNr = runningNo;
                                    top.Region = dp.Region;
                                    firstRunningNo = false;
                                }
                                top.BarcodeNr = barcodeformattedTag;
                                top.RunningBarcodeNr = runningNo;
                            }

                        }
                    }

                    for (int i = 0; i < this._multiplier; i++)
                    {
                        this.addValue(formattedTag.Trim());
                        this.addValue(runningNo.Trim());
                        if (checkNo.CompareTo(String.Empty) != 0)
                            this.addValue(checkNo.Trim());
                    }
                }

                foreach (ATagOption op in this._options)
                {
                    if (op.Active)
                    {
                        if (op.GetType() == typeof(TagOptionBarcode))
                        {
                            TagOptionBarcode top = (TagOptionBarcode)op;
                            int counter = this._result.Count / (top.Position * this._multiplier * lineMulitplier);
                            top.Counter = counter;
                            
                            for (int i = this._result.Count; i >= 1; i--)
                            {
                                if (i > 0 && (i % (top.Position * this._multiplier * lineMulitplier)) == 0)
                                {
                                    top.decBarcodeRunningNr();
                                    this.insertValue(i,top.BarcodeNr + top.RunningBarcodeNr);
                                    this.insertValue(i + 1, top.RunningBarcodeNr);
                                }
                                else if (counter == 0 && i == this._result.Count)
                                {
                                    top.decBarcodeRunningNr();
                                    this.insertValue(i, top.BarcodeNr + top.RunningBarcodeNr);
                                    this.insertValue(i + 1, top.RunningBarcodeNr);
                                }
                            }
                        }
                    }
                }

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
    }
}
