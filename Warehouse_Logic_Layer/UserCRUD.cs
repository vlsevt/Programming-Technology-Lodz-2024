using WarehouseDataLayer.APIs;
using WarehouseLogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLogicLayer
{
    internal class UserCRUD : IUserCRUD
    {
        private IDataRepository _dataRepository;

        public UserCRUD(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        private IUserDTO Map(IUser User)
        {
            return new UserDTO(User.ID, User.Name, User.Surname);
        }

        public void AddUser(int UserID, string Name, string Surname)
        {
            this._dataRepository.AddUser(UserID, Name, Surname);
        }

        public IUserDTO GetUser(int UserID)
        {
            return this.Map(this._dataRepository.GetUser(UserID));
        }

        public Dictionary<int, IUserDTO> GetUsers()
        {
            Dictionary<int, IUserDTO> Users = new Dictionary<int, IUserDTO>();

            foreach (IUser User in (this._dataRepository.GetUsers()).Values)
            {
                Users.Add(User.ID, this.Map(User));
            }

            return Users;
        }

        public void UpdateUser(int UserID, string Name, string Surname)
        {
            this._dataRepository.UpdateUser(UserID, Name, Surname);
        }

        public void DeleteUser(int UserID)
        {
            this._dataRepository.DeleteUser(UserID);
        }
    }
}

