using SalesAppAPI.Models;
using SalesAppAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesAppAPI.Interfaces.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesAppDbContext appDbContext;

         public UserRepository(SalesAppDbContext appDbContext)

        {
            this.appDbContext = appDbContext;   
        }




        public async Task<User> AddUser(User user)
        {
            try
            {
                var result = await appDbContext.Users.AddAsync(user);
                await appDbContext.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception)
            {

                throw;
            } 

        }

        public async void DeleteUser(int userId)
        {
            var result = await appDbContext.Users
                   .FirstOrDefaultAsync(u => u.Id == userId);
            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int userId)
        {
            return  await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
     

        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await appDbContext.Users
                  .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (result != null)
            {
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.Password = user.Password;
                result.CreateAt = user.CreateAt;
                result.Gender = user.Gender;            

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
