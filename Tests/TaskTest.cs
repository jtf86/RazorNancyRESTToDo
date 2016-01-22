using Xunit;
using System;

namespace ToDoList
{
  public class TaskTest
  {
    [Fact]
    public void GetDescription_WalkTheDog()
    {
      //Arrange
      var description01 = "Walk the dog.";
      Task newTask = new Task(description01);

      //Act
      var result = newTask.GetDescription();

      //Assert
      Assert.Equal(description01, result);
    }
  }
}
