using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactInfo.Models
{ 
    public interface IContactRepository
    {
        IEnumerable<ContactList> GetAllContact();
        ContactList GetContactById(int id);
        int PostSaveContact(AddContact Contacts);
    }
}