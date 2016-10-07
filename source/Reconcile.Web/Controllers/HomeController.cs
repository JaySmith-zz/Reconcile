using System.Collections.Generic;
using System.Web.Mvc;
using Magrathea;
using Microsoft.AspNet.Identity;
using Reconcile.Web.DomainModels;
using Reconcile.Web.DomainQueries;
using Reconcile.Web.ViewModels;

namespace Reconcile.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Repository _repository;

        public HomeController()
        {
            var context = new ReconcileDataContext();
            _repository = new Repository(context);
        }

        public ActionResult Index()
        {
            var bankAccounts = _repository.Find(new BankAccountsForUserQuery(User.Identity.GetUserId()));

            var model = new List<HomeIndexViewModel>();

            foreach (var bankAccount in bankAccounts)
            {
                var modelItem = new HomeIndexViewModel
                {
                    AccountId = bankAccount.Id,
                    AccountName = bankAccount.Name,
                    //AccountBalance = bankAccount.AvailableBalance.HasValue ? bankAccount.AvailableBalance.Value : 0,
                    AccountType = bankAccount.AccountType
                    
                };

                model.Add(modelItem);
            }

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new HomeAddViewModel();

            model.AccountTypeListItems = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = ""},
                new SelectListItem {Value = "Checking", Text = "Checking"},
                new SelectListItem {Value = "Savings", Text = "Savings"}
            };

            model.StatusListItems = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = ""},
                new SelectListItem {Value = "Open", Text = "Open"},
                new SelectListItem {Value = "Closed", Text = "Closed"}
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(HomeAddViewModel model)
        {
            var account = new BankAccount
            {
                Name = model.Name,
                AccountType = model.SelectedAccountType,
                Status = model.SelectedStatus,
                YieldPercent = model.YieldPercent,
                BeginingBalance = model.BeginingBalance,
                AspNetUserId = User.Identity.GetUserId()
            };

            _repository.Context.Add(account);
            _repository.Context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var item = _repository.Find(new BankAccountById(id));

            var model = new HomeAddViewModel
            {
                Id = item.Id,
                SelectedStatus = item.Status,
                SelectedAccountType = item.AccountType,
                Name = item.Name,
                BeginingBalance = item.BeginingBalance,
                YieldPercent = item.YieldPercent,
                AccountTypeListItems = new List<SelectListItem>
                {
                    new SelectListItem {Value = "", Text = ""},
                    new SelectListItem {Value = "Checking", Text = "Checking"},
                    new SelectListItem {Value = "Savings", Text = "Savings"}
                },
                StatusListItems = new List<SelectListItem>
                {
                    new SelectListItem {Value = "", Text = ""},
                    new SelectListItem {Value = "Open", Text = "Open"},
                    new SelectListItem {Value = "Closed", Text = "Closed"}
                }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HomeAddViewModel model)
        {
            var item = _repository.Find(new BankAccountById(model.Id));

            item.Name = model.Name;
            item.AccountType = model.SelectedAccountType;
            item.Status = model.SelectedStatus;
            item.YieldPercent = model.YieldPercent;
            item.BeginingBalance = model.BeginingBalance;

            _repository.Context.Update(item);
            _repository.Context.Commit();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}