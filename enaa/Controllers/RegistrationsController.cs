﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using enaa.Data;
using enaa.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace enaa.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
              return _context.Registration != null ? 
                          View(await _context.Registration.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Registration'  is null.");
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Genre,DateDeN,Age,Email,Phone,BrancheBac,NiveauAcad,FiliereAcad,AutreFiliereAcad,DernierDip,Etablissement,AnneeDiplome,Experience,SiOuiExperience,Ville,RegisteredOn")] Registration registration)
        {
            var emailSuccess = "Votre e-meil à été vérifié avec succés";
            var emailfake = "emailSuccess";
            if (ModelState.IsValid)
            {
                //if (IsValidEmailFormat(registration.Email))
                //{
                //    TempData["emailSuccess"] = emailSuccess;
                //}
                //else
                //{
                //    TempData["emailfake"] = emailfake;
                     
                //}
                _context.Add(registration);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        static bool IsValidEmailFormat(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, pattern);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return View(registration);
        }

        [Authorize(Roles = "Admin")]

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Prenom,Genre,DateDeN,Age,Email,Phone,BrancheBac,NiveauAcad,FiliereAcad,AutreFiliereAcad,DernierDip,Etablissement,AnneeDiplome,Experience,SiOuiExperience,Ville,RegisteredOn")] Registration registration)
        {
            if (id != registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.Id))
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
            return View(registration);
        }

        [Authorize(Roles = "Admin")]
        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Registration == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Registration'  is null.");
            }
            var registration = await _context.Registration.FindAsync(id);
            if (registration != null)
            {
                _context.Registration.Remove(registration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(string id)
        {
          return (_context.Registration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
