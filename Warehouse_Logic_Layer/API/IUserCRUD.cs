using WarehouseDataLayer.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer.API
{
    public interface IUserCRUD
    {
        static IUserCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
        {
            return new UserCRUD(dataRepository ?? IDataRepository.CreateDatabase());
        }

        void AddUser(int UserID, string Name, string Surname);
        IUserDTO GetUser(int UserID);
        Dictionary<int, IUserDTO> GetUsers();
        void UpdateUser(int UserID, string Name, string Surname);
        void DeleteUser(int UserID);
    }
}
