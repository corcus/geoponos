using System;
using System.Collections.Generic;
using System.Text;

namespace Geoponos.Core.Entities
{
    public class GeoponosUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public GeoponosUser()
        {

        }

        public GeoponosUser(string Username, string FisrtName, string LastName, string Email)
        {
            this.Username = Username;
            this.FirstName = FisrtName;
            this.LastName = LastName;
            this.Email = Email;
        }
    }
}
