using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerReservation.Data;
using ServerReservation.Models;

namespace ServerReservation.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Request
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests.Include(r => r.ApprovedByUser).Include(r => r.RequestedByUser).Include(r => r.Server);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ApprovedByUser)
                .Include(r => r.RequestedByUser)
                .Include(r => r.Server)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create(int? id)
        {
            var selectedServerId = id;
            if (selectedServerId == null)
            {
                ViewData["ApprovedByUserId"] = new SelectList(_context.Users, "Id", "Details");
                ViewData["RequestedByUserId"] = new SelectList(_context.Users, "Id", "Details");
                ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Details");
                return View();
            }
            else
            {
                ViewData["SelectedServerId"] = selectedServerId;
                ViewData["ApprovedByUserId"] = new SelectList(_context.Users, "Id", "Details");
                ViewData["RequestedByUserId"] = new SelectList(_context.Users, "Id", "Details");
                ViewData["ServerId"] = new SelectList(_context.Servers.Where(i => i.Id == selectedServerId), "Id", "Details");
                return View();
            }
        }

        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? selectedServerId, [Bind("Id,Timestamp,StartDate,EndDate,IsNewServer,ServerId,RequestedByEmployeeId,RequestedByEmployeeName,RequestedByUserId,RequestJustification,ApprovalStatus,ApprovedByEmployeeId,ApprovedByEmployeeName,ApprovedByUserId,ApprovalComment")] Request request)
        {
            if (ModelState.IsValid)
            {
                request.ApprovalStatus = ApprovalStatus.Pending;
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApprovedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.ApprovedByUserId);
            ViewData["RequestedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.RequestedByUserId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Details", request.ServerId);
            return View(request);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["ApprovedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.ApprovedByUserId);
            ViewData["RequestedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.RequestedByUserId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Details", request.ServerId);
            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Timestamp,StartDate,EndDate,IsNewServer,ServerId,RequestedByEmployeeId,RequestedByEmployeeName,RequestedByUserId,RequestJustification,ApprovalStatus,ApprovedByEmployeeId,ApprovedByEmployeeName,ApprovedByUserId,ApprovalComment")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
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
            ViewData["ApprovedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.ApprovedByUserId);
            ViewData["RequestedByUserId"] = new SelectList(_context.Users, "Id", "Details", request.RequestedByUserId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Details", request.ServerId);
            return View(request);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ApprovedByUser)
                .Include(r => r.RequestedByUser)
                .Include(r => r.Server)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
