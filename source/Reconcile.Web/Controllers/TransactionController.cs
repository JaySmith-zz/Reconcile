using System.Collections.Generic;
using System.Web.Mvc;
using Reconcile.Web.DomainModels;
using Reconcile.Web.ViewModels;

namespace Reconcile.Web.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            var model = new TransactionIndexViewModel();
            model.Balance = 0.00d;
            model.AvailableCash = 0.00d;
            model.TotalFees = 0.00d;

            model.Accounts = new List<BankAccount>();

            return View();
        }
    }
}