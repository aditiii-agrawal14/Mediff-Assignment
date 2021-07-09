using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVCApplication.Models;

namespace SampleMVCApplication.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> studentList = new List<Student>{
                            new Student() { RollNo = 1, Name = "Aditi", Age=23, Gender="Female" } ,
                            new Student() { RollNo = 2, Name = "Arpita", Age=22, Gender="Female" } ,
                            new Student() { RollNo = 3, Name = "Kshitij", Age=23, Gender="Male" } ,
                            new Student() { RollNo = 4, Name = "Yamini", Age=20, Gender="Female" } ,

            };
        static Student x;
        [HttpGet]
        public ActionResult Index()
        {
            return View(studentList.OrderBy(s => s.RollNo));
        }
        public ActionResult Edit(int Id)
        {
            
            var student = studentList.Where(s => s.RollNo == Id).FirstOrDefault();

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student stud)
        {
            var student = studentList.Where(s => s.RollNo == stud.RollNo).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(stud);
            foreach(Student studo in studentList)
            {
                Console.WriteLine(studo);
            }
           
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Student stud)
        {

            studentList.Add(stud);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int Id)
        {
            var student = studentList.Where(s => s.RollNo == Id).FirstOrDefault();

            return View(student); 
        }
       
        public ActionResult Delete(int Id)
        {
            Student student = studentList.Where(s => s.RollNo == Id).FirstOrDefault();

            x = student;
              return View(student);



        }
        [HttpPost]
        public ActionResult Delete()
        {
            studentList.Remove(x);
            return RedirectToAction("Index");

        }
    }
}