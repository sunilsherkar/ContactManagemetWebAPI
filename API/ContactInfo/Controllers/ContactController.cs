using ContactInfo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
  
namespace ContactInfo.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contact_Repository)
        {
            this.contactRepository = contact_Repository;
        }
        /// <summary>
        /// // GET: api/Products
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public IEnumerable<ContactList> GetAllContact()
        {
            return contactRepository.GetAllContact();
        }
        /// <summary>
        /// Get contact by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactList GetContactById(int id)
        {
            return contactRepository.GetContactById(id);
        }
        /// <summary>
        /// Save new contact 
        /// </summary>
        /// <param name="Contacts"></param>
        /// <returns></returns>
        public int PostSaveContact(AddContact Contacts)
        {
             return contactRepository.PostSaveContact(Contacts);
        } 
    } 
}