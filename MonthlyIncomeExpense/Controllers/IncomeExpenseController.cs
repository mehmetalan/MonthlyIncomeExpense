using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonthlyIncomeExpense.Models;
using System.Collections.Generic;

namespace MonthlyIncomeExpense.Controllers
{
    public class IncomeExpenseController : Controller
    {
        IncomeExpenseRepository _repository;
        MonthlyIncomeExpenseDbContext _ctx;
        public IncomeExpenseController(IncomeExpenseRepository repository, MonthlyIncomeExpenseDbContext ctx)
        {
            _repository = repository;
            _ctx = ctx;
        }
        // GET: IncomeExpenseController
        public ActionResult Index()
        {
            List<IncomeExpense> list = _repository.GetList();
            return View(list);
        }

        // GET: IncomeExpenseController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetIncomeExpenseById(id));
        }

        // GET: IncomeExpenseController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult GetIncomes()
        {
            return View(_repository.GetIncomes());
        }

        // POST: IncomeExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeExpense ie)
        {
            _repository.AddOrUpdateIncomeExpense(ie);
            return RedirectToAction("Index");
        }

        // GET: IncomeExpenseController/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData["InExTypeID"] = new SelectList(_ctx.InExTypes, "InExTypeID", "InExName");
            if (!id.HasValue || id.Value <= 0)
            {
                return View(new IncomeExpense());
            }
            IncomeExpense incomeExpense = _repository.GetIncomeExpenseById(id.Value);
            return View(incomeExpense);
            
        }

        // POST: IncomeExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeExpense ie)
        {
            ViewData["InExTypeID"] = new SelectList(_ctx.InExTypes, "InExTypeID", "InExName");
            _repository.AddOrUpdateIncomeExpense(ie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repository.DeleteIncomeExpense(id);
            return RedirectToAction("Index");
        }
    }
}
