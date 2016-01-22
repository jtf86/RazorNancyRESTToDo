using Xunit;
using System;
using System.Collections.Generic;


namespace ToDoList
{
  public class TaskTest
  {
    //  : IDisposable
    // public void Dispose()
    // {
    //   Task.DeleteAll();
    // }

    [Fact]
    public void GetDescription_WalkTheDog_pass()
    {
      //Arrange
      var description01 = "Walk the dog";
      Task newTask = new Task(description01);

      //Act
      var result = newTask.GetDescription();

      //Assert
      Assert.Equal(description01, result);
    }

    [Fact]
    public void GetAll_pass()
    {
      //Arrange
      var description01 = "Walk the dog";
      var description02 = "Wash the dishes";
      Task newTask1 = new Task(description01);
      Task newTask2 = new Task(description02);
      List<Task> newList = new List<Task> { newTask1, newTask2 };

      //Act
      var result = Task.GetAll();

      //Assert
      Assert.Equal(newList, result);
    }


  }
}
