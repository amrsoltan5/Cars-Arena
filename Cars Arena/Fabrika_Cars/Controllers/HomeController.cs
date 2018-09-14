using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fabrika_Cars.Models;
using System.IO;
using System.Threading;
using System.Globalization;
namespace Fabrika_Cars.Controllers
{
    public class HomeController : BaseController
    {
        carsArena db = new carsArena();
        
        // GET: Home
        public ActionResult Index()
        {

            
            return View();
        }

        [HttpGet]
        public ActionResult register()

        {
            return View();
        }

        [HttpPost]
        public ActionResult register(users u1)

        {

            db.users.Add(u1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult login ()
        {


            return View();

        }
        [HttpPost]
        public ActionResult login( users u)
        {

            var data = db.users.Where(a => a.email == u.email && a.password == u.password).SingleOrDefault();
            var dataphone = db.users.Where(a => a.phone == u.email && a.password == u.password).SingleOrDefault();

            if (data != null)
            {
                Session["user_id"] = data.id;
                Session["user_name"] = data.name;
                Session["user_email"] = data.email;
                Session["user_phone"] = data.phone;
                
                return RedirectToAction("Index");

            }
            else if (dataphone != null)
            {


                Session["user_id"] = dataphone.id;
                Session["user_name"] = dataphone.name;
                Session["user_email"] = dataphone.email;
                Session["user_phone"] = dataphone.phone;

                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.errormessage = "Email Or Password Not Valid";
                return View(u);
            }

        }




        public ActionResult freeAD()
        {

            return View();
        }


        [HttpPost]
        public ActionResult freeAD(freeAD add,HttpPostedFileBase file)
        {
            

                string filename = Guid.NewGuid() + Path.GetFileName(file.FileName);
                string filepath = Server.MapPath("~/images/");
                string filepathname = Path.Combine(filepath, filename);
                file.SaveAs(filepathname);

                var user = db.users.Where(a => a.email == add.email && a.phone == add.phone).SingleOrDefault();
                if (user != null)
                {
                    var userid = user.id;
                    db.adv_copmanies.Add(new adv_copmanies
                    {
                        title = add.title,
                        description = add.description,
                        photo = filename,
                        car_category = add.car_cat,
                        user_id = userid,
                        connectwithmail = add.mail,
                        connectwithmobile = add.mobile,
                        price = add.price
                    });
                    db.SaveChanges();
                    return RedirectToAction("index");

                }
                else
                {
                    db.users.Add(new users
                    {
                        name = add.name,
                        email = add.email,
                        address = add.city,
                        phone = add.phone,
                        gender = true,
                        password = "123456"

                    });
                    db.SaveChanges();
                    var userAfter = db.users.SingleOrDefault(a => a.email == add.email && a.phone == add.phone);

                    db.adv_copmanies.Add(new adv_copmanies
                    {
                        title = add.title,
                        description = add.description,
                        photo = filename,
                        car_category = add.car_cat,
                        user_id = userAfter.id,
                        connectwithmail = add.mail,
                        connectwithmobile = add.mobile,
                        price = add.price

                    });

                    db.SaveChanges();
                    return RedirectToAction("index");

                }
            }
        





        public ActionResult search (string text ,string filter)
        {

            if(filter != null)
            {
                var filterid = int.Parse(filter);

                IEnumerable<adv_copmanies> data = null;

                if(filterid==1)
                {
                    
                    data = db.adv_copmanies.Where(a=>a.car_category.ToLower().Contains(text.ToLower()));
                }else if(filterid ==2)
                {
                     data = db.adv_copmanies.Where(a=>a.title.ToLower().Contains(text.ToLower()));
                }
                else if(filterid==3)
                {
                     data = db.adv_copmanies.Where(a=>a.description.ToLower().Contains(text.ToLower()));
                }
               


                return View(data);

            }


                 else
                {


                    return View(db.adv_copmanies.Where(a=>a.title.ToLower().Contains(text.ToLower())));
                }




        }




        [HttpPost]
        public ActionResult sendmessage (messages details)
        {

            db.messages.Add(details);
            db.SaveChanges();



            return RedirectToAction("index");
        }


        public ActionResult messages ()
        {
            


            return View(db.messages);
        }


        public ActionResult profile ()
        {

            var userid = (int) Session["user_id"];

            var data = db.adv_copmanies.Where(a => a.user_id == userid);

            return View(data);


        }

        
        public ActionResult delete_adv(int id)
        {
            var adv = db.adv_copmanies.Find(id);

            db.adv_copmanies.Remove(adv);
            db.SaveChanges();

            return RedirectToAction("profile");
        }





        public JsonResult Logout ()
        {
            
                Session["user_id"] = null;
                Session["user_name"] = null;
                Session["user_email"] = null;
                Session["user_phone"] = null;

                Session.Abandon();


            return Json("success", JsonRequestBehavior.AllowGet);
           
        }


    }
}