using System.Web;
using System.Web.Mvc;
using Magrathea;
using Reconcile.Web.DomainModels;
using Reconcile.Web.DomainQueries;
using Reconcile.Web.ViewModels;

namespace Reconcile.Web.Controllers
{
    public class ImportController : Controller
    {
        private readonly Repository _repository;

        public ImportController()
        {
            var context = new ReconcileDataContext();
            _repository = new Repository(context);
        }

        public ActionResult Index(int id)
        {
            var account = _repository.Find(new BankAccountById(id));

            var model = new ImportIndexViewModel
            {
                AccountId = account.Id,
                Name = account.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, HomeIndexViewModel model)
        {
            // Import AccountTransactions into account

            // Update existing

            // Compare with Pending for possible match

            // Allow user to reconcile 

            return View();
        }
    }
}