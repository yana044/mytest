using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_API_Json.Models;

namespace Test_API_Json
{
    internal class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public AddressModel Address { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public CompanyModel Company { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            UserModel user = obj as UserModel;
            if (user == null)
            { return false; }

            return Id == user.Id && Name == user.Name && Username == user.Username && Email == user.Email 
                && Address.Equals(user.Address) && Website == user.Website
                && Phone == user.Phone && Company.Equals(user.Company);
        }
    }
}
