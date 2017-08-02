using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Infrastructure;
using Core.Models;
using Data;

namespace App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employee
        public ViewResult Index()
        {
            return View(_unitOfWork.Employees.GetAll());
        }

        // GET: Employee/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var employee = _unitOfWork.Employees.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return null;
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Email,Password,Id")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Add(employee);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            var employee = _unitOfWork.Employees.GetAll().SingleOrDefault(m => m.Id == id);

            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Email,Password,Id")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Employees.Update(employee);
                    _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _unitOfWork.Employees.GetAll()
                .SingleOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _unitOfWork.Employees.GetAll().SingleOrDefault(m => m.Id == id);
            _unitOfWork.Employees.Remove(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _unitOfWork.Employees.GetAll().Any(e => e.Id == id);
        }
    }
}