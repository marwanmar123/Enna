using System;
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
using Microsoft.AspNetCore.Identity.UI.Services;
using enaa.Services;

namespace enaa.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public RegistrationsController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [Authorize(Roles = "Admin")]

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
              return _context.Registration != null ? 
                          View(await _context.Registration.Where(x => x.Confirmation == true).ToListAsync()) :
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
        public async Task<IActionResult> Create(string cinUser, [Bind("Id,Nom,Prenom,Genre,DateDeN,Age,Email,Phone,Cin,BrancheBac,NiveauAcad,FiliereAcad,AutreFiliereAcad,DernierDip,Etablissement,AnneeDiplome,Experience,SiOuiExperience,Domaine,Ville,Adresse,Comment,Confirmation,RegisteredOn")] Registration registration)
        {
            var emailSuccess = "Votre e-meil à été vérifié avec succés";
            var emailfake = "emailSuccess";

            var check = await _context.Registration.SingleOrDefaultAsync(x => x.Cin == cinUser);

            try{
                if (check == null)
                {
                    if (ModelState.IsValid)
                    {
                        _context.Add(registration);
                        await _context.SaveChangesAsync();

                        await _emailSender.SendEmailAsync(registration.Email, "Confirmation de l'inscription",
                            $"<h3>Cher/Chère "+ registration.Nom + " , </h3>" +
                            "<p>Nous sommes ravis de vous informer que votre inscription a été validée avec succès <a href='http://enalhansali-001-site1.ctempurl.com/Registrations/ConfirmDetails/" + registration.Id + "'>click ici pour confirmer votre inscription</a>.</p>" +
                            "<p>L'équipe de Enaa vous contactera dans les plus brefs délais,</p>" +
                            "<h5>À très vite!<br/>ENAA</h5>.");

                        return RedirectToAction("Index", "Home");
                    }else{
                        TempData["inputsEmpty"] = "Remplir les champs !";
                        return View(registration);
                    }
                    
                }
                else
                {
                    TempData["cinExiste"] = "Vous êtes déjà inscrit !";
                    return View(registration);
                }
            }catch(Exception ex){
                return View(registration);
            }

        }


        static bool IsValidEmailFormat(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, pattern);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> isConfirmed(bool? confirme, string? id)
        {

            var about = _context.Registration.FirstOrDefault(a => a.Id == id);
            about.Confirmation = confirme;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> ConfirmDetails(string id)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nom,Prenom,Genre,DateDeN,Age,Email,Phone,Cin,BrancheBac,NiveauAcad,FiliereAcad,AutreFiliereAcad,DernierDip,Etablissement,AnneeDiplome,Experience,SiOuiExperience,Domaine,Ville,Adresse,Comment,Confirmation,RegisteredOn")] Registration registration)
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
