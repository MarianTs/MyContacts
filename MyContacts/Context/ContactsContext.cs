using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyContacts.Models;

namespace MyContacts.Context
{
    public class ContactsContext: DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }
    }
}