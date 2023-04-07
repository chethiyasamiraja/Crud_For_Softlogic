using CrudForSoftlogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudForSoftlogic.Controllers
{
    public class CustomerCrudController : ApiController
    {
        DBCustomerEntities cm = new DBCustomerEntities();
        public IHttpActionResult getCustomer()
        {
            var resurlts = cm.sp_CrudCustomer(0, "", 0, "", "", "Get").ToList();
            return Ok(resurlts);

        }
        public IHttpActionResult inserEmployee(tbl_Customer CustomerInsert)
        {
            var insertresurlts = cm.sp_CrudCustomer(0, CustomerInsert.Name, CustomerInsert.PhoneNo, CustomerInsert.Email, CustomerInsert.Address, "insert").ToList();
            return Ok(insertresurlts);
        }

        public IHttpActionResult getEmpId(int id)
        {
            var empDetails = cm.sp_CrudCustomer(id, "", 0, "", "", "GetEmpId").Select(x => new CustomerClass()
            {

                ID = x.ID,
                Name = x.Name,
                PhoneNo = Convert.ToInt32(x.PhoneNo),
                Address = x.Email,
                Email = x.Address

            }).FirstOrDefault<CustomerClass>();
            return Ok(empDetails);

        }

        public IHttpActionResult Put(CustomerClass ec)
        {

            var updateEmprecord = cm.sp_CrudCustomer(ec.ID, ec.Name,  ec.PhoneNo, ec.Address, ec.Email, "Update").ToList();
            return Ok(updateEmprecord);

        }

        public IHttpActionResult Delete(int id)
        {
            var deleteemp = cm.sp_CrudCustomer(id, "", 0, "", "", "Delete").Select(x => new CustomerClass()
            {

                ID = x.ID,
                Name = x.Name,
                PhoneNo = Convert.ToInt32(x.PhoneNo),
                Address = x.Address,
                Email = x.Email

            }).FirstOrDefault<CustomerClass>();
            cm.SaveChanges();
            return Ok();
        }





    }
}