using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace web_basics.data.Repositories
{
    public class Account
    {
        private readonly WebBasicsDBContext _context;

        public Account(IConfiguration configuration)
        {
            _context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Account> Get()
        {
            var accounts = _context.Accounts.ToList();
            return accounts;
        }

        public Entities.Account Create(Entities.Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account;
        }

        public Entities.Account Update(Entities.Account account)
        {
            var acc = _context.Accounts.Find(account.Id);
            acc.Role = account.Role;
            _context.Accounts.Update(acc);
            _context.SaveChanges();
            return acc;
        }

        public bool Delete(int id)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
                return false;

            _context.Accounts.Remove(acc);
            _context.SaveChanges();

            return true;
        }
    }
}