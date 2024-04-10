using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string taskName = "my first task";
        DateTime taskTime = DateTime.Today;
        string expectedResult = $"To-Do List:{Environment.NewLine}[ ] {taskName} - Due: {taskTime.ToString("MM/dd/yyyy")}";


        // Act
        this._toDoList.AddTask(taskName,taskTime);
        var result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string taskName = "my first complete task";
        DateTime taskTime = DateTime.Today;
        string expectedResult = $"To-Do List:{Environment.NewLine}[✓] {taskName} - Due: {taskTime.ToString("MM/dd/yyyy")}";


        // Act
        this._toDoList.AddTask(taskName, taskTime);
        this._toDoList.CompleteTask(taskName);
        var result = this._toDoList.DisplayTasks();

        //Assert 
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string taskName = "task to complete";
        

        // Act $ Assert
        Assert.That(() => this._toDoList.CompleteTask(taskName), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        ;
        string expectedResult = "To-Do List:";


        // Act
        
        string result = this._toDoList.DisplayTasks();

        //Assert 
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string taskName1 = "my first task";
        string taskName2 = "my second task";
        string taskName3 = "my third task";

        DateTime taskTime = DateTime.Today;
           


        // Act
        this._toDoList.AddTask(taskName1,taskTime);
        this._toDoList.AddTask(taskName2,taskTime);
        this._toDoList.AddTask(taskName3,taskTime);

        var result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Does.Contain("[ ] my first task - Due:"));
        Assert.That(result, Does.Contain("[ ] my second task - Due:"));
        Assert.That(result, Does.Contain("[ ] my third task - Due:"));
    }
}
