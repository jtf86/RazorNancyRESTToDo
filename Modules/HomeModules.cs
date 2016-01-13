using Nancy.ViewEngines.Razor;
using Nancy;
using todo.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["add_new_task.cshtml"];
      Get["/view_all_tasks"] = _ => {
        var allTasks = Task.ListOfTasks;
        return View["view_all_tasks.cshtml", allTasks];
      };
      Post["/task_added"] = _ => {
        Task NewTask = new Task{
          Description = Request.Form["new-task"]
        };
        NewTask.Save();
        return View["task_added.cshtml", NewTask];
      };
    }
  }
}
