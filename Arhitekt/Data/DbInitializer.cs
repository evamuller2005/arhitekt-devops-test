using Arhitekt.Data;
using Arhitekt.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Arhitekt.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ArhitektContext context)
        {
            context.Database.EnsureCreated();

            // Če že obstajajo projekti → ne delaj nič
            if (context.Projects.Any())
                return;

            var projects = new Project[]
            {
                new Project
                {
                    Name = "Piano House",
                    Description = "Modern wooden house",
                    DateCreated = DateTime.Now,
                    Images = new List<string>
                    {
                        "/images/piano.jpg",
                        "/images/piano2.jpg"
                    }
                },
                new Project
                {
                    Name = "Courtyard House",
                    Description = "Stylish minimal courtyard",
                    DateCreated = DateTime.Now,
                    Images = new List<string>
                    {
                        "/images/courtyard.jpg",
                        "/images/collage.jpg"
                    }
                },
                new Project
                {
                    Name = "Forest Villa",
                    Description = "Nature-focused architecture",
                    DateCreated = DateTime.Now,
                    Images = new List<string>
                    {
                        "/images/bigwood.jpg",
                        "/images/wild.jpg"
                    }
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
