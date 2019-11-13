using System;
using System.Collections.Generic;
using Gtk;
using Database;
using Entry;

public class MovieDBView
{
	public Gtk.ListStore moviesListStore;

	public MovieDBView( Gtk.VBox vbox )
	{
		//TreeView
		Gtk.TreeView tree = new Gtk.TreeView();
		vbox.PackStart( tree, true, true, 0 );
			//Creating columns in TreeView
		string[] ColumnTitles = new string[] {"Title", "Type", "ReleaseDate", "Director", "Producent", "Duration"};
		for( int i = 0 ; i < ColumnTitles.Length ; i++ )
			TreeViewManager.createColumn( ColumnTitles[i], tree,  i );
			//Creating storing List
		moviesListStore = new Gtk.ListStore( typeof(string), typeof(int), typeof(int), typeof(string), typeof(string), typeof(uint) );
		tree.Model = moviesListStore;

	}
}

/*
public class NewRecordWindow{
	public NewRecordWindow( DBConnection connect,  );
	*/
