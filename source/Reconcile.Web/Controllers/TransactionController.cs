using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Magrathea;
using Microsoft.AspNet.Identity;
using Reconcile.Web.DomainModels;
using Reconcile.Web.DomainQueries;
using Reconcile.Web.ViewModels;

namespace Reconcile.Web.Controllers
{
    public class TransactionController : Controller
    {
        private Repository _repository;

        public TransactionController()
        {
            var context = new ReconcileDataContext();
            _repository = new Repository(context);
        }

        // GET: Transaction
        public ActionResult Index()
        {
            var bankAccounts = _repository.Find(new BankAccountsForUserQuery(User.Identity.GetUserId())).ToList();

            var model = new TransactionIndexViewModel {Accounts = bankAccounts};

            //model.Balance = 0.00d;
            //model.AvailableCash = 0.00d;
            //model.TotalFees = 0.00d;

            return View(model);
        }

        public ActionResult View(int accountId)
        {
            var bankAccount = _repository.Find(new BankAccountById(accountId));

            var model = new TransactionViewAccountViewModel();

            model.AccountId = bankAccount.Id;
            model.AccountName = bankAccount.Name;
            model.AccountTransactions = bankAccount.Transactions;

            return View(model);
        }
    }

    public class TransactionViewAccountViewModel
    {
        public ICollection<Transaction> AccountTransactions { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}