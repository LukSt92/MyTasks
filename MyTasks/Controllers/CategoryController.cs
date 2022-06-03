using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Service;
using MyTasks.Core.ViewModels;
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

        public IActionResult Category(int id = 0)
        {
            var userId = User.GetUserId();

            var category = id == 0 ?
                new Category { Id = 0, UserId = userId } :
                _taskService.GetCategory(id, userId);

            var vm = new CategoryViewModel
            {
                Category = category
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category( Category category)
        {
            var userId = User.GetUserId();
            category.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new Category();

                return View("Category", vm);
            }

            if (category.Id == 0)
                _taskService.AddCategory(category);

            else
                _taskService.UpdateCategory(category);

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _taskService.DeleteCategory(id, userId);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}
