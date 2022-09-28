using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_Json.Models
{
    internal class GeoModel
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            GeoModel geo = obj as GeoModel;
            if (geo == null)
            { return false; }

            return Lat == geo.Lat && Lng == geo.Lng;
        }
    }
}
