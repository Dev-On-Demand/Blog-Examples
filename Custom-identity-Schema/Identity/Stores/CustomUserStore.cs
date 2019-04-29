using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Custom_identity_Schema.DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.EntityFrameworkCore;

namespace Custom_identity_Schema.Identity.Stores
{
    public class CustomUserStore : IUserRoleStore<CusUser>, IUserPasswordStore<CusUser>
    {
        public CustomUserStore(CustomDataContext context)
        {
            _context = context;
        }

        private readonly CustomDataContext _context;

        public Task AddToRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = _context.Roles.Where(item => item.Name.Equals(roleName)).FirstOrDefault();

            if(role != null)
            { 
                CusUserRole assignment = new CusUserRole() {  Id = role.Id, UserId = user.Id };
                _context.UserRoles.Add(assignment);
                _context.SaveChanges();
            }

            return Task.FromResult((CusUser)null);
        }

        public async Task<IdentityResult> CreateAsync(CusUser user, CancellationToken cancellationToken)
        {
            _context.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(CusUser user, CancellationToken cancellationToken)
        {
            _context.Remove(user);

            int i = await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(i == 1 ? IdentityResult.Success : IdentityResult.Failed());
        }

        public async Task<CusUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            if (int.TryParse(userId, out int id))
            {
                return await _context.Users.FindAsync(id);
            }
            else
            {
                return await Task.FromResult((CusUser)null);
            }
        }

        public async Task<CusUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _context.Users
                           .AsAsyncEnumerable()
                           .SingleOrDefault(p => p.Email.Equals(normalizedUserName, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(GetNormalizedUserNameAsync));
        }

        public Task<IList<string>> GetRolesAsync(CusUser user, CancellationToken cancellationToken)
        {
            var assignments = _context.UserRoles.Include(record => record.Role).Where(item => item.UserId.Equals(user.Id));

            List<string> roles = new List<string>();

            foreach(var record in assignments)
            {
                roles.Add(record.Role.Name);
            }

            return Task.FromResult<IList<string>>(roles);
        }

        public Task<string> GetUserIdAsync(CusUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(CusUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<IList<CusUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            IList<CusUser> users = new List<CusUser>();

            var role = _context.Roles.Where(item => item.Name.Equals(roleName)).FirstOrDefault();

            if(role != null)
            {
                var assignments = _context.UserRoles.Where(item => item.RoleId.Equals(role.Id));

                foreach(var record in assignments)
                {
                    users.Add(record.User);
                }
            }

            return Task.FromResult<IList<CusUser>>(users);
        }

        public Task<bool> IsInRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            bool inRole = false;

            var role = _context.Roles.Where(item => item.Name.Equals(roleName)).FirstOrDefault();

            if(role != null)
            { 
                var assignment = _context.UserRoles.Where(item => item.UserId.Equals(user.Id) && item.RoleId.Equals(role.Id)).FirstOrDefault();

                inRole = assignment != null;
            }

            return Task.FromResult<bool>(inRole);
        }

        public Task RemoveFromRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = _context.Roles.Where(item => item.Name.Equals(roleName)).FirstOrDefault();

            if(role != null)
            {
                var assignments = _context.UserRoles.Where(item => item.UserId.Equals(user.Id) && item.RoleId.Equals(role.Id));

                _context.UserRoles.RemoveRange(assignments.ToArray());
                _context.SaveChanges();
            }

            return Task.FromResult<CusUser>(null);
        }

        public Task SetNormalizedUserNameAsync(CusUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult((object)null);
        }

        public Task SetUserNameAsync(CusUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(nameof(SetUserNameAsync));
        }

        public async Task<IdentityResult> UpdateAsync(CusUser user, CancellationToken cancellationToken)
        {
            try
            { 
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return IdentityResult.Failed();
            }

            return IdentityResult.Success;
        }

        public Task SetPasswordHashAsync(CusUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult((object)null);
        }

        public Task<string> GetPasswordHashAsync(CusUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(CusUser user, CancellationToken cancellationToken)
        {
            return !String.IsNullOrWhiteSpace(user.PasswordHash);
        }

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
        #endregion
    }
}
