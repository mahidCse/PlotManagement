using Autofac;
using Microsoft.AspNetCore.Hosting;
using RealState.Core.Entity;
using RealState.Core.Services;
using RealState.SD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealState.Models.TransactionModels
{
    public class TransactionUM
    {

        private ITransactionService _transactionService;
        private ICategoryService _categoryService;
        private IAccountService _accountService;
        public TransactionUM()
        {
            _transactionService = Startup.AutofacContainer.Resolve<ITransactionService>();
            _categoryService = Startup.AutofacContainer.Resolve<ICategoryService>();
            _accountService = Startup.AutofacContainer.Resolve<IAccountService>();

        }


        public void AddExpense( TransactionModel transaction)
        {
            _transactionService.AddNewTransaction(new Transaction
            {
                Amount = transaction.Amount,
                ImageUrl = transaction.ImageUrl,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId,
                Date = transaction.Date.Date,
                Time = transaction.Date.TimeOfDay,
                Flag = TransactionType.Expense
            });
        }

        public void AddIncome(TransactionModel transaction)
        {
            _transactionService.AddNewTransaction(new Transaction
            {
                Amount = transaction.Amount,
                ImageUrl = transaction.ImageUrl,
                CategoryId = transaction.CategoryId,
                AccountId = transaction.AccountId,
                Date = transaction.Date.Date,
                Time = transaction.Date.TimeOfDay,
                Flag = TransactionType.Income
            });
        }

        internal void DeleteTransaction(int id)
        {
            var transction = _transactionService.GetTransactionById(id);

            if(transction.ImageUrl != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", transction.ImageUrl);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

            }

            _transactionService.Remove(id);
        }

        public object GetExpenses()
        {


            var allTrasaction = _transactionService.GetAllTransaction().Where(f => f.Flag == -1).ToList();

                var expenseList = new List<TransactionModel>();

                foreach (var expense in allTrasaction)
                {
                    var category = _categoryService.GetCategoryById(expense.CategoryId).Name;
                    var accountName = _accountService.GetAccountById(expense.AccountId).Name;

                expenseList.Add(new TransactionModel
                    {
                        Id = expense.Id,
                        AccountId = expense.AccountId,
                        Description = expense.Description,
                        Amount = expense.Amount,
                        Date = expense.Date,
                        Time = expense.Time,
                        ImageUrl = expense.ImageUrl,
                        AccountName = accountName,
                        CategoryName = category

                    }); ;
                }


                return new
                {
                    data = (from record in expenseList
                            select new string[]
                            {
                                record.Id.ToString(),
                                record.AccountName,
                                record.CategoryName,
                                record.Amount.ToString(),
                                record.Date.ToString("MM/dd/yyyy"),
                                record.Time.ToString(),
                                record.ImageUrl
                            }
                        ).ToArray()

                };
            
        }
    }
}
