using KExpense.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KExpense.Repository
{
    public interface IKExpenseRepository
    {
        List<ExpenseModel> GetAllKExpenses();
        ExpenseModel RecordExpense(ExpenseModel newExpense);
    }
}
