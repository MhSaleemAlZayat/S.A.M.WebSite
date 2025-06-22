using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace S.A.M.Helper.Services.AspIdentity.Role
{
    public class RoleManagerService : RoleManager<Data.Entities.AspIdentity.Role>, IRoleManagerService
    {
        private readonly IRoleValidator<Data.Entities.AspIdentity.Role> _roleValidators;
        private readonly ILogger<RoleManager<Data.Entities.AspIdentity.Role>> _logger;

        public RoleManagerService(IRoleStore<Data.Entities.AspIdentity.Role> store,
            IEnumerable<IRoleValidator<Data.Entities.AspIdentity.Role>> roleValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            ILogger<RoleManager<Data.Entities.AspIdentity.Role>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }

        public async Task<IdentityResult> Add(Data.Entities.AspIdentity.Role role)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                if (string.IsNullOrEmpty(role.Name))
                {
                    throw new ArgumentException("Name not initialized.", nameof(role.Name));
                }


                if (string.IsNullOrEmpty(role.Id))
                    role.Id = Guid.NewGuid().ToString();

                await CreateAsync(role);

            }
            catch (Exception exp)
            {
                throw;
            }
            return result;
        }


        public async Task<bool> Delete(string roleId, string userId)
        {
            bool result = false;
            try
            {
                var roleDB = await Roles.Where(r => r.Id == roleId && r.IsDeleted == false).FirstOrDefaultAsync();
                if (roleDB != null)
                {
                    roleDB.IsDeleted = true;
                    roleDB.UpdatedBy = userId;
                    roleDB.UpdateDate = DateTime.UtcNow;

                    result = (await Store.UpdateAsync(roleDB, new CancellationToken(false))).Succeeded;
                }
            }
            catch (Exception exp)
            {
                throw;
            }
            return result;
        }

        public async Task<List<Data.Entities.AspIdentity.Role>> GetAll()
        {
            try
            {
                var roles = await Roles.Where(r => r.IsDeleted == false).ToListAsync();
                return roles;

            }
            catch (Exception exp)
            {
                throw;
            }
        }

        public async Task<Data.Entities.AspIdentity.Role> GetById(string roleId)
        {
            try
            {
                var role = await Roles.Where(r => r.IsDeleted == false && r.Id == roleId).FirstOrDefaultAsync();
                return role;
            }
            catch (Exception exp)
            {
                throw;
            }
        }
    }
}