using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using SIL.Filters;
using SIL.Models;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Web.Core.Authentication;
using SIL.Domain;
using SIL.Core.Common;
using SIL.Web.ViewModels;
using SIL.Service.Commands.Security;
using AutoMapper;
using SIL.Web.Core.Models;
using SIL.CommadProcessor.Command;
using SIL.Web.Core.Extensions;

namespace SIL.Controllers
{

    public class AccountController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly IUserRepository userRepository;
        private readonly IFormsAuthentication formAuthentication;


        public AccountController(ICommandBus commandBus, IUserRepository userRepository, IFormsAuthentication formAuthentication)
        {
            this.commandBus = commandBus;
            this.userRepository = userRepository;
            this.formAuthentication = formAuthentication;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return ContextDependentView();
        }

        public ActionResult LogOff()
        {
            formAuthentication.Signout();
            return RedirectToAction("Index", "Home");
        }


        private bool ValidatePassword(User user, string password)
        {
            var encoded = Md5Encrypt.Md5EncryptPassword(password);
            return user.PasswordHash.Equals(encoded);
        }

        private ActionResult ContextDependentView()
        {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.FormAction = "Json" + actionName;
                return PartialView();
            }
            else
            {
                ViewBag.FormAction = actionName;
                return View();
            }
        }

        public ActionResult Register()
        {
            return ContextDependentView();
        }    
     

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserViewModel form)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<UserViewModel, UserRegisterCommand>(form);
                command.Activated = true;
                command.RoleId = (Int32)UserRoles.User;
               // IEnumerable<ValidationResult> errors = commandBus.Validate(command);
              //  ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (result.Success)
                    {
                        User user = userRepository.Get(u => u.Email == form.Email);
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                          UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                              user));
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "An unknown error occurred.");
                    }
                }
                // If we got this far, something failed, redisplay form
                return View(form);
            }

            // If we got this far, something failed
            return Json(new { errors = GetErrorsFromModelState() });
        }

        [HttpPost]
        public JsonResult JsonLogin(LogOnViewModel form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Get(u => u.Email == form.UserName && u.Activated == true);
                if (user != null)
                {
                    if (ValidatePassword(user, form.Password))
                    {
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                                 UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                                     user));

                        return Json(new { success = true, redirect = returnUrl });


                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed
            return Json(new { errors = GetErrorsFromModelState(), success = false });
        }

        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel form)
        {
            if (ModelState.IsValid)
            {
               SILUser silUser = HttpContext.User.GetSilUser();
                var command = new ChangePasswordCommand
                {
                    UserId = silUser.UserId,
                    OldPassword = form.OldPassword,
                    NewPassword = form.NewPassword
                };
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (result.Success)
                    {
                        return RedirectToAction("ChangePasswordSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(form);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult JsonRegister(UserViewModel form)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<UserViewModel, UserRegisterCommand>(form);
                command.Activated = true;
                command.RoleId = (Int32)UserRoles.User;
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (result.Success)
                    {
                        User user = userRepository.Get(u => u.Email == form.Email);
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                          UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                              user));
                        return Json(new { success = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "An unknown error occurred.");
                    }
                }
                // If we got this far, something failed
                return Json(new { errors = GetErrorsFromModelState() });
            }

            // If we got this far, something failed
            return Json(new { errors = GetErrorsFromModelState() });
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnViewModel form, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Get(u => u.Email == form.UserName && u.Activated == true);
                if (user != null)
                {
                    if (ValidatePassword(user, form.Password))
                    {
                        formAuthentication.SetAuthCookie(this.HttpContext,
                                                                 UserAuthenticationTicketBuilder.CreateAuthenticationTicket(
                                                                     user));

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            // If we got this far, something failed
            return View("Login", form);
        }
    }
}
