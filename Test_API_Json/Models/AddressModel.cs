using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_Json.Models
{
    internal class AddressModel
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoModel Geo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            AddressModel address = obj as AddressModel;
            if (address == null)
            { return false; }

            return Street == address.Street && Suite == address.Suite && City == address.City && Zipcode == address.Zipcode && Geo.Equals(address.Geo);
        }
    }
}
