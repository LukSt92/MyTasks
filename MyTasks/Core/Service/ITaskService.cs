using MyTasks.Core.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks.Core.Service
{
    public interface ITaskService
    {
        IEnumerable<Task> Get(string userId,
            bool isExecuted = false, int categoryId = 0, string title = null);
        IEnumerable<Category> GetCategories(string UserId);
        Task Get(int id, string userId);

        Category GetCategory(int id, string userId);
        void Add(Task task);
        void AddCategory(Category category);
        void Update(Task task);
        void UpdateCategory(Category category);
        void Delete(int id, string userId);
        void DeleteCategory(int id, string userId);
        void Finish(int id, string userId);

    }
}
