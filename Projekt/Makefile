.PHONY = all Gui_Helpers clean
.DEFAULT_GOAL = all

CS = mcs
libs = -r:System.Data -r:MySql.Data
pkg = -pkg:gtk-sharp-2.0
to_dll = -target:library

SRCS = $(wildcard *.cs)
BINS = $(SRCS:%.cs=%)
path_raport=./Raport/


all: Main.exe

Main.exe: Main.cs Gui_MainWindow.dll
	$(CS) $(pkg) Main.cs -r:Gui_MainWindow.dll

Gui_MainWindow.dll: Gui_Movies.dll Gui_MainWindow.cs Database.dll Gui_Helpers Entry.dll
	$(CS) $(pkg) $(to_dll) -r:Gui_Movies.dll Gui_MainWindow.cs -r:Entry.dll -r:Gui_TreeViewManager.dll -r:Database.dll

Gui_Movies.dll: Database.dll Entry.dll Gui_Movies.cs Gui_Helpers
	$(CS) $(libs) $(pkg) $(to_dll) -r:Database.dll -r:Entry.dll -r:Gui_TreeViewManager.dll Gui_Movies.cs

Gui_Helpers: Gui_TreeViewManager.dll

Gui_TreeViewManager.dll: Gui_TreeViewManager.cs
	$(CS) $(pkg) $(to_dll) Gui_TreeViewManager.cs

Database.dll: Database.cs Entry.dll
	$(CS) $(libs) $(to_dll) Database.cs -r:Entry.dll

Entry.dll: Entry.cs Entry_exceptions.dll Entry_subclasses.dll
	$(CS) $(libs) $(to_dll) Entry.cs -r:Entry_subclasses.dll

Entry_subclasses.dll: Entry_subclasses.cs Entry_exceptions.dll
	$(CS) $(to_dll) Entry_subclasses.cs -r:Entry_exceptions.dll

Entry_exceptions.dll: Entry_exceptions.cs
	$(CS) $(to_dll) Entry_exceptions.cs

test.exe: Database.dll Entry.dll test.cs
	$(CS) $(libs) -r:Database.dll -r:Entry.dll test.cs

clean:
	@rm -f $(filter-out MySql.Data.dll, $(wildcard *.dll))
	@rm -f $(wildcard *.exe)
