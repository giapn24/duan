using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vesion15.Models;

    public class SQLDBContext : DbContext
    {
        public SQLDBContext (DbContextOptions<SQLDBContext> options)
            : base(options)
        {
        }

        public DbSet<vesion15.Models.HoSo> HoSo { get; set; } = default!;
    }
