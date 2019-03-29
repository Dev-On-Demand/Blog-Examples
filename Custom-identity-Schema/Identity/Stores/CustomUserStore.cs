using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Custom_identity_Schema.DataModel;
using Microsoft.AspNetCore.Identity;

namespace Custom_identity_Schema.Identity.Stores
{
    public class CustomUserStore : IUserRoleStore<CusUser>
    {
        public CustomUserStore(CustomDataContext context)
        {
            _context = context;
        }

        private readonly CustomDataContext _context;

        public Task AddToRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CusUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CusUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(CusUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CusUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(CusUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(CusUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(CusUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(CusUser user, CancellationToken cancellationToken)
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
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomUserStore()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
