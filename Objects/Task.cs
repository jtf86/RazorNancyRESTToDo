namespace todo.Objects
{
  using System;
  using System.Collections.Generic;

  public class Task
  {
    private string description { get; set; }

    public Task(string new_description)
    {
      description = new_description;
    }

    public string GetDescription()
    {
      return description;
    }

    public static List<string> ListOfTasks = new List<string> {};

    public void Save()
    {
      ListOfTasks.Add(this.GetDescription());
    }

    public static void ClearAll()
    {
      ListOfTasks.Clear();
    }
  }
}
