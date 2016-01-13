namespace todo.Objects
{
  using System;
  public class Task
  {
    private string description;

    public string GetDescription()
    {
        return description;
     }

    public static List<string> ListOfTasks = new List<string> {};

    public void Save()
    {
      ListOfTasks.Add(this.GetDescription());
    }
  }
}
