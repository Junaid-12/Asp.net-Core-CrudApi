using EmployeWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeWebApi.Reposistry
{
    public class EmployeeResposistry : IEmpolyee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeResposistry(ApplicationDbContext context)
        {
            _context = context;
    }

        public async Task<Employee> CreateEmployee(Employee employeeMo)
        {
            var result  = await _context.employeeMos.AddAsync(employeeMo);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var Result = await _context.employeeMos.Where(x => x.iD == id).FirstOrDefaultAsync();
            if (Result != null)
            {
               _context.employeeMos.Remove(Result);
                _context.SaveChangesAsync();
                return Result;
            }
         
            return null;
        }
            

        public async Task<Employee> GetEmployeebyid(int id)
        {
            return await _context.employeeMos.Where(x => x.iD == id).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.employeeMos.ToListAsync(); 
        }

        public async  Task<Employee> UpdateEmployee(Employee employeeMo)
        {
            var result = await _context.employeeMos.Where(x => x.iD == employeeMo.iD).FirstOrDefaultAsync();
            if (result != null)
            {
                result.iD = employeeMo.iD;
                result.Name = employeeMo.Name;
                result.City = employeeMo.City;
                _context.Update(result);
                _context.SaveChangesAsync();

                return result;
                    
            }
            return null;

        }
    }
}
