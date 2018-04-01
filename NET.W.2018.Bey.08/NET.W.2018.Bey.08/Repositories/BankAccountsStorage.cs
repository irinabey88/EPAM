namespace NET.W._2018.Bey._08.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Enum;
    using Exception;
    using Interfaces;
    using Models.BankAccount;

    /// <summary>
    /// Provides abank account storage
    /// </summary>
    public class BankAccountsStorage : IBankAccountRepository
    {
        /// <summary>
        /// Source file name
        /// </summary>
        private readonly string _fileStorage;

        /// <summary>
        /// Enumeration of accounts
        /// </summary>
        private IEnumerable<BankAccount> _accountsList;

        /// <summary>
        /// Get instance of bank account storage
        /// </summary>
        /// <param name="fileName">Source file name</param>
        public BankAccountsStorage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            this._fileStorage = fileName;
            this._accountsList = this.Load() ?? throw new ArgumentNullException(nameof(_accountsList));
        }

        public BankAccount this[string id]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var bankAccount = this.Get(id);

                return bankAccount;
            }
        }

        public IEnumerable<BankAccount> Load()
        {
            List<BankAccount> bankAccountList = new List<BankAccount>();

            using (var fs = new FileStream(this._fileStorage, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var readedAccount = LoadData(reader);

                        if (readedAccount == null)
                        {
                            throw new ArgumentNullException(nameof(readedAccount));
                        }

                        bankAccountList.Add(readedAccount);
                    }
                }
            }

            return bankAccountList;
        }

        public BankAccount Get(BankAccount model)
        {            
            return this.Get(model.BankUser.UserId);
        }

        public BankAccount Get(string id)
        {
            BankAccount findAccount = null;

            foreach (var accout in this._accountsList)
            {
                if (accout.AccountId.Equals(id))
                {
                    findAccount = accout;
                }
            }

            return findAccount;
        }

        public BankAccount Add(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this.Get(model.AccountId) != null)
            {
                throw new AddBankAccountException(model.AccountId);
            }

            using (var fs = new FileStream(this._fileStorage, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    SaveAccount(writer, model);
                }
            }

            this._accountsList = this._accountsList.Concat(new[] { model });

            return model;
        }

        public BankAccount Delete(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var deletedAccount = this[model.AccountId] ?? throw new DeleteAccountException(model.AccountId);
            this._accountsList = this._accountsList.Except(new List<BankAccount> { deletedAccount });

            if (!this._accountsList.Any())
            {
                File.Delete(this._fileStorage);
                return model;
            }

            SaveAccountsList();
            return model;
        }

        public BankAccount Update(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this._accountsList.ToList().Contains(model))
            {
                throw new AddBankAccountException(model.AccountId);
            }

            var deletedAccount = this[model.AccountId] ?? throw new DeleteAccountException(model.AccountId);
            this._accountsList = this._accountsList.Except(new List<BankAccount> { deletedAccount });
            this._accountsList = this._accountsList.Concat(new[] { model });

            SaveAccountsList();
            return model;
        }   

        public IEnumerable<BankAccount> GetAllElements()
        {
            return this._accountsList;
        }

        #region Private methods

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

        private void SaveAccountsList()
        {
            using (var fs = new FileStream(this._fileStorage, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (var account in this._accountsList)
                    {
                        SaveAccount(writer, account);
                    }
                }
            }
        }

        private void SaveAccount(BinaryWriter writer, BankAccount account)
        {
            writer.Write(account.AccountId);
            writer.Write((int)account.TypeAccount);
            writer.Write(account.BankUser.UserId);
            writer.Write(account.BankUser.FirstName);
            writer.Write(account.BankUser.LastName);
            writer.Write(account.Amount);
            writer.Write(account.Bonus);
            writer.Write(account.IsClosed);
            writer.Flush();
        }

        private BankAccount LoadData(BinaryReader reader)
        {
            var accountId = reader.ReadString();
            var type = reader.ReadInt32();
            var userId = reader.ReadString();
            var firstName = reader.ReadString();
            var lastName = reader.ReadString();                        
            var amount = reader.ReadUInt32();
            var bonus = reader.ReadUInt32();
            var isClosed = reader.ReadBoolean();

            DataValidation(accountId, userId, firstName, lastName);

            if (!System.Enum.IsDefined(typeof(BankAccountType), type))
            {
                throw new IncorrectBankAccountTypeException(type);
            }

            return CreateAccounts(accountId, userId, firstName, lastName, (BankAccountType)type, amount, bonus, isClosed);
        }

        private BankAccount CreateAccounts(string accountId, string userId, string firstName, string lastName, BankAccountType typeAccount, uint amount, uint bonus, bool isClosed)
        {
            BankAccount newAccount;
            BankUser bankUser = new BankUser(userId, firstName, lastName);

            switch (typeAccount)
            {
                case BankAccountType.Base:
                    newAccount = new BaseAccount(bankUser, accountId, typeAccount, amount, bonus, isClosed);
                    break;
                case BankAccountType.Gold:
                    newAccount = new GoldAccount(bankUser, accountId, typeAccount, amount, bonus, isClosed);
                    break;
                case BankAccountType.Platinum:
                    newAccount = new PlatinumAccount(bankUser, accountId, typeAccount, amount, bonus, isClosed);
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(typeAccount));
            }

            return newAccount;
        }
        #endregion
    }
}