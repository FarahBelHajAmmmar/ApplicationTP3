using ApplicationTP3_second_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace ApplicationTP3_second_.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _db;


		public CustomerController(ApplicationDbContext db)
		{
			_db = db;
		}

       
        public IActionResult Index()
        {
            var customerDiscounts = (from Customer in _db.Customers
                                     join Membershiptype in _db.Membershiptypes on Customer.MembershiptypesId equals Membershiptype.Id
                                     select new CustomerViewModel
                                     {
                                         Name = Customer.Name,
                                         DiscountRate = Membershiptype.DiscountRate,
                                         Id = Customer.Id
                                     }).ToList();

            return View(customerDiscounts);
        }
        
        public IActionResult Edit(int? Id)
            
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var customer = _db.Customers.Find(Id);
            var membership = _db.Membershiptypes.Find(customer.MembershiptypesId);
            var obj = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                DiscountRate = membership.DiscountRate

            };
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerViewModel obj)
        {
            
            if (ModelState.IsValid)
            {
                var customer = _db.Customers.Find(obj.Id);
                customer.Name = obj.Name;
                _db.SaveChanges();
                var memebership = _db.Membershiptypes.Find(customer.MembershiptypesId);
                memebership.DiscountRate = obj.DiscountRate;
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);


        }
        public IActionResult Delete(int? Id)

        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var customer = _db.Customers.Find(Id);
            var membership = _db.Membershiptypes.Find(customer.MembershiptypesId);
            var obj = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                DiscountRate = membership.DiscountRate

            };
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CustomerViewModel obj)
        {

            if (ModelState.IsValid)
            {
                var customer = _db.Customers.Find(obj.Id);
                {
                    if (customer != null)
                    {
                        _db.Customers.Remove(customer);

                        _db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                 
                }
               

            }
            return View(obj);


        }
        public IActionResult Details(int? id)
        {
			var obj = (from cs in _db.Customers
					   join mb in _db.Membershiptypes on cs.MembershiptypesId equals mb.Id
					   where cs.Id == id
					   select new CustomerDetailsViewMode
					   {
						   Id = cs.Id,
						   Name = cs.Name,
						   DiscountRate = mb.DiscountRate,
						   MembershiptypesId = cs.MembershiptypesId,
						   Signupfee = mb.Signupfee,
						   DurationInMonth = mb.DurationInMonth
					   }).FirstOrDefault();




			if (obj != null)
			{
				return View(obj);
			}
			else
			{
				return NotFound();
			}
		}
		public IActionResult Create()
		{
			var members = _db.Membershiptypes.ToList();

			ViewBag.MembershipTypes = members
				.Select(member => new SelectListItem
				{
					Text = member.Id.ToString(),
					Value = member.Id.ToString()
				})
				.ToList();

			return View();
		}


		[HttpPost]
        [ValidateAntiForgeryToken]

		public IActionResult Create(Customers c)

		{
            ViewBag.Errors = ModelState.Values
           .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            if (!ModelState.IsValid)
			{
				var members = _db.Membershiptypes.ToList();

				ViewBag.MembershipTypes = members
					.Select(member => new SelectListItem
					{
						Text = member.Id.ToString(),
						Value = member.Id.ToString()
					})
					.ToList();
			}
		
			_db.Customers.Add(c);
			_db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

	}
}
