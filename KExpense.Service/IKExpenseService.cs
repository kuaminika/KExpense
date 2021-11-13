using KExpense.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace KExpense.Service
{
    public interface IKExpenseService
    {
        List<IKExpense> GetAll();
    }
}
