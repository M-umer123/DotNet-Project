using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Project_1.Models;

namespace Project_1.Controllers
{
    public class AdminController : Controller
    {
        private readonly MarketReadySiteContext context;

        public AdminController(MarketReadySiteContext context)
        {
            this.context = context;
        }

        private void CheckAdminLogin()
        {
            var adminId = HttpContext.Session.GetInt32("AdminId");

            string currentAction = ControllerContext.ActionDescriptor.ActionName.ToLower();

            if (adminId == null && currentAction != "login" && currentAction != "logout")
            {
                TempData["ErrorMessage"] = "Please log in to access the admin panel.";
                Response.Redirect("/Admin/Login");
            }
        }

        //// ✅ Step 2: This automatically runs before every action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            CheckAdminLogin();
            base.OnActionExecuting(context);
        }

        // GET: HomeController
        public IActionResult Index()
        {
            var dashboard = new DashboardViewModel
            {
                TotalBookings = context.BookingTbls.Count(),
              
                UpcomingBookings = context.BookingTbls.Count(b => b.BookerBookingDate > DateTime.Now),
                RecentBookings = context.BookingTbls
                  .OrderByDescending(b => b.BookId)
                  .Take(5)
                  .ToList(),
                Menus = context.Menus.ToList()
            };

            return View(dashboard);
        }



        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AdminTable model)
        {
       
                // ✅ Check if name + password exist in DB
                var admin = context.AdminTables
                    .FirstOrDefault(a => a.AdminName == model.AdminName
                                      && a.AdminPassword == model.AdminPassword);

                if (admin != null)
                {
                    // ✅ Store session values
                    HttpContext.Session.SetInt32("AdminId", admin.AdminId);
                    HttpContext.Session.SetString("AdminName", admin.AdminName);
                    HttpContext.Session.SetString("AdminEmail", admin.AdminEmail ?? "");

                    TempData["SuccessMessage"] = "Login successful!";
                    return RedirectToAction("Index", "Admin");
                }

                TempData["ErrorMessage"] = "Invalid name or password!";
            

            return View(model);
        }


        public IActionResult Logout()
        {
         
            HttpContext.Session.Clear();

          
            return RedirectToAction("Login", "Admin");
        }

        public IActionResult Profile(int id)
        {
            var admin = context.AdminTables.FirstOrDefault(a => a.AdminId == id);
            if (admin == null)
            {
                return RedirectToAction("index", "admin");
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(AdminTable model)
        {
          
                var admin = context.AdminTables.FirstOrDefault(a => a.AdminId == model.AdminId);
                if (admin == null)
                {
                    TempData["ErrorMessage"] = "Admin not found!";
                    return RedirectToAction("Index", "Admin");
                }

                // ✅ Update only existing fields (no password)
                admin.AdminName = model.AdminName;
                admin.AdminPhone = model.AdminPhone;
                admin.AdminEmail = model.AdminEmail;

                context.SaveChanges();

            // ✅ Update Session (so UI shows latest values immediately)
            HttpContext.Session.SetInt32("AdminId", admin.AdminId);
            HttpContext.Session.SetString("AdminName", admin.AdminName ?? "");
            HttpContext.Session.SetString("AdminEmail", admin.AdminEmail ?? "");
            HttpContext.Session.SetString("AdminPhone", admin.AdminPhone ?? "");

            TempData["SuccessMessage"] = "Profile updated successfully!";
                return RedirectToAction("Profile", new { id = model.AdminId });
           
            // ❌ If validation fails, return the form with errors
            return View(model);
        }


        public ActionResult forgot_password()
        {
            return View();
        }


        // About User Form

        public ActionResult about_form()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult about_form(AboutTbl model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if there's already an About record
                    var existingAbout = context.AboutTbls.FirstOrDefault();

                    if (existingAbout == null)
                    {
                        // No record found → Insert new
                        context.AboutTbls.Add(model);
                        TempData["SuccessMessage"] = "About information added successfully!";
                    }
                    else
                    {
                        // Record exists → Update existing fields
                        existingAbout.AboutTitle = model.AboutTitle;
                        existingAbout.AboutDesc = model.AboutDesc;
                        existingAbout.AboutBtnText = model.AboutBtnText;

                        context.AboutTbls.Update(existingAbout);
                        TempData["SuccessMessage"] = "About information updated successfully!";
                    }

                    context.SaveChanges();
                    return RedirectToAction("about_form");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Failed to save information!";
                    return RedirectToAction("about_form");
                }
            }

            return View(model);
        }


        // Menu Add ActionMethod

        public ActionResult add_menu()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add_menu(Menu model)
        {


            var menu = context.Menus.FirstOrDefault() ?? new Menu();

            // ✅ Helper method for saving image
            string SaveImage(IFormFile file)
            {
                if (file == null)
                {
                    return null; // 🆕 Changed to return null instead of redirect
                }

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Admin_Assets", "images");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string fullPath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return fileName;
            }

            // ✅ Each product gets its own save check
            // Product 1
            if (!string.IsNullOrEmpty(model.ItemTitle1))
            {
                menu.ItemTitle1 = model.ItemTitle1;
                menu.ItemDesc1 = model.ItemDesc1;
                menu.Item1Price = model.Item1Price;

                var imageFile = Request.Form.Files["ItemImg1"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 1!";
                    return View(model);
                }

                menu.ItemImg1 = imagePath;
            }

            // Product 2
            if (!string.IsNullOrEmpty(model.ItemTitle2))
            {
                menu.ItemTitle2 = model.ItemTitle2;
                menu.ItemDesc2 = model.ItemDesc2;
                menu.Item2Price = model.Item2Price;

                var imageFile = Request.Form.Files["ItemImg2"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 2!";
                    return View(model);
                }

                menu.ItemImg2 = imagePath;
            }

            // Product 3
            if (!string.IsNullOrEmpty(model.ItemTitle3))
            {
                menu.ItemTitle3 = model.ItemTitle3;
                menu.ItemDesc3 = model.ItemDesc3;
                menu.Item3Price = model.Item3Price;

                var imageFile = Request.Form.Files["ItemImg3"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 3!";
                    return View(model);
                }

                menu.ItemImg3 = imagePath;
            }

            // Product 4
            if (!string.IsNullOrEmpty(model.ItemTitle4))
            {
                menu.ItemTitle4 = model.ItemTitle4;
                menu.ItemDesc4 = model.ItemDesc4;
                menu.Item4Price = model.Item4Price;

                var imageFile = Request.Form.Files["ItemImg4"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 4!";
                    return View(model);
                }

                menu.ItemImg4 = imagePath;
            }

            // Product 5
            if (!string.IsNullOrEmpty(model.ItemTitle5))
            {
                menu.ItemTitle5 = model.ItemTitle5;
                menu.ItemDesc5 = model.ItemDesc5;
                menu.Item5Price = model.Item5Price;

                var imageFile = Request.Form.Files["ItemImg5"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 5!";
                    return View(model);
                }

                menu.ItemImg5 = imagePath;
            }

            // Product 6
            if (!string.IsNullOrEmpty(model.ItemTitle6))
            {
                menu.ItemTitle6 = model.ItemTitle6;
                menu.ItemDesc6 = model.ItemDesc6;
                menu.Item6Price = model.Item6Price;

                var imageFile = Request.Form.Files["ItemImg6"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 6!";
                    return View(model);
                }

                menu.ItemImg6 = imagePath;
            }

            // Product 7
            if (!string.IsNullOrEmpty(model.ItemTitle7))
            {
                menu.ItemTitle7 = model.ItemTitle7;
                menu.ItemDesc7 = model.ItemDesc7;
                menu.Item7Price = model.Item7Price;

                var imageFile = Request.Form.Files["ItemImg7"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 7!";
                    return View(model);
                }

                menu.ItemImg7 = imagePath;
            }

            // Product 8
            if (!string.IsNullOrEmpty(model.ItemTitle8))
            {
                menu.ItemTitle8 = model.ItemTitle8;
                menu.ItemDesc8 = model.ItemDesc8;
                menu.Item8Price = model.Item8Price;

                var imageFile = Request.Form.Files["ItemImg8"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 8!";
                    return View(model);
                }

                menu.ItemImg8 = imagePath;
            }

            // Product 9
            if (!string.IsNullOrEmpty(model.ItemTitle9))
            {
                menu.ItemTitle9 = model.ItemTitle9;
                menu.ItemDesc9 = model.ItemDesc9;
                menu.Item9Price = model.Item9Price;

                var imageFile = Request.Form.Files["ItemImg9"];
                var imagePath = SaveImage(imageFile);

                // 🆕 Added Validation
                if (imagePath == null)
                {
                    TempData["ErrorMessage"] = "Please upload an image for Item 9!";
                    return View(model);
                }

                menu.ItemImg9 = imagePath;
            }

            // ✅ Add or Update database record
            if (menu.MenuId == 0)
                context.Menus.Add(menu);
            else
                context.Menus.Update(menu);

            context.SaveChanges();

            TempData["SuccessMessage"] = "Product saved successfully!";
            return RedirectToAction("add_menu");
        }

        // All Bookings Page
        public ActionResult all_bookings()
        {

            return View(context.BookingTbls.ToList());
        }

        [HttpGet]
public IActionResult booking_delete(int id)
{
    var booking = context.BookingTbls.FirstOrDefault(b => b.BookId == id);

    if (booking == null)
    {
        TempData["ErrorMessage"] = "Booking not found.";
        return RedirectToAction("all_bookings");
    }

    context.BookingTbls.Remove(booking);
    context.SaveChanges();

    TempData["SuccessMessage"] = "Booking deleted successfully.";
    return RedirectToAction("all_bookings");
}


        // Home Page

        public ActionResult add_home_info()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add_home_info(HomeTbl model, IFormFile HomeBgImg)
        {
            try
            {


                // ✅ Check if there is already a home record
                var existingHome = context.HomeTbls.FirstOrDefault();

                // ✅ Helper to save uploaded image
                string SaveImage(IFormFile file)
                {
                    if (file == null) return existingHome?.HomeBgImg; // keep old if not replaced

                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Admin_Assets", "Images");

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(folderPath, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return fileName;
                }

                // ✅ If record exists → Update
                if (existingHome != null)
                {
                    existingHome.HomeTitle = model.HomeTitle;
                    existingHome.HomeDesc = model.HomeDesc;
                    existingHome.HomeBgImg = SaveImage(HomeBgImg);

                    context.HomeTbls.Update(existingHome);
                    TempData["SuccessMessage"] = "Home info updated successfully!";
                }
                else
                {
                    // ✅ If no record exists → Add new one
                    model.HomeBgImg = SaveImage(HomeBgImg);
                    context.HomeTbls.Add(model);
                    TempData["SuccessMessage"] = "Home info added successfully!";
                }

                context.SaveChanges();
                return RedirectToAction("add_home_info");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong while saving home info!";
                return RedirectToAction("add_home_info");
            }
        }






        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
