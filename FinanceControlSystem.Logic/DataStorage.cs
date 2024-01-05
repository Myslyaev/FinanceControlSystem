using FinanceControlSystem.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceControlSystem.Logic
{
    public class DataStorage
    {
        [JsonInclude]
        private Dictionary<int, TransactionCategoryModel> _transactionCategories;
        [JsonInclude]
        private Dictionary<int, TransactionModel> _transactions;
        [JsonInclude]
        private Dictionary<int, ClientsFinanceModel> _clientsFinance;
        [JsonInclude]
        private int _transactionCategoriesLastId;
        [JsonInclude]
        private int _transactionsLastId;
        [JsonInclude]
        private int _clientsFinanceLastId;
        [JsonInclude]
        private string _dataStorageFile = "DataStorage.json";


        public DataStorage()
        {
            _transactionCategories = new Dictionary<int, TransactionCategoryModel>();
            _transactions = new Dictionary<int, TransactionModel>();
            _clientsFinance = new Dictionary<int, ClientsFinanceModel>();
            _transactionCategoriesLastId = 1;
            _transactionsLastId = 1;
            _clientsFinanceLastId = 1;

            string json;
            using (StreamReader reader = new StreamReader(_dataStorageFile))
            {
                json = reader.ReadToEnd();
                reader.Close();
            }
            DataStorage tmp = JsonSerializer.Deserialize<DataStorage>(json);
            _transactionCategories = tmp._transactionCategories;
            _transactions = tmp._transactions;
            _clientsFinance = tmp._clientsFinance;
            _transactionCategoriesLastId = tmp._transactionCategoriesLastId;
            _transactionsLastId = tmp._transactionsLastId;
            _clientsFinanceLastId = tmp._clientsFinanceLastId;
        }

        public void SaveAll()
        {
            string json = JsonSerializer.Serialize(this);
            using (StreamWriter writer = new StreamWriter(_dataStorageFile, false))
            {
                writer.Write(json);
                writer.Close();
            }
        }

        public void LoadAll()
        {
            string json;
            using (StreamReader reader=new StreamReader(_dataStorageFile))
            {
                json = reader.ReadToEnd();
                reader.Close();
            }
            DataStorage tmp=JsonSerializer.Deserialize<DataStorage>(json);
            _transactionCategories = tmp._transactionCategories;
            _transactions = tmp._transactions;
            _clientsFinance = tmp._clientsFinance;
            _transactionCategoriesLastId = tmp._transactionCategoriesLastId;
            _transactionsLastId = tmp._transactionsLastId;
            _clientsFinanceLastId = tmp._clientsFinanceLastId;
        }

        #region Category
        public void AddCategory(TransactionCategoryModel category)
        {
            category.Id = _transactionCategoriesLastId;
            _transactionCategories.Add(_transactionCategoriesLastId, category);
            _transactionCategoriesLastId++;
        }

        public void RemoveCategorybyId(int id)
        {
            _transactionCategories.Remove(id);
        }

        public TransactionCategoryModel GetCategoryModelById(int id)
        {
            return _transactionCategories[id];
        }

        public List<TransactionCategoryModel> GetAllCategoryModels()
        {
            return _transactionCategories.Values.ToList();
        }
        #endregion

        #region Trancactions
        public void AddTransaction(TransactionModel category)
        {
            category.Id = _transactionsLastId;
            _transactions.Add(_transactionsLastId, category);
            _transactionsLastId++;
        }

        public void RemoveTransactionbyId(int id)
        {
            _transactions.Remove(id);
        }

        public TransactionModel GetTransactionModelById(int id)
        {
            return _transactions[id];
        }

        public List<TransactionModel> GetAllTransactionModels()
        {
            return _transactions.Values.ToList();
        }
        #endregion

        #region ClientFinance
        public void AddClientFinance(ClientsFinanceModel category)
        {
            category.Id = _clientsFinanceLastId;
            _clientsFinance.Add(_clientsFinanceLastId, category);
            _clientsFinanceLastId++;
        }

        public void RemoveClientsFinancebyId(int id)
        {
            _clientsFinance.Remove(id);
        }

        public ClientsFinanceModel GetClientsFinanceModelById(int id)
        {
            return _clientsFinance[id];
        }

        public List<ClientsFinanceModel> GetAllClientsFinanceModels()
        {
            return _clientsFinance.Values.ToList();
        }
        #endregion
    }
}
