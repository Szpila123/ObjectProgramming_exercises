using System;
using Gtk;
using Database;
using Entry;
public class MainWindow
{
	private DBConnection connect;
	private Movie[] Movies_DB;
	private MovieDBView MovView;

	public MainWindow()
	{
		//Window
		Gtk.Window window = new Gtk.Window("My Movies Library");
		window.SetSizeRequest(1000,700);
		window.DeleteEvent += delegate{ Application.Quit(); };

		//VBox
		VBox vbox = new VBox(false, 0);
		window.Add(vbox);

		//Toolbar
		Toolbar toolbar = new Toolbar();
		vbox.PackStart(toolbar, false, false, 0);
			//New entry button
		ToolButton NewButton = new ToolButton( Stock.Add );
		toolbar.Insert( NewButton, -1 );
		NewButton.Clicked += new EventHandler( NewClicked );
			//Edit button
		ToolButton EditButton = new ToolButton( Stock.Edit );
		toolbar.Insert( EditButton, -1 );

		//Setting connection to database
		connect = new DBConnection();
		MovView = new MovieDBView( vbox );
		ReviewList( MovView );

		window.ShowAll ();
	}

	//Metody zostaną uogólnione dla wszystkich obiektów
	private void NewClicked( object obj, EventArgs args ){
		Gtk.Window NewWindow = new Gtk.Window("New Movie Entry");
		NewWindow.SetSizeRequest( 300, 500 );
		NewWindow.DeleteEvent += delegate{};

		//VBox
		VBox vbox = new VBox(false, 0);
		NewWindow.Add(vbox);

		//Table
		Table buttons_table = new Table( 7, 2, true );
		vbox.PackStart( buttons_table, true, true, 0 );

		string[] Labels = {"Title", "Type", "RealeseDate", "Director", "Producent", "Duration"};
		Gtk.Entry[] Entries = new Gtk.Entry[6];


		for( uint i = 0 ; i < 6 ; i++ ){
			buttons_table.Attach( new Gtk.Label( Labels[i] ), 0, 1, i, i + 1 );
			buttons_table.Attach( ( Entries[i] = new Gtk.Entry("") ), 1, 2, i, i + 1 );
			Entries[i].Editable = true;
			Entries[i].Visibility = true;
		}

		Button save_btn = new Button("Save");
		buttons_table.Attach( save_btn, 1, 2, 6, 7 );
		save_btn.Clicked += (evt_obj, evt_evt) => SaveClicked( new string[] { Entries[0].Text, Entries[1].Text, Entries[2].Text, Entries[3].Text, Entries[4].Text, Entries[5].Text }, NewWindow );

		NewWindow.ShowAll();
	}

	private void SaveClicked( string[] entries, Gtk.Window NewWindow )
	{
		Movie mov = new Movie( -1, entries[0], Int32.Parse(entries[1]), Int32.Parse(entries[2]), entries[3], entries[4], UInt32.Parse(entries[5]) );
		connect.Insert( "Movies", mov );
		ReviewList( MovView );
		NewWindow.Destroy();
	}

	private void ReviewList( MovieDBView MovView )
	{
		MovView.moviesListStore.Clear();
		Movies_DB = connect.Select<Movie>( "Movies" );

		for( int i = 0 ; i < Movies_DB.Length ; i++ )
			MovView.moviesListStore.AppendValues( Movies_DB[i].Title, Movies_DB[i].Type, Movies_DB[i].ReleaseDate, Movies_DB[i].Director, Movies_DB[i].Producent, Movies_DB[i].Duration );
	}
}
