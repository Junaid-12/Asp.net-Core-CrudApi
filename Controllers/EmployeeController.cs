using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeWebApi.Reposistry;
using EmployeWebApi.Data;

namespace EmployeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpolyee _contexl;
        public EmployeeController(IEmpolyee contexl)
        {
             _contexl=  contexl;
         }
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _contexl.GetEmployees());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Data Not Load");
            }
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var Result = await _contexl.GetEmployeebyid(id);
                if (Result == null)
                {

                    BadRequest(" $ Id Not found");
                }
                return Result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError ,ex);
            }
        }
       [HttpPost]
       [Route("CreateEmployee")]
       public async Task<ActionResult<Employee>> CreateEmployee(Employee employeeMo)
        {
            try
            {
                if (employeeMo == null)
                {
                    return BadRequest("please Check your Profile");
                }
                var CreatedEmploye = await _contexl.CreateEmployee(employeeMo);
                return CreatedAtAction(nameof(GetEmployee), new { id = CreatedEmploye.iD }, CreatedEmploye);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult<Employee>> Update(int id ,Employee employee)
        {
            try
            {
                if (id != employee.iD)
                {
                    return BadRequest("Id $ miss Match");
                }

                var Updtaeid = await _contexl.GetEmployeebyid(id);
                if (Updtaeid == null)
                {
                    return BadRequest(" Employee ${id} Id is Null ");
                }
                return await _contexl.UpdateEmployee(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest("id not Found");
                }
                return await _contexl.DeleteEmployee(id);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        

    }
}
