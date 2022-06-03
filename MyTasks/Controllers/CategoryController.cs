using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Service;
using MyTasks.Persistence.Extensions;
using MyTasks.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasks.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ITaskService _taskService;

        public CategoryController(ITaskService taskService)
        {
            _taskService = taskService; 
        }

        public IActionResult Categories( Category category)
        {
            var userId = User.GetUserId();

            var categories = _taskService.GetCategories(userId);
            
            return View(categories);
        }
    }
}
