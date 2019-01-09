using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassmaMnagement.Models;
using System.Data.Entity;

namespace ClassmaMnagement.DataAccessClass
{
    public class ClassContext: DbContext
    {
        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
