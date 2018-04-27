using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pecanpie.Models;

namespace pecanpie.Controllers
{
    public class HomeController : Controller
    {
        private PecanPieContext _context;
        public HomeController( PecanPieContext context )
        {
            _context = context;
        }

//**************************************************************************** */
//**************************************************************************** */
//**************************************************************************** */
        public IActionResult Index()
        {
            return View( "Index" );
        }

//**************************************************************************** */
//**************************************************************************** */
//**************************************************************************** */
        public IActionResult RegisterForm( UserViewModel model )
        {
            if( ModelState.IsValid )
            {
                PasswordHasher<UserViewModel> Hasher = new PasswordHasher<UserViewModel>();
                model.Password = Hasher.HashPassword( model, model.Password );

                User NewUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                //Handle Success
                _context.Users.Add( NewUser );
                _context.SaveChanges();

                NewUser = _context.Users.SingleOrDefault( a => a.Email == model.Email );
                HttpContext.Session.SetInt32( "UserId", NewUser.UserId );
                return RedirectToAction( "Dashboard", "Game" );// Name of Method, Name of Controller
            }
            return View( "Index" );
        }

//**************************************************************************** */
//**************************************************************************** */
//**************************************************************************** */

        public IActionResult LoginForm( UserLogViewModel model )
        {
            if( ModelState.IsValid )
            {
                
                User ReturnUser = _context.Users.SingleOrDefault( u => u.Email == model.Email );
                if( ReturnUser != null )
                {
                    if( model.Email != null && model.Password != null )
                    {
                        var Hasher = new PasswordHasher<UserLogViewModel>();
                        if( 0 != Hasher.VerifyHashedPassword( model, ReturnUser.Password, model.Password))
                        {
                            HttpContext.Session.SetInt32( "UserId", ReturnUser.UserId );
                            return RedirectToAction( "Dashboard", "Game" );
                        }
                    }
                }
                ViewBag.Login = "Please Register.";
                return View( "Index" );
            }
            return View( "Index" );
        }
//**************************************************************************** */
//**************************************************************************** */
//**************************************************************************** */

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View( "Index" );
        }

        
    }
}
