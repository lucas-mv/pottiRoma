using Akavache;
using PottiRoma.App.Utils;
using System;
using System.Reactive.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Repositories.Internal
{
    public static class CacheAccess
    {
        public static void Initialize()
        {
            BlobCache.ApplicationName = Constants.AKAVACHE_APP_NAME;
        }

        public async static Task DeleteAll()
        {
            await BlobCache.LocalMachine.InvalidateAll();
            await BlobCache.Secure.InvalidateAll();
        }

        public async static Task Insert<T>(string key, T blob)
        {
            await BlobCache.LocalMachine.InsertObject<T>(key, blob);
        }

        public async static Task InsertExpire<T>(string key, T blob, TimeSpan expiration)
        {
            await BlobCache.LocalMachine.InsertObject<T>(key, blob, expiration);
        }

        public async static Task<T> Get<T>(string key)
        {
            return await BlobCache.LocalMachine.GetObject<T>(key);
        }

        public async static Task InsertSecure<T>(string key, T blob)
        {
            await BlobCache.Secure.InsertObject<T>(key, blob);
        }

        public async static Task<T> GetSecure<T>(string key)
        {
            return await BlobCache.Secure.GetObject<T>(key);
        }
    }
}
