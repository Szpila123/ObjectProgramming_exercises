using Gtk;
using System;

public class TreeViewManager
{
	public TreeViewManager(){}

	//For creating a columns of name name and index num for Gtk.TreeView
	public static void createColumn( string name, Gtk.TreeView tree, int num ){
		Gtk.TreeViewColumn column = new Gtk.TreeViewColumn();
		column.Title = name;
		Gtk.CellRendererText NameCell = new Gtk.CellRendererText();
		column.PackStart( NameCell, true );
		tree.AppendColumn( column );
		column.AddAttribute( NameCell, "text", num );
	}
}
