using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppEmp.Models;
using WebAppEmp;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Cors;

namespace WebAppEmp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext context;

        public WeatherForecastController(AppDbContext _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("[action]")]
        [Route("/addcountry")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Country>> AddCountry(Country cnt)
        {
            try
            {
                context.Country.Add(cnt);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetCountry", cnt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/listcountry")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            try
            {
                return await context.Country.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("/addstate")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<State>> AddState(State state)
        {
            try
            {
                context.State.Add(state);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetState", state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/liststate")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<State>>> GetState(Int32 countryid)
        {
            try
            {
                return await context.State.Where(x => x.countryid == countryid).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("/addcity")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<City>> AddCity(City city)
        {
            try
            {
                context.City.Add(city);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetCity", city);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/listcity")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<City>>> GetCity(Int32 stateid)
        {
            try
            {
                return await context.City.Where(x => x.stateid == stateid).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("/adddepartment")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            try
            {
                context.Department.Add(department);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetDepartment", department);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/listdepartment")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            try
            {
                return await context.Department.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("action")]
        [Route("/addemployee")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                context.Employee.Add(employee);
                await context.SaveChangesAsync();
                return CreatedAtAction("GetEmployee", employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/listemployee")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<EmployeeVieewModel>>> GetEmployee()
        {
            try
            {
               var record = (from emp in context.Employee.ToList()

                              join city in context.City.ToList()
                              on emp.cityid equals city.cityid

                              join state in context.State.ToList()
                              on emp.stateid equals state.stateid

                              join country in context.Country.ToList()
                              on emp.countryid equals country.countryid

                              join dept in context.Department.ToList()
                              on emp.departmentid equals dept.departmentid

                              select new
                              {
                                  Employeeid = emp.employeeid,
                                  Firstname = emp.firstname,
                                  Lastname = emp.lastname,
                                  Gender = emp.gender,
                                  Dob = emp.dob,
                                  Statename = state.statename,
                                  Email = emp.email,
                                  Phone = emp.phone,
                                  Pincode = emp.pincode,
                                  Hobbies = emp.hobbies,
                                  Cityname = city.cityname,
                                  Countryid = country.countryid,
                                  Stateid = state.stateid,
                                  Cityid = city.cityid,
                                  Departmentid = dept.departmentid,
                                  Cname = country.cname,
                                  DepartmentName = dept.departmentname
                                }).ToList();
                List<EmployeeVieewModel> employeeVieewModels = new List<EmployeeVieewModel>();
                foreach(var item in record)
                {
                    var data = new EmployeeVieewModel();
                    data.cityid = item.Cityid;
                    data.cityname = item.Cityname;
                    data.cname = item.Cname;
                    data.countryid = item.Countryid;
                    data.departmentid = item.Departmentid;
                    data.departmentname = item.DepartmentName;
                    data.dob = item.Dob;
                    data.email = item.Email;
                    data.employeeid = item.Employeeid;
                    data.firstname = item.Firstname;
                    data.gender = item.Gender;
                    data.hobbies = item.Hobbies;
                    data.lastname = item.Lastname;
                    data.phone = item.Phone;
                    data.pincode = item.Pincode;
                    data.stateid = item.Stateid;
                    data.statename = item.Statename;
                    employeeVieewModels.Add(data);
                }
                return employeeVieewModels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        [Route("/updateemployee")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                context.Employee.Update(employee);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("/deleteemployee")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Int32 employeeid)
        {
            try
            {
                var check = context.Employee.Where(x => x.employeeid == employeeid).FirstOrDefault();
                if (check != null)
                {
                    context.Employee.Remove(check);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/searchemployee")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(string searchtext)
        {
            try
            {
               return await context.Employee.Where(x => x.email == searchtext || x.firstname == searchtext || x.lastname == searchtext).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("/searchemployeeshort")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployeeSort(string searchtext)
        {
            try
            {
                return await context.Employee.OrderByDescending(x => x.firstname).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
