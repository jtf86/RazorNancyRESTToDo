using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace ToDoList
{
  public class Task
  {
    private string description { get; set; }
    private int id { get; set; }

    private static List<Task> instances = new List<Task> {};

    public Task(string Description, int Id = 0)
    {
      id = Id;
      description = Description;
    }

    public int GetId()
    {
      return id;
    }

    public string GetDescription()
    {
      return description;
    }

    public void SetDescription(string newDescription)
    {
      description = newDescription;
    }

    public static List<Task> GetAll()
    {
      List<Task> AllTasks = new List<Task>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tasks", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int taskId = rdr.GetInt32(0);
        string taskDescription = rdr.GetString(1);
        Task newTask = new Task(taskDescription, taskId);
        AllTasks.Add(newTask);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return AllTasks;
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
