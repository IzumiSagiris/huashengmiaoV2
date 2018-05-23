using IzumiSagiris.Service.IzumiEntity;
using IzumiSagiris.Service.Student;
using IzumiSagirisCommon.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IzumiSagiri.Controllers
{
    public class StudentController : BaseController
    {
        public readonly IStudentInterFace _service;

        public StudentController()
        {
            _service = IzumiDirectLocator.GetService<IStudentInterFace>();
        }
        public ActionResult Index()
        {
            long StudentID = 3504831318674374656;

            var student = _service.GetStudent(StudentID);

            return View();
        }

        public ActionResult Detail()
        {
            long StudentID = 3504831318674374656;

            var student = _service.GetStudent(StudentID);

            return View(
                );
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(StudentEntity Student)
        {
            long StudentID = 3504831318674374656;

            var student = _service.GetStudent(StudentID);

            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentEntity Student)
        {
            Student.StudentName = "hehe";
            Student.Status = 1;
            var result = _service.UpdateStudent(Student);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateStudent(StudentEntity Student)
        {
            Student.StudentID = 3504831318674374656;
            Student.StudentName = "zhangbaiyang";
            Student.Status = 1;
            var result = _service.UpdateStudent(Student);
            return View();
        }
    }
}