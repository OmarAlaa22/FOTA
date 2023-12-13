using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace FOTA.Controllers
{
	public class FilresController : Controller
	{
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FilresController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult OpenFile(int value)
        {
            string fileName = "CAN.txt";
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Files", fileName);

            if (System.IO.File.Exists(filePath))
            {
                // Read the existing content
                string existingContent = System.IO.File.ReadAllText(filePath);

                // Delete the existing file
                System.IO.File.Delete(filePath);

                // Write the new content (in this case, the number 1)
                System.IO.File.WriteAllText(filePath, value.ToString());

                return Ok(new { OldContent = existingContent, NewContent = value });
            }
            else
            {
                return NotFound(new { Message = "File not found!" });
            }
        }
        public IActionResult Index()
		{

			string filePath = @"C:\\Users\\dell\\Desktop\\hexa\\CAN.txt";

			if (System.IO.File.Exists(filePath))
			{
				string fileContent = System.IO.File.ReadAllText(filePath);
				ViewBag.Data = fileContent;
				return View();
			}
			else
			{
				ViewBag.ErrorMessage = "File not found!";
				return View();
			}
		
		}
		public IActionResult ReadFile()
		{
			string filePath = "C:\\Users\\dell\\Desktop\\khaled\\yourfile.txt";

			if (System.IO.File.Exists(filePath))
			{
				string fileContent = System.IO.File.ReadAllText(filePath);
				ViewBag.Data=fileContent;
				return View("ReadFile", fileContent);
			}
			else
			{
				ViewBag.ErrorMessage = "File not found!";
				return View("Error");
			}

		}
	}
}
