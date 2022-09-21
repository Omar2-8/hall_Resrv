using Hall_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.XWPF.UserModel;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Hall_Reservation.Controllers
{
    public class DashBoardController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly ModelContext _context;

        public DashBoardController(ModelContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }



        public async Task<IActionResult> ExporttoExcel()
        {
            try
            {
                List<Checked> checkeds=_context.Checkeds.Where(x=>x.Status==1).ToList();
                List<Booking> bookings=new List<Booking>();
                foreach(var check in checkeds)
                {
                    var book = _context.Bookings.Find(check.BookingId);
                    bookings.Add(book);
                    
                }

                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Excel Report");
                FileInfo file = new FileInfo(filePath);
                var memoryStream = new MemoryStream();
                int count = 1;

                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Customers Data");
                    ICellStyle style = workbook.CreateCellStyle();
                    style.WrapText = true;
                    style.Alignment = HorizontalAlignment.Center;


                    IRow row = excelSheet.CreateRow(0);
                    row.CreateCell(0).SetCellValue("Booking Id");
                    row.CreateCell(1).SetCellValue("User Id");
                    row.CreateCell(2).SetCellValue("User Name");
                    row.CreateCell(3).SetCellValue("Hall Id");
                    row.CreateCell(4).SetCellValue("Hall Name");
                    row.CreateCell(5).SetCellValue("Creation_Date");

                    excelSheet.SetColumnWidth(0, 35 * 256);
                    excelSheet.SetColumnWidth(1, 35 * 256);
                    excelSheet.SetColumnWidth(2, 35 * 256);
                    excelSheet.SetColumnWidth(3, 35 * 256);
                    excelSheet.SetColumnWidth(4, 35 * 256);
                    excelSheet.SetColumnWidth(5, 35 * 256);


                    foreach (var book in bookings)
                    {

                        IRow row1 = excelSheet.CreateRow(count);
                        row1.CreateCell(0).SetCellValue((double)book.BookingId);
                        row1.CreateCell(1).SetCellValue((double)book.UserId);
                        row1.CreateCell(2).SetCellValue(book.User.Fname);
                        row1.CreateCell(3).SetCellValue((double)book.HallId);
                        row1.CreateCell(4).SetCellValue(book.Hall.HallName);
                        row1.CreateCell(5).SetCellValue(book.Creation_Date);

                        row1.GetCell(0).CellStyle = style;
                        row1.GetCell(1).CellStyle = style;
                        row1.GetCell(2).CellStyle = style;
                        row1.GetCell(3).CellStyle = style;
                        row1.GetCell(4).CellStyle = style;
                        row1.GetCell(5).CellStyle = style;


                        count++;

                    }
                    workbook.Write(fs);
                    using (var fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        await fileStream.CopyToAsync(memoryStream);
                    }
                    memoryStream.Position = 0;
                    return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Excel Report");

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Admin()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("login", "LoginAndRegestration");
            }
                ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            ViewBag.NumberOfUser = _context.Users.Count();
            ViewBag.NumberOfHalls = _context.Halls.Count();
            ViewBag.NumberOfreservedHalls = _context.Checkeds.Where(c => c.Status == 1).Count();
            ViewBag.NumberOfemptyHalls = _context.Checkeds.Where(c => c.Status == 0 || c.Status==null).Count();

            return View();
        }
        public IActionResult logout()
        {

            HttpContext.Session.Clear();
            
            return RedirectToAction("login", "LoginAndRegestration");
        }


        //public ActionResult usersCount()
        //{

        //    ViewBag.TotalCountUsers = count;
        //    ViewData["Users"]=count;
        //    return View(count);
        //}

        //public ActionResult hallsCount()
        //{
        //   
        //    ViewBag.CountHalls=halls;
        //    ViewData["halls"]=halls;
        //    return View(halls);
        //}


        //public ActionResult reservedHallsCount()
        //{
        //    
        //    ViewBag.ReservedHalls=reserved;
        //    ViewData["reservedHalls"] = reserved;
        //    return View(reserved);
        //}








    }
}
