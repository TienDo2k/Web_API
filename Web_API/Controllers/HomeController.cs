using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase

    {
        public static List<SinhVien> Students = new List<SinhVien>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Students);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var sinhVien = Students.SingleOrDefault(sv => sv.ID == id);
                if (sinhVien == null)
                {
                    return NotFound();
                }
                return Ok(sinhVien);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(SinhVien s)
        {
            var SinhVien = new SinhVien
            {
                ID = s.ID,
                Name = s.Name,
                Mark = s.Mark,
                Age = s.Age,
            };
            Students.Add(SinhVien);
            return Ok(new
            {
                Success = true,
                Data = SinhVien
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, SinhVien svEdit)
        {
            try
            {
                var sinhVien = Students.SingleOrDefault(sv => sv.ID == id);
                if (sinhVien == null)
                {
                    return NotFound();
                }
                //update
                if (id != sinhVien.ID.ToString())
                {
                    return BadRequest();
                }
                sinhVien.ID = svEdit.ID;
                sinhVien.Name = svEdit.Name;
                sinhVien.Mark = svEdit.Mark;
                sinhVien.Age = svEdit.Age;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var sinhVien = Students.SingleOrDefault(sv => sv.ID == id);
                if (sinhVien == null)
                {
                    return NotFound();
                }
                Students.Remove(sinhVien);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}
