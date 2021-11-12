using KExpense.Repository;
using KExpense.Model;
using System;
using System.Collections.Generic;

namespace KExpense.Service
{
    public class  KExpenseService
    {
        IKExpenseRepository kexpenseRepository;

        public KExpenseService(IKExpenseRepository kexpenseRepository)
        {
            this.kexpenseRepository = kexpenseRepository;
        }


        public List<ExpenseModel> GetAll()
        {
            List < ExpenseModel > result =  this.kexpenseRepository.GetAllKExpenses();
            return result;
        }

        public ExpenseModel RecordExpense(ExpenseModel newExpense)
        {
            ExpenseModel savedRecord = this.kexpenseRepository.RecordExpense(newExpense);
            return savedRecord;
        }
    }
}
