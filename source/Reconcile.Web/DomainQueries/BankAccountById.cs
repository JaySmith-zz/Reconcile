using System.Linq;
using Magrathea;
using Reconcile.Web.DomainModels;

namespace Reconcile.Web.DomainQueries
{
    public class BankAccountById : Scalar<BankAccount>
    {
        public BankAccountById(int id)
        {
            ContextQuery = c => c.AsQueryable<BankAccount>().FirstOrDefault(x => x.Id == id);
        }
    }
}