using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SIL.CommadProcessor.Dispatcher;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Contact;
using SIL.Web.Core;
using SIL.Web.Core.ActionFilters;
using SIL.Web.Core.Models;
using SIL.Web.ViewModels;
using SIL.Web.Helpers;

namespace SIL.Web.Controllers
{
    [CompressResponse]
    [SILAuthorise(Roles.User, Roles.Admin)]
    public class ContactController : Controller
    {
        private ICommandBus _commandBus;
        private IContactRepository _contactRepository;
        private IUnitOfWork _unitOfWork;
        private ICompanyRepository _customerRepository;

        public ContactController(ICommandBus commandbus, IContactRepository contactRepository, ICompanyRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
            this._commandBus = commandbus;
            this._customerRepository = customerRepository;
        }


        public ActionResult Index()
        {
            var con = _contactRepository.GetAll();
            
            return View(con);
        }

        public ActionResult Create()
        {
            var viewModel = new ContactViewModel();
            var customer = _customerRepository.GetAll();
            viewModel.Customers = customer.ToSelectItemList(c => c.Name, c => c.CustomerId.ToString());

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(ContactViewModel cvm)
        {
            var command = Mapper.Map<ContactViewModel, CreateOrUpdateContactCommand>(cvm);

            if (ModelState.IsValid)
            {
                var result = _commandBus.Submit(command);
                if (result.Success) return RedirectToAction("Index");
            }

            //var contact = _contactRepository.GetAll();
            ////c.Contacts = contact.ToSelectListOfContacts(c.ContactId);

            if (cvm.ContactId == 0)
                return View("Create", cvm);
            else
                return View("Edit", cvm);
        }


        public ActionResult Edit(int id)
        {
            var contact = _contactRepository.GetById(id);
            var contactVm = Mapper.Map<Contact, ContactViewModel>(contact);

            return View(contactVm);

        }

        public ActionResult ContactInfo([Bind(Prefix = "id")] int Contact_Id)
        {
            var contact = _contactRepository.GetById(Contact_Id);
            var contactVm = Mapper.Map<Contact, ContactViewModel>(contact);
            return View(contactVm);
        }
        public ActionResult Delete(int id)
        {
            var command = new DeleteContactCommand { ContacId = id };
            var result = _commandBus.Submit(command);
            var websites = _contactRepository.GetAll();
            return View(websites);

        }

    }
}