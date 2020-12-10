using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductionData
{
    [DataContract]
    public class CreateOrderIdentifiers
    {
        private String _formattedtag = String.Empty;
        private String _unformattetTag = String.Empty;
        private DProperties _dynamicProperties= null;
        private int _region = 0;

        public int Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }


        [DataMember(Name = "DynamicProperties", IsRequired = true)]
        public DProperties DynamicProperties
        {
            set
            {
                this._dynamicProperties = value;
            }
            get
            {
                return this._dynamicProperties;
            }
        }

        [DataMember(Name = "FormattedTag", IsRequired = true)]
        public String FormattedTag
        {
            set
            {
                this._formattedtag = value;
            }
            get
            {
                return this._formattedtag;
            }
        }
       }
    }
