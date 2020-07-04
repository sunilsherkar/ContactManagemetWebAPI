using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using ContactInfo.Models;

namespace ContactInfo.Service
{
    public class ContactService : IContactRepository
    {
        ContactDbContext _db = new ContactDbContext();
        public IEnumerable<ContactList> GetAllContact()
        {
            IEnumerable<ContactList> clist = null;
            clist = _db.ContactLists.SqlQuery(@"exec usp_GetContactList").ToList<ContactList>();
            return clist;
        }
        public ContactList GetContactById(int id)
        {
            ContactList list = null;
            list = _db.ContactLists.SqlQuery(@"exec 
                     usp_GetContactList @UserID",
                 new SqlParameter("@UserID", id)).FirstOrDefault<ContactList>();

            return list;
        }

        public int PostSaveContact(AddContact Contacts)
        {
            int result = -1;
            try
            {
                 result = _db.Database.ExecuteSqlCommand(@"exec usp_InsertUpdateContact
                        @UserID ,@FirstName, @LastName,@EmailID,@MobileNo,@IsActive",
                new SqlParameter("@UserID", Contacts.UserID),
                new SqlParameter("@FirstName", Contacts.FirstName),
                new SqlParameter("@LastName", Contacts.LastName),
                new SqlParameter("@EmailID", Contacts.Email),
                new SqlParameter("@MobileNo", Contacts.Mobile),
                new SqlParameter("@IsActive", Contacts.isactive));
            }
            catch
            {
            }
            return result;
        }
    }
}