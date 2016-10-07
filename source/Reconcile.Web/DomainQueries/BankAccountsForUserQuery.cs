using System.Linq;
using Magrathea;
using Reconcile.Web.DomainModels;

namespace Reconcile.Web.DomainQueries
{
    public class BankAccountsForUserQuery : Query<BankAccount>
    {
        public BankAccountsForUserQuery(string userId)
        {
            ContextQuery = c => c.AsQueryable<BankAccount>().Where(x => x.AspNetUserId == userId);
        }
    }
}