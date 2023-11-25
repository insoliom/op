using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

UserInterface ui = UserInterface.GetInstance();

var db = new FanDatabase(new DbContextOptionsBuilder().UseInMemoryDatabase("fanDatabase").Options);

ui.StartProgram(db);