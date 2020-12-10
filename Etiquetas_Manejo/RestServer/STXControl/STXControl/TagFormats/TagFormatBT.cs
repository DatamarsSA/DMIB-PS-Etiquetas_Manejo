using ProductionData;
using System;
using STXControl.TagOptions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace STXControl.TagFormats
{
    class TagFormatBT : ATagFormat
    {
        public TagFormatBT(DMProductionOrder order)
        {
            this._multiplier = 2;
            if (order != null)
                this._order = order;

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
                    String formattedTag;

                    if (int.Parse(this._order.Properties.AuthorisationTypeId) == 1)
                        formattedTag = dp.FormattedTag.Substring(3, dp.FormattedTag.Length - 3);
                    else
                        formattedTag = dp.FormattedTag; //.Replace(" ", string.Empty);

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
