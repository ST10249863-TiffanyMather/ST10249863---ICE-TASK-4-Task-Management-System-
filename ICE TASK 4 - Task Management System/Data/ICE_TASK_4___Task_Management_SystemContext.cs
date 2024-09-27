using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ICE_TASK_4___Task_Management_System.Models;

namespace ICE_TASK_4___Task_Management_System.Data
{
    public class ICE_TASK_4___Task_Management_SystemContext : DbContext
    {
        public ICE_TASK_4___Task_Management_SystemContext (DbContextOptions<ICE_TASK_4___Task_Management_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<ICE_TASK_4___Task_Management_System.Models.TaskModel> TaskModel { get; set; } = default!;
    }
}
