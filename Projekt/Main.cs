using System;
using Gtk;
public class main
{
	//Application start - only MoviesDB intrface
	public static void Main()
	{
		Gtk.Application.Init();
		MainWindow window = new MainWindow();
		Gtk.Application.Run();
	}
}
