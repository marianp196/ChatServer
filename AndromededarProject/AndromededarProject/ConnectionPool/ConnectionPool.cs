using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.ConnectionPool
{
    /// <summary>
    /// Müsste wohl mal grundsätzlich überarbeitet werden... sorry
    /// </summary>
    /// <typeparam name="TConnectionID"></typeparam>
    public class ConnectionPool<TConnectionID> : IConnectionPoolWriter<TConnectionID>, IConnectionPoolReader<TConnectionID>
    { 
        public ConnectionPool(IDictionary<Adress, StorageObject<TConnectionID>> storage, IUserReader userReader)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _userReader = userReader;
        }
        
        public async Task Push(string user, TConnectionID connectionId)
        {
            var result = await _userReader.GetUserByUserName(user);
            if (!result.Success)
                throw new KeyNotFoundException(user);

            var adress = result.Value.Adress;           
            _storage.Add(adress, new StorageObject<TConnectionID> { User = user, Value = connectionId });          
        }

        public void Remove(string user)
        {
            var adress = getAdress(user);
            _storage.Remove(adress);
        }

        public bool TryRead(Adress adress, out TConnectionID connectionID)
        {             
            bool  result  = _storage.TryGetValue(adress, out var obj);
            connectionID = default(TConnectionID);
            if (result)
                connectionID = obj.Value;
            return result;
        }

        private Adress getAdress(string user)
        {
            return _storage.Where(x => x.Value.User == user).Select(x => x.Key).FirstOrDefault();
        }      

        private readonly IDictionary<Adress, StorageObject<TConnectionID>> _storage;
        private readonly IUserReader _userReader;
    }

    public class StorageObject<T>
    {
        public string User;
        public T Value;
    }
}
