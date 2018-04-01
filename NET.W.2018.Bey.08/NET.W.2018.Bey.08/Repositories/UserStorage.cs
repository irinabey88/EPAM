namespace NET.W._2018.Bey._08.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Exception;
    using Exception.User;
    using Interfaces;
    using Models.BankAccount;

    /// <summary>
    /// Provides user storage
    /// </summary>
    public class UserStorage : IUserRepository
    {
        /// <summary>
        /// Source file name
        /// </summary>
        private readonly string _fileStorage;

        /// <summary>
        /// Enumeration of users
        /// </summary>
        private IEnumerable<BankUser> _listUser;

        /// <summary>
        /// Provides instance of users storage
        /// </summary>
        /// <param name="fileStorage">Source file name</param>
        public UserStorage(string fileStorage)
        {
            if (string.IsNullOrWhiteSpace(fileStorage))
            {
                throw new ArgumentNullException($"{nameof(fileStorage)}");
            }

            this._fileStorage = fileStorage;
            this._listUser = this.Load() ?? throw new ArgumentNullException(nameof(_listUser));
        }

        public BankUser this[string id]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var user = this.Get(id);

                return user;
            }
        }

        public IEnumerable<BankUser> Load()
        {
            List<BankUser> usersList = new List<BankUser>();

            using (var fs = new FileStream(this._fileStorage, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var readedUser = LoadData(reader);

                        if (readedUser == null)
                        {
                            throw new ArgumentNullException(nameof(readedUser));
                        }

                        usersList.Add(readedUser);
                    }
                }
            }

            return usersList;
        }

        public BankUser Get(string id)
        {
            BankUser findBankUser = null;

            foreach (var user in this._listUser)
            {
                if (user.UserId.Equals(id))
                {
                    findBankUser = user;
                }
            }

            return findBankUser;
        }

        public BankUser Get(BankUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return this.Get(model.UserId);
        }

        public BankUser Add(BankUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this.Get(model.UserId) != null)
            {
                throw new AddUserException(model.UserId);
            }

            var user = FindUserWithEqualsData(model.FirstName, model.LastName);
            if (user != null)
            {
                throw new EqualsUserException(model.FirstName, model.LastName);
            }

            using (var fs = new FileStream(this._fileStorage, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    SaveUser(writer, model);
                }
            }

            this._listUser = this._listUser.Concat(new[] { model });

            return model;
        }

        public BankUser Delete(BankUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var deletedAccount = this[model.UserId] ?? throw new DeleteUserException(model.UserId);
            this._listUser = this._listUser.Except(new List<BankUser> { deletedAccount });

            if (!this._listUser.Any())
            {
                File.Delete(this._fileStorage);
                return model;
            }

            SaveUsersList();
            return model;
        }

        public BankUser Update(BankUser model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this._listUser.ToList().Contains(model))
            {
                throw new AddBankAccountException(model.UserId);
            }

            var deletedUser = this[model.UserId] ?? throw new DeleteUserException(model.UserId);
            this._listUser = this._listUser.Except(new List<BankUser> { deletedUser });
            this._listUser = this._listUser.Concat(new[] { model });

            SaveUsersList();
            return model;
        }

        public IEnumerable<BankUser> GetAllElements()
        {
            return this._listUser;
        }

        #region Private methods

        private BankUser FindUserWithEqualsData(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            BankUser finedUser = null;

            foreach (var user in this._listUser)
            {
                if (user.FirstName.Equals(firstName) && user.LastName.Equals(lastName))
                {
                    finedUser = user;
                    break;
                }
            }

            return finedUser;
        }

        private void SaveUser(BinaryWriter writer, BankUser bankUser)
        {
            writer.Write(bankUser.UserId);
            writer.Write(bankUser.FirstName);
            writer.Write(bankUser.LastName);           
            writer.Flush();
        }

        private BankUser LoadData(BinaryReader reader)
        {
            var userId = reader.ReadString();
            var firstName = reader.ReadString();
            var lastName = reader.ReadString();

            DataValidation(userId, firstName, lastName);

            return new BankUser(userId, firstName, lastName);
        }

        private void DataValidation(params string[] inputData)
        {
            foreach (var element in inputData)
            {
                if (string.IsNullOrWhiteSpace(element))
                {
                    throw new ArgumentNullException(nameof(element));
                }
            }
        }

        private void SaveUsersList()
        {
            using (var fs = new FileStream(this._fileStorage, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (var account in this._listUser)
                    {
                        SaveUser(writer, account);
                    }
                }
            }
        }

        #endregion
    }
}