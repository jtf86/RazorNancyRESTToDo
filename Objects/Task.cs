using System;
using System.Collections.Generic;

namespace ToDoList
{

  public class Task
  {
    private string description { get; set; }
    private int id { get; set; }

    private static List<Task> instances = new List<Task> {};

    public Task(string new_description)
    {
      description = new_description;
      instances.Add(this);
      id = instances.Count;
    }

    public string GetDescription()
    {
      return description;
    }

    public int GetId()
    {
      return id;
    }

    public static List<Task> All()
    {
      return instances;
    }

    public static Task Find(int id)
    {
      return instances[id-1];
    }

    public static void DeleteAll()
    {
      instances.Clear();
    }
  }
}
