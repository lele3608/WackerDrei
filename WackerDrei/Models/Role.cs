using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WackerDrei.Models
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {

        }

        public Role(string name) : base(name)
        {

        }
    }
}