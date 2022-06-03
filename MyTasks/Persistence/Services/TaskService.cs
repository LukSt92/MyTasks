using MyTasks.Core;
using MyTasks.Core.Models.Domains;
using MyTasks.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.Persistence.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Task> Get(string userId,
            bool isExecuted = false, int categoryId = 0, string title = null)
        {
            return _unitOfWork.Task.Get(userId, isExecuted, categoryId, title);
        }

        public IEnumerable<Category> GetCategories(string userId)
        {
            return _unitOfWork.Task.GetCategories(userId);
        }

        public Task Get(int id, string userId)
        {
            return _unitOfWork.Task.Get(id, userId);
        }

        public Category GetCategory(int id, string userId)
        {
            return _unitOfWork.Category.GetCategory(id, userId);
        }

        public void Add(Task task)
        {
            _unitOfWork.Task.Add(task);
            _unitOfWork.Complete();
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.Category.AddCategory(category);
            _unitOfWork.Complete();
        }

        public void Update(Task task)
        {
            _unitOfWork.Task.Update(task);
            _unitOfWork.Complete();
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.Category.UpdateCategory(category);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Task.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int id, string userId)
        {
            _unitOfWork.Category.DeleteCategory(id, userId);
            _unitOfWork.Complete();
        }

        public void Finish(int id, string userId)
        {
            _unitOfWork.Task.Finish(id, userId);
            _unitOfWork.Complete();
        }
    }
}
