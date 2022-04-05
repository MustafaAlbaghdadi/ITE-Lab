#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspcore.Data;
using aspcore.Models;
using aspcore.Models.Shared;
using Microsoft.AspNetCore.Authorization;

namespace aspcore.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tickets

        [Authorize()]

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(UserType.Admin))
            {
                
                return View(await _context.Tickets.ToListAsync());


            }
            else if (User.IsInRole(UserType.Client))
            {
                return View(await _context.Tickets.Where(item => item.userId == User.Identity.Name).ToListAsync());

            }
            return (View());

        }

        //[Authorize(Roles = UserType.Client)]
        //[HttpGet("Tickets")]

        //public async Task<IActionResult> Index2()
        //{


        //    return View(await _context.Tickets.ToListAsync());
        //}



        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
           

            if (ticket == null)
            {
                return NotFound();
            }
            if (User.IsInRole(UserType.Client))
            {

                if (ticket.userId != User.Identity.Name)
                {
                    return NotFound();
                }
            }

            try
            {
                var comments = await _context.Comments.Where(item => item.TicketId == ticket.Id).ToListAsync();
                ticket.Comments  = comments;

            }
            catch 
            {

                
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Address,Phone,Note,CableType,TestType,CoresNumbers,CableLength,Wavelength")] Ticket ticket)
        {
            if (!string.IsNullOrWhiteSpace(ticket.Title) && !string.IsNullOrWhiteSpace(ticket.Address) && !string.IsNullOrWhiteSpace(ticket.Phone))
            {
                ticket.IsOpein = true;
                ticket.CreateDate = DateTime.Now;
                ticket.LastUpdate = DateTime.Now;
                ticket.userId = User.Identity.Name;

                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            if (User.IsInRole(UserType.Client))
            {

                if (ticket.userId != User.Identity.Name)
                {
                    return NotFound();
                }
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Address,IsOpein,userId,LastUpdate,CreateDate,Phone,Note,CableType,TestType,CoresNumbers,CableLength,Wavelength")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            
                if (User.IsInRole(UserType.Client))
                {

                    if (ticket.userId != User.Identity.Name)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    ticket.LastUpdate = DateTime.Now;
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            if (User.IsInRole(UserType.Client))
            {

                if (ticket.userId != User.Identity.Name)
                {
                    return NotFound();
                }
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (User.IsInRole(UserType.Client))
            {

                if (ticket.userId != User.Identity.Name)
                {
                    return NotFound();
                }
            }
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
