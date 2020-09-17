using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransactionWithjQuery.DbContext;
using BankTransactionWithjQuery.Models;
using System.IO;
using OfficeOpenXml;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BankTransactionWithjQuery.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineBankDbContext _context;

        public ProductsController(OnlineBankDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productses.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Productses
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Category,Color,UnitDecimal,AvailableQuantity,CreateDate,EndDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Productses.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Category,Color,UnitDecimal,AvailableQuantity,CreateDate,EndDate")] Products products)
        {
            if (id != products.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Productses
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Productses.FindAsync(id);
            _context.Productses.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExcelResult()
        {
            string connectionstring = "Server=DESKTOP-HPCIQLA\\TESTDB; Database=jQueryQAjaxMVCDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
            //string sql = "INSERT INTO USerExcel ";

            string FilePath = "G:\\22.xlsx";
            FileInfo existingFile = new FileInfo(FilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        // Console.WriteLine(" Value: +" + worksheet.Cells[row, col].Value.ToString().Trim());
                        string ss = "+" + worksheet.Cells[row, col].Value.ToString().Trim();
                        using (var connection = new SqlConnection(connectionstring))
                        {
                            connection.Open();
                            var sql = "INSERT INTO USerExcel (Codenumber) VALUES(@name)";
                            using (var cmd = new SqlCommand(sql, connection))
                            {
                                cmd.Parameters.Add("@name", SqlDbType.VarChar);
                                cmd.Parameters["@name"].Value = ss;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            return  View();
        }
        private bool ProductsExists(int id)
        {
            return _context.Productses.Any(e => e.ProductID == id);
        }
    }
}
