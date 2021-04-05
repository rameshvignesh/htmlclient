using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebApi.Models;

namespace DemoWebApi.Controllers
{
    public class DeptController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ShowEmps()
        {
            NorthwindEntities db = new NorthwindEntities();
            var data = from emp in db.Employees
                       select new
                       {
                           DeptName = emp.Dept.Name,
                           Location = emp.Dept.Location,
                           EmpId = emp.Id,
                           EmpName = emp.Name,
                           Salary = emp.Salary
                       };
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        public HttpResponseMessage GetDept()
        {
            using(NorthwindEntities db=new NorthwindEntities())
            {
                var data = db.Depts.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
        }
        public HttpResponseMessage GetDept(int id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var data = db.Depts.Find(id);
                if (data != null)
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dept with id= " + id + " not found");
            }

        }

        //{"Id":90,"Name":"Aero","Location":"Australia"}
        public HttpResponseMessage PostDept([FromBody] Dept dept)
        {
            try
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {
                    db.Depts.Add(dept);
                    db.SaveChanges();
                   
                        return Request.CreateResponse(HttpStatusCode.Created, dept);
                   
                       
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        //{"Name":"CHEMICAL","Location":"INDIA"}==>id=10
        public HttpResponseMessage PutDept(int id,[FromBody]Dept dept)
        {
            try
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {
                    var data = db.Depts.Find(id);
                    if (data == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Dept with id= " + id + " not found");
                    }
                    else
                    {
                        data.Name = dept.Name;
                        data.Location = dept.Location;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

                }
        public HttpResponseMessage DeleteDept(int id)
        {
            try
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {
                    var data = db.Depts.Find(id);
                    if (data == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Dept with id= " + id + " not found");
                    }
                    else
                    {
                        db.Depts.Remove(data);
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
        }
    

