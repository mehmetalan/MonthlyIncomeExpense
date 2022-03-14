using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyIncomeExpense.Models;
using System.Collections.Generic;

namespace MonthlyIncomeExpense.Controllers
{
    public class IncomeExpenseController : Controller
    {
        IncomeExpenseRepository _repository;
        public IncomeExpenseController(IncomeExpenseRepository repository)
        {
            _repository = repository;
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
            if(!id.HasValue || id.Value <= 0)
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
