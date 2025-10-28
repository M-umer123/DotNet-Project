using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_1.Models;

namespace Project_1.Controllers
{
    public class UserController : Controller
    {
        private readonly MarketReadySiteContext context;

        public UserController(MarketReadySiteContext context) {
            this.context = context;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View(context.HomeTbls.FirstOrDefault());
        }

      

        // Menu Page

        public ActionResult menu()
        {
            return View(context.Menus.ToList());
        }



        // About Method

        public ActionResult about()
        {
            var aboutData = context.AboutTbls.ToList(); // Fetch all about records
            return View(aboutData); // Pass to view
        }

        // Booking Method

        public ActionResult booking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult booking(BookingTbl model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Save the booking record to database
                    context.BookingTbls.Add(model);
                    context.SaveChanges();

                    // Show a success message
                    TempData["SuccessMessage"] = "Your table has been booked successfully!";

                    // Redirect to the same page (so form resets)
                    return RedirectToAction("booking");
                }
                catch (Exception ex)
                {
                
                    // Show an error message
                    TempData["ErrorMessage"] = "Something went wrong! Please try again later.";
                }
            }

            // Return the same view if model is invalid or error occurs
            return View(model);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
