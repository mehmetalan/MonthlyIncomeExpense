using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class IncomeExpenseRepository
    {
        MonthlyIncomeExpenseDbContext _ctx;
        public IncomeExpenseRepository(MonthlyIncomeExpenseDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<IncomeExpense> GetList()
        {
            return _ctx.IncomeExpenses.ToList();
        }

        public IncomeExpense GetIncomeExpenseById(int id)
        {
            return _ctx.IncomeExpenses.FirstOrDefault(x => x.Id == id);
        }

        public IncomeExpense AddOrUpdateIncomeExpense(IncomeExpense ie)
        {
            if(ie.Id > 0)
            {
                _ctx.IncomeExpenses.Attach(ie);
                _ctx.Entry(ie).State = EntityState.Modified;
            }
            else
            {
                _ctx.IncomeExpenses.Add(ie);
            }
            _ctx.SaveChanges();
            return ie;
        }

        public void DeleteIncomeExpense(int id)
        {
            IncomeExpense silinecek = GetIncomeExpenseById(id);
            _ctx.Remove(silinecek);
            _ctx.SaveChanges();
        }
    }
}
