using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2001216311_VuThiHuyenVi_DoAn.Models;

namespace _2001216311_VuThiHuyenVi_DoAn.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Cart> cart = db.Cart.ToList();
            return View(cart);
        }

        public ActionResult Add(int id=0)
        {
            if(id>0)
            {
                CompanyDBContext db = new CompanyDBContext();
                Cart cartItem = db.Cart.Where(cart => cart.ProId == id).FirstOrDefault();
                if(cartItem!=null)
                {
                    cartItem.Quantity += 1;
                }
                else
                {
                    Cart cart = new Cart();
                    cart.ProId = id;
                    cart.Quantity = 1;
                    db.Cart.Add(cart);
                }    
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}