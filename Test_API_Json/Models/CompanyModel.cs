using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_API_Json.Models
{
    internal class CompanyModel
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            CompanyModel company = obj as CompanyModel;
            if (company == null)
            { return false; }

            return Name == company.Name && CatchPhrase == company.CatchPhrase && Bs == company.Bs;
        }
    }
}
