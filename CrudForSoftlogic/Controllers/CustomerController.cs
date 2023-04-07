using CrudForSoftlogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CrudForSoftlogic.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer



        public ActionResult Index()
        {
            IEnumerable<tbl_Customer> CustomerObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/CustomerCrud");

            var consumeapi = hc.GetAsync("CustomerCrud");
            consumeapi.Wait();
            var readData = consumeapi.Result;
            if (readData.IsSuccessStatusCode)
            {
                var displayData = readData.Content.ReadAsAsync<IList<tbl_Customer>>();
                displayData.Wait();
                CustomerObj = displayData.Result;
            }


            return View(CustomerObj);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(tbl_Customer newEmpInsert)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/CustomerCrud");

            var insertrec = hc.PostAsJsonAsync<tbl_Customer>("CustomerCrud", newEmpInsert);
            insertrec.Wait();
            var savedata = insertrec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");


        }

        public ActionResult Details(int id)
        {
            CustomerClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/");


            var consumeapi = hc.GetAsync("CustomerCrud?id=" + id.ToString());
            consumeapi.Wait();
            var readData = consumeapi.Result;
            if (readData.IsSuccessStatusCode)
            {
                var displayempDetails = readData.Content.ReadAsAsync<CustomerClass>();
                displayempDetails.Wait();
                empobj = displayempDetails.Result;
            }
            return View(empobj);
            //build the project
        }

        public ActionResult Edit(int id)
        {

            CustomerClass empobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/");


            var consumeapi = hc.GetAsync("CustomerCrud?id=" + id.ToString());
            consumeapi.Wait();
            var readData = consumeapi.Result;
            if (readData.IsSuccessStatusCode)
            {
                var displayempDetails = readData.Content.ReadAsAsync<CustomerClass>();
                displayempDetails.Wait();
                empobj = displayempDetails.Result;
            }
            return View(empobj);


        }

        [HttpPost]
        public ActionResult Edit(CustomerClass ec)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/CustomerCrud");
            var updaterec = hc.PutAsJsonAsync<CustomerClass>("CustomerCrud", ec);
            updaterec.Wait();

            var saveData = updaterec.Result;
            if (saveData.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");


            }
            return View(ec);
        }


        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:8934/api/CustomerCrud");

            var deleterec = hc.DeleteAsync("CustomerCrud/" + id.ToString());
            deleterec.Wait();

            var savedata = deleterec.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Index");

        }






    }
}