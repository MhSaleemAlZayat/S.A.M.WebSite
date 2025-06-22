using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using S.A.M.Data.Entities.AspIdentity;
using System.Security.Cryptography;

namespace S.A.M.Helper.Services.AspIdentity.UserManager
{
    public class UserManagerService : UserManager<User>, IUserManagerService
    {
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();
        public UserManagerService(IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<UserManager<User>> logger,
            IServiceProvider services)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            UserValidators.RemoveAt(0);
        }

        private IQueryable<User> IncludeUserQuery(IQueryable<User> query, bool userRole, bool userLogin, bool userClaim, bool userToken)
        {
            try
            {
                //if (userClaim) { query = query.Include(u => u.UserClaim); }
                //if (userLogin) { query = query.Include(u => u.UserLogin); }
                //if (userRole) { query = query.Include(u => u.UserRole); }
                //if (userToken) { query = query.Include(u => u.UserToken); }
            }
            catch (Exception exp)
            {
                throw;
            }
            return query;
        }

        public UserManager<Data.Entities.AspIdentity.User> UserManager
        { get { return (UserManager<User>)this; } }

        public async Task<IdentityResult> Add(User user, string password)
        {
            IdentityResult identityResult = new IdentityResult();
            try
            {
                if (string.IsNullOrEmpty(user.Id))
                    user.Id = Guid.NewGuid().ToString();

                identityResult = await CreateAsync(user, password);
            }
            catch (Exception exp)
            {
                throw;
            }
            return identityResult;
        }

        public async Task<User> GetByEamil(string email)
        {
            User user = new();
            try
            {
                user = await UserManager.FindByEmailAsync(email);

            }
            catch (Exception exp)
            {
                throw;
            }
            return user;
        }

        public async Task<User> GetById(string userId)
        {
            User user = new();
            try
            {
                user = await Users.Where(r => r.IsDeleted == false && r.Id == userId).FirstOrDefaultAsync();
            }
            catch (Exception exp)
            {
                throw;
            }
            return user;
        }

        public async Task<List<User>> GetAll(bool active, bool includeUserRole, bool includeUserLogin, bool includeUserClaim, bool includeUserToken)
        {
            List<User> userDTOs = new List<User>();
            try
            {

                IQueryable<User> userQuery = Users.Where(u => u.IsDeleted == false && u.LockoutEnd == null);

                //userQuery = IncludeUserQuery(userQuery, includeUserRole, includeUserLogin, includeUserClaim, includeUserToken);

                ICollection<User> users = await userQuery.ToListAsync();

                if (users != null)
                    userDTOs = users.ToList();
            }
            catch (Exception exp)
            {
                throw;
            }
            return userDTOs;
        }

        public async Task<List<User>> GetByIdList(List<string> userIds, bool active, bool includeUserRole, bool includeUserLogin, bool includeUserClaim, bool includeUserToken)
        {
            List<User> userDTOs = new List<User>();
            try
            {
                IQueryable<User> userQuery = Users.Where(u => u.IsDeleted == false && userIds.Contains(u.Id));

                userQuery = IncludeUserQuery(userQuery, includeUserRole, includeUserLogin, includeUserClaim, includeUserToken);

                ICollection<User> users = await userQuery.ToListAsync();

                if (users != null)
                    userDTOs = users.ToList();
            }
            catch (Exception exp)
            {
                throw;
            }
            return userDTOs;
        }

        public async Task<List<UserClaim>> GetUserCalimsById(string userId)
        {
            try
            {

                var user = await GetById(userId);

                return await GetUserCalimsByUser(user);
            }
            catch (Exception exp)
            {

                throw;
            }
        }

        public async Task<List<UserClaim>> GetUserCalimsByUser(User user)
        {
            try
            {
                if (user == null)
                    throw new Exception("User is null!");


                var claims = await GetClaimsAsync(user);

                return claims.Select(c =>
                    new UserClaim
                    {
                        ClaimValue = c.Value,
                        ClaimType = c.Type
                    }
                ).ToList();
            }
            catch (Exception exp)
            {

                throw;
            }
        }
    }
}