using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _db.Students.
                Include(x => x.objStdHob).ThenInclude(x => x.hobby);
            return View(objStudentList);
        }
        //GET
        public IActionResult NewStudentRegistration()
        {
            var student = new Student();
            var hobby = _db.Hobbies.Select(u => new SelectListItem
            {
                Text = u.HobbyName,
                Value = u.HobbyId.ToString()
            }).ToList();
            //hobby.Insert(0, new SelectListItem { Text = "--------------Select--------------", Value = "0", Selected = true });
            student.hobbiesList = hobby;
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewStudentRegistration(Student obj)
        {
            //custom validations
            if (obj.FName.Length > 32)
            {
                ModelState.AddModelError("LengthExceeded", "Max 32 characters");
            }
            if (obj.LName.Length > 32)
            {
                ModelState.AddModelError("LengthExceeded", "Max 32 characters");
            }
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var i in specialChar)
            {
                if (obj.FName.Contains(i))
                {
                    ModelState.AddModelError("ValueError", "No special characters allowed");
                }
                if (obj.LName.Contains(i))
                {
                    ModelState.AddModelError("ValueError", "No special characters allowed");
                }

            }
            if (obj.DOB > DateTime.Now.AddYears(-18))
            {
                ModelState.AddModelError("AgeError", "Age less than 18");
            }
            /*
            */
            if (ModelState.IsValid)
            {
                foreach (var item in obj.Hobbies)
                {
                    int id = 0;
                    int.TryParse(item, out id);
                    obj.objStdHob.Add(new StudentHobby
                    {
                        HobbyId = id
                    });
                }
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Record Created Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            
            var studentData = _db.Students.
                Include(x => x.objStdHob).Where(x => x.StudentId == id).FirstOrDefault();
            var selectedHobbies = studentData.objStdHob.Select(x => x.HobbyId).ToList();
            var hobby = _db.Hobbies.Select(x => new SelectListItem()
            {
                Text = x.HobbyName,
                Value = x.HobbyId.ToString(),
                Selected = selectedHobbies.Contains(x.HobbyId)

            }).ToList();
            studentData.hobbiesList = hobby;
            //studentData.StudentId = id;
                
                        
            if(studentData == null)
            {
                return NotFound();
            }
            return View(studentData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            //custom validations
            if (obj.FName.Length > 32)
            {
                ModelState.AddModelError("LengthExceeded", "Max 32 characters");
            }
            if (obj.LName.Length > 32)
            {
                ModelState.AddModelError("LengthExceeded", "Max 32 characters");
            }
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var i in specialChar)
            {
                if (obj.FName.Contains(i))
                {
                    ModelState.AddModelError("ValueError", "No special characters allowed");
                }
                if (obj.LName.Contains(i))
                {
                    ModelState.AddModelError("ValueError", "No special characters allowed");
                }

            }
            if (obj.DOB > DateTime.Now.AddYears(-18))
            {
                ModelState.AddModelError("AgeError", "Age less than 18");
            }


            if (ModelState.IsValid)
            {

                var existingStdHob = _db.Students.Include(x => x.objStdHob).
                    FirstOrDefault(x=>x.StudentId==obj.StudentId);
                foreach (var item in existingStdHob.objStdHob.ToList())
                {
                    _db.Remove(item);
                }
                _db.SaveChanges();
                _db.ChangeTracker.Clear();
                foreach (var item in obj.Hobbies)
                {
                     
                    int id = 0;
                    int.TryParse(item, out id);
                    obj.objStdHob.Add(new StudentHobby
                    {
                        HobbyId = id
                    });
                }
                _db.Students.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Record Updated Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentData = _db.Students.Find(id);
            if (studentData == null)
            {
                return NotFound();
            }
            
           return PartialView("_DeleteAlertPartialView", studentData);


        }

        [HttpPost]
        public IActionResult Delete(Student studentData)
        {

            if (studentData == null)
            {
                return NotFound();
            }
            //TempData["confirmation"] = "Are you sure?";

            _db.Students.Remove(studentData);
            _db.SaveChanges();
            TempData["success"] = "Student Record Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
