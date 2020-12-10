using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ProductionData
{
    [DataContract]
    public class FSproductionItems
    {
        private int lineNumber;
        private int auth_retagging;

        [DataMember(Name = "LineNumber", IsRequired = false)]
        //public Nullable<int> LineNumber { get; set; }
        public int? LineNumber
        {
            set
            {
                if (value.HasValue)
                {
                    this.lineNumber = value.Value;
                } else
                {
                    this.lineNumber = -1;
                }
            }
            get
            {
                return lineNumber;
            }
        }

        [DataMember(Name = "AuthCode", IsRequired = false)]
        public String AuthCode { get; set; }

        [DataMember(Name = "AuthType", IsRequired = false)]
        public String AuthType { get; set; }

        [DataMember(Name = "Auth_retagging", IsRequired = false)]
        public int? Auth_retagging
        {
            set
            {
                if (value.HasValue)
                {
                    this.auth_retagging = value.Value;
                }
                else
                {
                    this.auth_retagging = 0;
                }
            }
            get
            {
                return auth_retagging;
            }
        }

        [DataMember(Name = "LFcode", IsRequired = false)]
        public String LFcode { get; set; }

        [DataMember(Name = "UHFcode", IsRequired = false)]
        public String UHFcode { get; set; }

        [DataMember(Name = "keyCode", IsRequired = false)]
        public String keyCode { get; set; }

        // deprecated, we shall use CustomVars from now
        [DataMember(Name = "LaserVars", IsRequired = false)]
        public List<FSlaserVars> LaserVars { get; set; }

        [DataMember(Name = "Lasers", IsRequired = false)]
        public List<FSlaser> Lasers { get; set; }

        [DataMember(Name = "Printers", IsRequired = false)]
        public List<FSprinter> Printers { get; set; }

        [DataMember(Name = "CustomVars", IsRequired = false)]
        public List<FScustomVars> CustomVars { get; set; }


        public string ColombiaControlDigit( )
        {
            string runningNumber = this.keyCode.Substring(this.keyCode.Length - 12, 12);
            // test
            //runningNumber = "010000061735";
            int intVal = 0;
            int intVal1 = 0;

            for (int byCont = 0; byCont <= 10; byCont = byCont + 2)
            {
                //intVal = intVal + Val(Mid(runningNumber, byCont, 1));
                intVal += (int)Char.GetNumericValue((char)runningNumber.Substring(byCont, 1)[0]);
            }
            for (int byCont = 1; byCont <= 11; byCont = byCont + 2)
            {
                intVal1 = (int)Char.GetNumericValue((char)runningNumber.Substring(byCont, 1)[0]) * 2;
                if (intVal1 > 9)
                {
                    intVal = intVal + intVal1 % 10 + (int)(intVal1 / 10);
                } else
                {
                    intVal = intVal + intVal1;
                }
            }
            int checkdigit = 10 - intVal % 10;
            if (checkdigit == 10)
                checkdigit = 0;
            return checkdigit.ToString();
        }
        public string SpainControlDigit()
        {
            string runningNumber = this.keyCode.Substring(this.keyCode.Length - 12, 12);            
            //runningNumber = "724840102000001";
            int intVal = 0;

            if ((Int32.Parse(runningNumber.Substring(runningNumber.Length - 8, 8)) >= 1500000) && (Int32.Parse(runningNumber.Substring(runningNumber.Length - 8, 8)) < 2000000))
            {
                intVal = 18 + 30 + (int)Char.GetNumericValue((char)runningNumber.Substring(0, 1)[0]) + (int)Char.GetNumericValue((char)runningNumber.Substring(1, 1)[0]);
                for (int byCont = 4; byCont <= 10; byCont++)
                {
                    intVal += (int)Char.GetNumericValue((char)runningNumber.Substring(byCont, 1)[0]);
                }                
            } else
            {
                intVal = (int)Char.GetNumericValue((char)runningNumber.Substring(0, 1)[0]) + ((int)Char.GetNumericValue((char)runningNumber.Substring(1, 1)[0]))*2;
                for (int byCont = 4; byCont <= 10; byCont++)
                {
                    intVal += (int)Char.GetNumericValue((char)runningNumber.Substring(byCont, 1)[0])* (byCont - 1);
                }
            }
            intVal += (int)Char.GetNumericValue((char)runningNumber.Substring(runningNumber.Length-1, 1)[0]);
            int checkdigit = intVal % 10;
            return checkdigit.ToString();
        }
        public string PortugalControlDigit()
        {
            string sTemp = this.keyCode.Substring(this.keyCode.Length - 11, 11);
            int intVal = 0;
            for (int byCont = 1; byCont <= 9; byCont = byCont + 2)
            {                
                intVal += (int)Char.GetNumericValue((char)sTemp.Substring(byCont, 1)[0]);
            }
            for (int byCont = 0; byCont <= 10; byCont = byCont + 2)
            {
                intVal += (int)Char.GetNumericValue((char)sTemp.Substring(byCont, 1)[0])*3;
            }
            int checkdigit = 10 - intVal % 10;
            if (checkdigit == 10)
                checkdigit = 0;
            return checkdigit.ToString();
        }

        public string CyprusControlDigit()
        {
            string sTemp = this.keyCode.Substring(this.keyCode.Length - 8, 8);
            int intVal = 0;
            intVal += 5 * (int)Char.GetNumericValue((char)sTemp.Substring(0, 1)[0]);
            intVal += 9 * (int)Char.GetNumericValue((char)sTemp.Substring(1, 1)[0]);
            intVal += 6 * (int)Char.GetNumericValue((char)sTemp.Substring(2, 1)[0]);
            intVal += 3 * (int)Char.GetNumericValue((char)sTemp.Substring(3, 1)[0]);
            intVal += 1 * (int)Char.GetNumericValue((char)sTemp.Substring(4, 1)[0]);
            intVal += 7 * (int)Char.GetNumericValue((char)sTemp.Substring(5, 1)[0]);
            intVal += 8 * (int)Char.GetNumericValue((char)sTemp.Substring(6, 1)[0]);
            intVal += 2 * (int)Char.GetNumericValue((char)sTemp.Substring(7, 1)[0]);
            intVal = Math.Abs(9 - (intVal % 13));
            return intVal.ToString();
        }

        public string RomaniaControlDigit()
        {
            string sTemp = this.keyCode.Substring(this.keyCode.Length - 12, 2) + this.keyCode.Substring(this.keyCode.Length - 9, 9);
            //sTemp = "03474036530";
            int intVal = 0;
            for (int byCont = 1; byCont <= 9; byCont = byCont + 2)
            {
                intVal += (int)Char.GetNumericValue((char)sTemp.Substring(byCont, 1)[0]);
            }
            for (int byCont = 0; byCont <= 10; byCont = byCont + 2)
            {
                intVal += (int)Char.GetNumericValue((char)sTemp.Substring(byCont, 1)[0]) * 3;
            }
            int checkdigit = 10 - intVal % 10;
            if (checkdigit == 10)
                checkdigit = 0;
            return checkdigit.ToString();
        }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSproductionItems>));

                using (MemoryStream stream = new MemoryStream())
                {
                    ser.WriteObject(stream, this);
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        stream.Position = 0;
                        ret = sr.ReadToEnd();
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deserialize(string message)
        {
            try
            {
                if (message == string.Empty)
                    return;

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSproductionItems));
                using (Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(message)))
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
