using Nancy;
using Nancy.ViewEngines.Razor;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/categories"] = _ => {
        var AllCategories = Category.All();
        return View["categories.cshtml", AllCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
        var NewCategory = new Category(Request.Form["category-name"]);
        var AllCategories = Category.All();
        return View["categories.cshtml", AllCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedCategory = Category.Find(parameters.id);
        var CategoryTasks = SelectedCategory.GetTasks();
        model.Add("category", SelectedCategory);
        model.Add("tasks", CategoryTasks);
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category SelectedCategory = Category.Find(parameters.id);
        List<Task> AllTasks = SelectedCategory.GetTasks();
        model.Add("category", SelectedCategory);
        model.Add("tasks", AllTasks);
        return View["category_tasks_form.cshtml", model];
      };
      Post["/tasks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category SelectedCategory = Category.Find(Request.Form["category-id"]);
        List<Task> CategoryTasks = SelectedCategory.GetTasks();
        string TaskDescription = Request.Form["task-description"];
        Task NewTask = new Task(TaskDescription);
        CategoryTasks.Add(NewTask);
        model.Add("tasks", CategoryTasks);
        model.Add("category", SelectedCategory);
        return View["category.cshtml", model];
      };
    }
  }
}
