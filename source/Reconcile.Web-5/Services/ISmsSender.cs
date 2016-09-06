using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reconcile.Web_5.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
