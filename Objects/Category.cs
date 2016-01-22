using System;
using System.Collections.Generic;

namespace ToDoList
{
  public class Category
  {
    private static List<Category> instances = new List<Category> {};
    private string name;
    private int id;
    private List<Task> tasks;

    public Category(string categoryName)
    {
      name = categoryName;
      instances.Add(this);
      id= instances.Count;
      tasks = new List<Task>{};
    }

    public string GetName()
    {
      return name;
    }

    public int GetId()
    {
      return id;
    }

    public List<Task> GetTasks()
    {
      return tasks;
    }

    public void AddTask(Task task)
    {
      tasks.Add(task);
    }

    public static List<Category> GetAll()
    {
      return instances;
    }

    public static void Clear()
    {
      instances.Clear();
    }

    public static Category Find(int id)
    {
      return instances[id-1];
    }
  }
}
