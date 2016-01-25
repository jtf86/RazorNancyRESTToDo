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
        List<Category> AllCategories = Category.GetAll();
        return View["categories.cshtml", AllCategories];
      };
      Get["/tasks"] = _ => {
        Dictionary<string, object> Model = new Dictionary<string, object> {};
        List<Task> AllTasks = Task.GetAll();
        List<Category> AllCategories = Category.GetAll();
        Model.Add("tasks", AllTasks);
        Model.Add("categories", AllCategories);
        return View["tasks.cshtml", Model];
      };
    }
  }
}
