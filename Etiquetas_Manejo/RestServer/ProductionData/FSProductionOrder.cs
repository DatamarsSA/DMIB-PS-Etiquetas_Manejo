using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    /*public enum eJobType
    {
        list,
        autoincremental,
        repetition
    };*/
    public enum ProductType  // Product in OS
    {
        undefined,
        visualOnly,
        electronic,
        MF11, //FET
        MF11_DOUBLE,
        MF22, //BABYTAG
        TagFaster,
        TagFaster_DOUBLE
    };

    [DataContract]
    public class FSProductionOrder : IResponseData
    {
        [DataMember(Name = "ProdLineItemNum", IsRequired = true)]
        public String ProdLineItemNum { get; set; }

        [DataMember(Name = "AssignmentID", IsRequired = false)]
        public String AssignmentID { get; set; }

        [DataMember(Name = "ComponentSet", IsRequired = false)]
        public String ComponentSet { get; set; }

        [DataMember(Name = "ProductType", IsRequired = false)]
        public ProductType ProductType { get; set; }

        [DataMember(Name = "Products", IsRequired = false)]
        public List<product> Products { get; set; }  // this shall overseed ProductType, I need to parse it to detect if we have strip productions

        [DataMember(Name = "Notes", IsRequired = false)]
        public String Notes { get; set; }

        [DataMember(Name = "Colour", IsRequired = false)]
        public String Colour { get; set; }
       
        //[DataMember(Name = "JobType", IsRequired = false)]
        //public eJobType JobType { get; set; }

        // this make sense if the JobType is equal to autoincremental only, the numbers will increment up to this number and then roll back
        //[DataMember(Name = "repetitionNumber", IsRequired = false)]
        //public int repetitionNumber { get; set; }

        [DataMember(Name = "NoOfItems", IsRequired = true)]
        public long NoOfItems { get; set; }

        // authorization order properties
        [DataMember(Name = "AuthProperties", IsRequired = false)]
        public FSauthProperties AuthProperties { get; set; }

        [DataMember(Name = "OrderInformation", IsRequired = false)]
        public FSorderInformation OrderInformation { get; set; }

        [DataMember(Name = "LfParameters", IsRequired = false)]
        public FSlfParameters LfParameters { get; set; }

        [DataMember(Name = "UhfParameters", IsRequired = false)]
        public FSuhfParameters UhfParameters { get; set; }

        // deprecated
        [DataMember(Name = "LaserParameters", IsRequired = false)]
        public FSlaserParameters LaserParameters { get; set; }

        [DataMember(Name = "ProdItems", IsRequired = false)] // was true
        public List<FSproductionItems> ProdItems { get; set; }

        public bool hasLaser()
        {
            if (this.LaserParameters != null)
            {
                return true;
            }
            if (this.ProdItems?.Count > 0 )
            {
                if (this.ProdItems[0].Lasers == null)
                {
                    return false;
                }
                foreach (FSlaser ls in this.ProdItems[0].Lasers){
                    if (ls.Disabled == false)
                    {
                        return true;
                    }
                }                
            }
            return false;
        }

        public string getLayoutName()
        {
            if (this.hasLaser() == false)
            {
                return string.Empty;
            }
            if (this.ProdItems?.Count > 0)
            {
                if (this.ProdItems[0].Lasers?.Count > 0)
                {
                    return this.ProdItems[0].Lasers[0].LayoutName;
                }
            } else if (this.LaserParameters != null)
            {
                return this.LaserParameters.LayoutName;
            } else
            {
                return string.Empty;
            }
            return string.Empty;
        }

        public string getLayoutName(int ix)
        {
            if (this.hasLaser() == false)
            {
                return string.Empty;
            }
            if (this.ProdItems?.Count >= (ix+1))
            {
                return this.ProdItems[0].Lasers[ix].LayoutName;
            }
            else
            {
                return string.Empty;
            }
        }

        public string serialize()
        {
            try
            {
                string ret = "";
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<FSProductionOrder>));

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

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(FSProductionOrder));
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
