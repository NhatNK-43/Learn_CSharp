using System.IO;
using System.Linq;
using learn_c_sharp_mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace learn_c_sharp_mvc.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData

            _logger.LogInformation("Index action");
            return "Toi la first controller";
        }

        // ~ IActionResult
        // Kiểu trả về                 | Phương thức
        // ------------------------------------------------
        // ContentResult               | Content()
        // EmptyResult                 | new EmptyResult()
        // FileResult                  | File()
        // ForbidResult                | Forbid()
        // JsonResult                  | Json()
        // LocalRedirectResult         | LocalRedirect()
        // RedirectResult              | Redirect()
        // RedirectToActionResult      | RedirectToAction()
        // RedirectToPageResult        | RedirectToRoute()
        // RedirectToRouteResult       | RedirectToPage()
        // PartialViewResult           | PartialView()
        // ViewComponentResult         | ViewComponent()
        // StatusCodeResult            | StatusCode()
        // ViewResult                  | View()

        public void Nothing()
        {
            _logger.LogInformation("Nothing");
            Response.Headers.Add("Hello", "Xin chao cac ban");
        }

        public object Anything() => new int[] { 1, 3, 4 };

        public IActionResult ReadMe()
        {
            var content = @"
            Xin chao cac ban!
            Minh la Nhat.
            ";
            return Content(content, "text/plain");
        }

        public IActionResult Image()
        {
            // Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "image.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/png");
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }

        public IActionResult Google()
        {
            var url = "https://www.google.com";
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "Khanh";
            }

            // View() -> Razor Engine, doc .cshtml (template)
            //______________________________________________
            // View(template) - template duong dan tuyet doi toi .cshtml
            // View(template, model) 
            // return View("/MyView/hello.cshtml", username);

            // .cshtml -> /View/First/hello.cshtml
            // return View("hello.cshtml", username);

            // .cshtml -> /View/First/HelloView.cshtml
            // => /View/Controller/Action.cshtml => thiet lap them tai Startup.cs
            return View();

            // .cshtml -> /View/First/HelloView.cshtml
            // (object) username -> Model
            // return View((object) username);
        }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                TempData["StatusMessage"] = "Khong tim thay san pham";
                return Redirect(Url.Action("Index", "Home"));
            }

            // Model
            // return View(product);

            // ViewData
            // ViewData["product"] = product;
            // return View("ViewProduct2");

            //ViewBag
            ViewBag.product = product;
            ViewBag.title = "San pham";
            return View("ViewProduct3");
        }
    }
}