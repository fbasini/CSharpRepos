using MathGame;

var Menu = new Menu();

var date = DateTime.Now;

var games = new List<string>();

string name = Helpers.GetName();

Menu.ShowMenu(name, date);


