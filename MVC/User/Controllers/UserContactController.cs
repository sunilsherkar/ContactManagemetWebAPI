using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using User.Models;

namespace User.Controllers
{
    public class UserContactController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://sunilsherkar-001-site1.ftempurl.com/";
        //String Baseurl = "http://localhost:53939/";
        /// <summary>
        /// Return all list of contacts
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            List<ContactList> ContactLists = new List<ContactList>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/contact");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ContactResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ContactLists = JsonConvert.DeserializeObject<List<ContactList>>(ContactResponse);

                }
                //returning the employee list to view  
                return View(ContactLists);
            }
        }
        /// <summary>
        /// Add contact get methods
        /// </summary>
        /// <returns></returns>
        public ActionResult AddContact()
        {
            AddContact model = new AddContact();
            model.UserID = 0;
            return View(model);
        }
        /// <summary>
        /// Add new contact 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddContact(AddContact model)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Baseurl);
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/api/contact", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json("Success");
                }
                 else
                {
                    return Json("failed");
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("<b>Message:</b> {0}<br /><br />", ex.Message);
                return Json(message);
            }
        }
        /// <summary>
        /// To update contact info of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Baseurl);
            AddContact model = new AddContact();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/api/contact/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<AddContact>(data);
            }
            return View("AddContact", model);
        } 
    }
}
