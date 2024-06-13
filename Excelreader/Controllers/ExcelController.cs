using Excelreader.Services;
using Microsoft.AspNetCore.Mvc;

namespace Excelreader.Controllers
{
    public class ExcelController : Controller
    {
        private readonly ExcelService _csvReaderService;
        private const int PageSize = 50;

        public ExcelController()
        {
            _csvReaderService = new ExcelService();
        }

        public IActionResult Index(int page = 1)
        {
            string filePath = "/uploads/Data.csv"; // Adjust the path to your CSV file

            var csvData = _csvReaderService.GetCsvData(filePath);
            var paginatedData = csvData.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            var totalRecords = csvData.Count();
            var totalPages = (totalRecords + PageSize - 1) / PageSize;

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedData);
        }
    }
}
