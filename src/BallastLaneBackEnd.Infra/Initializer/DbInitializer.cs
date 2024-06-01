using BallastLaneBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLaneBackEnd.Infra.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

        
            InitializerStudent(context);


            InitializerTeacher(context);

            InitializerSubject(context);

       //     InitializerClass(context);

            context.SaveChanges();
        }

        private static void InitializerStudent(SchoolContext context)
        {
            if (context.Students.Any())
            {
                return;   
            }

            var students = new Student[]
            {
                new Student{Name="John Glen", BirthDate=new DateTime(2012,5,12), CreateDate = DateTime.Now},
                new Student{Name="Bob Lazar", BirthDate=new DateTime(2012,12,5), CreateDate = DateTime.Now},
                new Student{Name="Alexanser Arnald", BirthDate=new DateTime(2011,9,17), CreateDate = DateTime.Now}
            };

            foreach (var p in students)
            {
                context.Students.Add(p);
            }
        }

        private static void InitializerTeacher(SchoolContext context)
        {
            if (context.Teachers.Any())
            {
                return;   
            }

            var teachers = new Teacher[]
            {
              new Teacher { Name = "John Glen", CreateDate = DateTime.Now },
new Teacher { Name = "Jane Smith", CreateDate = DateTime.Now },
new Teacher { Name = "Michael Brown" , CreateDate = DateTime.Now},
new Teacher { Name = "Emily Davis" , CreateDate = DateTime.Now },
new Teacher { Name = "David Wilson" , CreateDate = DateTime.Now},
new Teacher { Name = "Susan Clark" , CreateDate = DateTime.Now},
new Teacher { Name = "Robert Johnson" , CreateDate = DateTime.Now},
new Teacher { Name = "Linda Martinez", CreateDate = DateTime.Now }
            };

            foreach (var p in teachers)
            {
                context.Teachers.Add(p);
            }
        }


        private static void InitializerSubject(SchoolContext context)
        {
            if (context.Subjects.Any())
            {
                return;
            }

            var teachers = new Subject[]
            {
              new Subject { Name = "Mathematics", CreateDate = DateTime.Now },
            new Subject { Name = "English Language Arts" , CreateDate = DateTime.Now},
            new Subject { Name = "Science", CreateDate = DateTime.Now },
            new Subject { Name = "Social Studies", CreateDate = DateTime.Now },
            new Subject { Name = "Physical Education" , CreateDate = DateTime.Now},
            new Subject { Name = "Art", CreateDate = DateTime.Now },
            new Subject { Name = "Music" , CreateDate = DateTime.Now},
            new Subject { Name = "Foreign Language", CreateDate = DateTime.Now }
            };

            foreach (var p in teachers)
            {
                context.Subjects.Add(p);
            }
        }


        private static void InitializerClass(SchoolContext context)
        {
            if (context.Classes.Any())
            {
                return;
            }

            var classe = new Class[]
            {
              new Class { Number = "201", SubjectId = 1, TeacherId = 1, CreateDate = DateTime.Now},
            new Class { Number = "202", SubjectId = 1, TeacherId = 1, CreateDate = DateTime.Now }
            };

            foreach (var p in classe)
            {
                context.Classes.Add(p);
            }
        }
    }
}
