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

            if (context.Projects.Any())
                return;

            var projects = new Project[]
            {
                new Project { 
                    Name="Tiny Holiday Home", 
                    Description="Modern tiny house", 
                    Images=new List<string>{"/images/tiny.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Four Leaves Villa", 
                    Description="Organic shaped villa", 
                    Images=new List<string>{"/images/four.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Casa N", 
                    Description="Estudio GMARQ project", 
                    Images=new List<string>{"/images/casan.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Valley Villa", 
                    Description="Eco-friendly villa", 
                    Images=new List<string>{"/images/valley.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Piano House", 
                    Description="LINE Architects", 
                    Images=new List<string>{"/images/piano.jpg", "/images/piano2.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="The Quest", 
                    Description="Strom Architects", 
                    Images=new List<string>{"/images/quest.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Back Country House", 
                    Description="LTD Architectural", 
                    Images=new List<string>{"/images/back.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="DIYA", 
                    Description="SPASM Design Architects", 
                    Images=new List<string>{"/images/diya.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Napoli Station", 
                    Description="Zaha Hadid Architects", 
                    Images=new List<string>{"/images/napoli.jpg"},
                    DateCreated = DateTime.UtcNow
                },
                new Project { 
                    Name="Under", 
                    Description="Snøhetta underwater restaurant", 
                    Images=new List<string>{"/images/under.jpg"},
                    DateCreated = DateTime.UtcNow
                }
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
