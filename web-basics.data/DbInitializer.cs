using System.Linq;
using web_basics.data.Entities;

namespace web_basics.data
{
    public static class DbInitializer
    {
        private static bool cats;
        private static bool accounts;
        private static bool owners;

        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();
            if (!cats)
                if (!context.Cats.Any())
                {
                    context.Cats.AddRange(new Cat {Name = "Barsik", Age = 3}, new Cat {Name = "Kozkii", Age = 4},
                        new Cat {Name = "Murka", Age = 13}, new Cat {Name = "Bony", Age = 2});
                    cats = true;
                }

            if (!accounts)
                if (!context.Accounts.Any())
                {
                    context.Accounts.AddRange(
                        new Account {Email = "user1@email.com", Password = "111111", Role = Role.User},
                        new Account {Email = "user2@email.com", Password = "222222", Role = Role.User},
                        new Account {Email = "admin@email.com", Password = "password", Role = Role.Admin});
                    accounts = true;
                }

            if (!owners)
                if (!context.Owners.Any())
                {
                    context.Owners.AddRange(new Owner {UserId = 1, CatId = 1}, new Owner {UserId = 2, CatId = 3},
                        new Owner {UserId = 2, CatId = 4});
                    owners = true;
                }

            context.SaveChanges();
        }
    }
}