using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Command;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Company;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;

namespace SIL.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class CustomerController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly ICompanyRepository _customerRepository;
        private readonly IContactRepository _contactRepository;
        public CustomerController(ICompanyRepository companyRepository, IContactRepository contactRepository, ICommandBus commandBus)
        {
            this._contactRepository = contactRepository;
            this._customerRepository = companyRepository;
            this._commandBus = commandBus;
        }

        public ActionResult CustomerInfo([Bind(Prefix="id")] int Companies_Id)
        {
            var company = _customerRepository.GetById(Companies_Id);
            var viewModel = Mapper.Map<Customer, CustomerViewModel>(company);
            return View(viewModel);
        }

        public ActionResult Index()
        {
            var company = _customerRepository.GetAll();
            return View(company);
        }

        public ActionResult Details(int id = 0)
        {
            var company = _customerRepository.GetById(id);
            var viewModel = Mapper.Map<Customer, CustomerViewModel>(company);
            return View(viewModel);
        }


        public ActionResult Create()
        {
            var viewModel = new CustomerViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerViewModel c)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<CustomerViewModel, CreateOrUpdateCompanyCommand>(c);
                //IEnumerable<ValidationResult> errors = _commandBus.Validate(command);
                //ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = _commandBus.Submit(command);
                    if (result.Success) return RedirectToAction("Index");
                }
            }


            //var contact = _contactRepository.GetAll();
            ////c.Contacts = contact.ToSelectListOfContacts(c.ContactId);
            ////if fail
            if (c.CustomerId == 0)
                return View("Create", c);
            else
                return View("Edit", c);
        }



        [HttpPost]        
        public ActionResult Create(CustomerViewModel c)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<CustomerViewModel, CreateOrUpdateCompanyCommand>(c);
                //IEnumerable<ValidationResult> errors = _commandBus.Validate(command);
                //ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = _commandBus.Submit(command);
                    if (result.Success) return RedirectToAction("Index");
                }
            }
            //if fail
            if (c.CustomerId == 0)
                return View("Create", c);
            else
                return View("Edit", c);
        }

        public ActionResult Edit(int id)
        {
            var company = _customerRepository.GetById(id);
            var viewModel = Mapper.Map<Customer, CustomerViewModel>(company);
            var contact = _contactRepository.GetAll();
        //    viewModel.Contacts = contact.ToSelectListOfContacts(company.ContactId);
            return View(viewModel);
        }
        public ActionResult Delete(int id)
        {
           var command = new DeleteCustomerCommand { CustomerId = id };
           var result = _commandBus.Submit(command);
           var company = _customerRepository.GetAll();
           return View(company);
        }

    }
}
