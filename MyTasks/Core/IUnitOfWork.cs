using MyTasks.Core.Repositories;
using MyTasks.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Core
{
    public interface IUnitOfWork
    {

        ITaskRepository Task { get; }

        void Complete();
    }
}
