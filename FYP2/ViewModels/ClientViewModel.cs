using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP2.Models;

namespace FYP2.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Session> Sessions { get; set; }
        public IEnumerable<Referral> Referrals { get; set; }

    }
}