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
            // Ensure the database is created.
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Students.Any())
            {
                return;   // DB has been seeded.
            }

            var students = new Student[]
            {
                new Student{Name="John Glen", BirthDate=new DateTime(2012,5,12)},
                new Student{Name="Bob Lazar", BirthDate=new DateTime(2012,12,5)},
                new Student{Name="Alexanser Arnald", BirthDate=new DateTime(2011,9,17)}
            };

            foreach (var p in students)
            {
                context.Students.Add(p);
            }

            context.SaveChanges();
        }
    }
}
