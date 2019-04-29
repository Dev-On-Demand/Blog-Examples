using System;
using System.Threading;
using System.Threading.Tasks;
using Custom_identity_Schema.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Linq;

namespace Custom_identity_Schema.Identity.Stores
{
    public class CustomRoleStore : IRoleStore<CusRole>
    {
        public CustomRoleStore(CustomDataContext context)
        {
            _context = context;
        }

        private readonly CustomDataContext _context;

        public async Task<IdentityResult> CreateAsync(CusRole role, CancellationToken cancellationToken)
        {
            _context.Add(role);

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(IdentityResult.Success);
        }

        public async Task<IdentityResult> DeleteAsync(CusRole role, CancellationToken cancellationToken)
        {
            _context.Remove(role);

            int i = await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(i == 1 ? IdentityResult.Success : IdentityResult.Failed());
        }


        public async Task<CusRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            if (int.TryParse(roleId, out int id))
            {
                return await _context.Roles.FindAsync(id);
            }
            else
            {
                return await Task.FromResult((CusRole)null);
            }
        }

        public async Task<CusRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _context.Roles
                           .AsAsyncEnumerable()
                           .SingleOrDefault(p => p.Name.Equals(normalizedRoleName, StringComparison.OrdinalIgnoreCase), cancellationToken);
        }

        public Task<string> GetNormalizedRoleNameAsync(CusRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(CusRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(CusRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(CusRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult((object)null);
        }

        public Task SetRoleNameAsync(CusRole role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(CusRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
