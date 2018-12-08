using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreAppEFCore.Data;
using AspNetCoreAppEFCore.Models;

namespace AspNetCoreAppEFCore.Controllers
{
    public class DataModelsController : Controller
    {
        private readonly DataContext _context;

        public DataModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: DataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataModels.ToListAsync());
        }

        // GET: DataModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModels
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return View(dataModel);
        }

        // GET: DataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,ArticleCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color,FileId")] DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataModel);
        }

        // GET: DataModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModels.SingleOrDefaultAsync(m => m.Id == id);
            if (dataModel == null)
            {
                return NotFound();
            }
            return View(dataModel);
        }

        // POST: DataModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,ArticleCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color,FileId")] DataModel dataModel)
        {
            if (id != dataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataModelExists(dataModel.Id))
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
            return View(dataModel);
        }

        // GET: DataModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModels
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return View(dataModel);
        }

        // POST: DataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataModel = await _context.DataModels.SingleOrDefaultAsync(m => m.Id == id);
            _context.DataModels.Remove(dataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataModelExists(int id)
        {
            return _context.DataModels.Any(e => e.Id == id);
        }
    }
}
