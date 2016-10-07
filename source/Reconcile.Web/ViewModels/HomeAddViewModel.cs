using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using System.Web.Profile;

namespace Reconcile.Web.ViewModels
{
    public class HomeAddViewModel
    {
        public HomeAddViewModel()
        {
            AccountTypeListItems = new List<SelectListItem>();
            StatusListItems = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Account Type")]
        public string SelectedAccountType { get; set; }

        public IEnumerable<SelectListItem> AccountTypeListItems { get; set; }

        [Display(Name = "Status")]
        public string SelectedStatus { get; set; }

        public IEnumerable<SelectListItem> StatusListItems { get; set; }

        [Display(Name = "Yield (APY)")]
        public decimal YieldPercent { get; set; }

        [Display(Name = "Monthly Fee")]
        public decimal MonthlyFee { get; set; }

        [Display(Name = "Begining Balance")]
        public decimal BeginingBalance { get; set; }
    }
}