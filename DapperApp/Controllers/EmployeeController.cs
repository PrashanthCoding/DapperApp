using DapperApp.Models;
using DapperApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // Employee Controller
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _employeeRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("Details")]
        public ActionResult Get(int id)
        {
            var result = _employeeRepository.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Employee employee)
        {
            _employeeRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return NoContent();
        }
    }
}
