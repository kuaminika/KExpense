using System;

namespace KExpense.Model
{

    public class ExpenseModel
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string BriefDescription { get; set; }
        public string Reason { get; set; }

        public decimal Cost { get; set; }
    }
}
