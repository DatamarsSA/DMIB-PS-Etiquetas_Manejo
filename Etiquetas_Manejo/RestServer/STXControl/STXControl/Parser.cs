using ProductionData;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace STXControl
{
    public class Parser
    {
        private string _filepath = string.Empty;
        private List<ParseItem> _parseItems = new List<ParseItem>();
        private DMProductionOrder _order;

        public Parser(string filepath, ref DMProductionOrder order)
        {
            this._filepath = filepath;
            this._order = order;
            this.readFile();
        }

        public bool Parse()
        {
            try
            {
                string country = string.Empty;
                string regio = string.Empty;
                string flockNo = string.Empty;
                string runningNo = string.Empty;
                string checkDigit = string.Empty;
                bool ret = false;

                int authtype = int.Parse(this._order.Properties.AuthorisationTypeId);
                ParseItem pi = this._parseItems.Find(x => x.Authority == authtype);

                if(pi != null)
                {
                    Regex r = new Regex(pi.Pattern, RegexOptions.IgnoreCase);

                    foreach (CreateOrderIdentifiers identifier in this._order.Identifiers)
                    {
                        Match match = r.Match(identifier.FormattedTag);

                        if (match.Success)
                        {
                            if(pi.CountryLength != 0)
                             country = match.Value.Substring(pi.CountryIndex, pi.CountryLength);
                            if (pi.RegioLength != 0)
                            {
                                regio = match.Value.Substring(pi.RegioIndex, pi.RegioLength);
                                identifier.Region = int.Parse(regio);
                            }
                            if (pi.FlockNoLength != 0)
                                flockNo = match.Value.Substring(pi.FlockNoIndex, pi.FlockNoLength);
                            if (pi.RunningNoLength != 0)
                                runningNo = match.Value.Substring(pi.RunningNoIndex, pi.RunningNoLength);
                            if (pi.CheckDigitLength != 0)
                                checkDigit = match.Value.Substring(pi.CheckDigitIndex, pi.CheckDigitLength);

                            identifier.FormattedTag = country + regio + " " + flockNo + " ";
                            if (pi.RunningNoIndex > pi.CheckDigitIndex)
                            {
                                identifier.FormattedTag += checkDigit + runningNo;
                            }
                            else
                            {
                                identifier.FormattedTag += runningNo + " " + checkDigit;
                            }
                            identifier.FormattedTag.Trim();
                            ret = true;
                        }
                        else { break; } // might be better to throw an exception here
                    }
                }
                else
                {
                    throw new Exception("There is no parsing rule for AuthorisationTypeId: " + authtype.ToString() + "!");
                }
                
                if (!ret)
                    throw new Exception("The parsing rule for AuthorisationTypeId: " + authtype.ToString() + " does not match!");

                return true;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void readFile()
        {
            try
            {
                string line = string.Empty;
             
                using(StreamReader sr = new StreamReader(this._filepath, Encoding.Default))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        ParseItem item = new ParseItem(line);
                        this._parseItems.Add(item);
                    }
                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
