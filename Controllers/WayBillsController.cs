using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TritonExpress.Data;
using TritonExpress.Models;

namespace TritonExpress.Controllers
{
    public class WayBillsController : Controller
    {
        private readonly DataContext _context;

        public WayBillsController(DataContext context)
        {
            _context = context;
        }

        // GET: WayBills
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.WayBills.Include(w => w.Vehicles);
            return View(await dataContext.ToListAsync());
        }

        // GET: WayBills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wayBill = await _context.WayBills
                .Include(w => w.Vehicles)
                .FirstOrDefaultAsync(m => m.wayBillId == id);
            if (wayBill == null)
            {
                return NotFound();
            }

            return View(wayBill);
        }

        // GET: WayBills/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "vehicleRegistration");
            return View();
        }

        // POST: WayBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("wayBillId,wayBillReference,totalWeight,parcels,VehicleId")] WayBill wayBill)
        {
            if (ModelState.IsValid)
            {
                wayBill.wayBillReference = wayBill.GetWayRef();
                _context.Add(wayBill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "vehicleRegistration", wayBill.VehicleId);
            return View(wayBill);
        }

        // GET: WayBills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wayBill = await _context.WayBills.FindAsync(id);
            if (wayBill == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "vehicleName", wayBill.VehicleId);
            return View(wayBill);
        }

        // POST: WayBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("wayBillId,wayBillReference,totalWeight,parcels,VehicleId")] WayBill wayBill)
        {
            if (id != wayBill.wayBillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wayBill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WayBillExists(wayBill.wayBillId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "vehicleName", wayBill.VehicleId);
            return View(wayBill);
        }

        // GET: WayBills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wayBill = await _context.WayBills
                .Include(w => w.Vehicles)
                .FirstOrDefaultAsync(m => m.wayBillId == id);
            if (wayBill == null)
            {
                return NotFound();
            }

            return View(wayBill);
        }

        // POST: WayBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wayBill = await _context.WayBills.FindAsync(id);
            _context.WayBills.Remove(wayBill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WayBillExists(int id)
        {
            return _context.WayBills.Any(e => e.wayBillId == id);
        }
    }
}
