import java.io.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Main{
	static public void main( String[] args ){
		try{
			if( args.length != 2 ){  System.out.println("Please enter the filename and class name"); return; }
			if( args[0].indexOf("./") != 0 ){ System.out.println("For your safty load and save object only in current folder \"./\""); return; }
			if( !args[1].equals("Samochod") && !args[1].equals("Tramwaj") ){ System.out.println( "Invalid class name"); return; } 
			
			Object obj = Class.forName(args[1]).getConstructor().newInstance(); 

			File tempFile = new File( args[0] );
			if( tempFile.exists() ) ((Pojazd) obj).Load(args[0]);

			if( args[1].equals("Samochod") ) ((Samochod) obj).new Swing(args[0]);
			else if( args[1].equals("Tramwaj") ) ((Tramwaj) obj).new Swing(args[0]);

		}catch( Exception exc ){ System.out.println("Error occured"); return; };


	}
}

abstract class Pojazd implements java.io.Serializable{
	abstract public String toString();
	abstract public void Save( String path );
	abstract public void Load( String path );
}

class Samochod extends Pojazd implements java.io.Serializable{
	public int numer;	
	public String marka;
	public int rok_prod; 
	
	public Samochod( int numer, String marka, int rok_prod ){ this.numer = numer; this.marka = marka; this.rok_prod = rok_prod; }
	public Samochod(){}

	public String toString(){
		if( numer == 0 && marka == null && rok_prod == 0 ) return "Obiekt nie zainicjalizowany";
		return "Samochod o numerze " + Integer.toString(numer) + " marki " + marka + " wyprodukowany w  roku " + Integer.toString( rok_prod );
	}

	public void Save(String path){
		try{
			FileOutputStream fileOut = new FileOutputStream( path );
			ObjectOutputStream out = new ObjectOutputStream(fileOut);
			out.writeObject( this );
			out.close();
			fileOut.close();
		}catch( Exception exp ){ System.out.println("Error occured during saving object of class Samochod"); }
	}

	public void Load(String path){
		try{
			Samochod load;
			FileInputStream fileIn = new FileInputStream(path);
			ObjectInputStream in = new ObjectInputStream(fileIn);
			load = (Samochod) in.readObject();
			this.numer = load.numer;
			this.marka = load.marka;
			this.rok_prod = load.rok_prod;
			in.close();
			fileIn.close();
		}catch( Exception exp ){ System.out.println("Error occured during loading object of class Samochod"); }
	}

	public class Swing extends JFrame{
		JFrame f;
		Swing(String path){
			super(path);
			JFrame f = new JFrame("Edycja samochodu");
			f.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

			Container kontener = f.getContentPane();
			GridLayout layout = new GridLayout(4,2);
			kontener.setLayout(layout);

			JLabel numer_etykieta = new JLabel("Numer");
			kontener.add(numer_etykieta);
			JTextField numer = new JTextField( Integer.toString(Samochod.this.numer), 40 );
			kontener.add(numer);

			JLabel marka_etykieta = new JLabel("Marka");
			kontener.add(marka_etykieta);
			JTextField marka = new JTextField( Samochod.this.marka, 40 );
			kontener.add(marka);

			JLabel rok_prod_etykieta = new JLabel("Rok produkcji");
			kontener.add(rok_prod_etykieta);
			JTextField rok_prod = new JTextField( Integer.toString(Samochod.this.rok_prod), 40 );
			kontener.add(rok_prod);

			JButton b = new JButton("Zapisz");
			b.addActionListener(new ActionListener(){
						public void actionPerformed( ActionEvent e){
							Samochod.this.numer = Integer.parseInt( numer.getText() );
							Samochod.this.marka = marka.getText();
							Samochod.this.rok_prod = Integer.parseInt( rok_prod.getText()) ;
							Samochod.this.Save(path);
						}
					    });	
			kontener.add(b);

			f.pack();
			f.setVisible(true);
		}	
			
	}
}

class Tramwaj extends Pojazd implements java.io.Serializable{
	public int numer;
	public int linia;
	public int rok_prod;

	public Tramwaj( int numer, int linia, int rok_prod ){ this.numer = numer; this.linia = linia; this.rok_prod = rok_prod; }
	public Tramwaj(){}

	public String toString(){
		if( numer == 0 && linia == 0  && rok_prod == 0 ) return "Obiekt nie zainicjalizowany";
		return "Tramwaj o numerze " + Integer.toString(numer) + " linii " + Integer.toString(linia) + " wyprodukowany w  roku " + Integer.toString( rok_prod );
	}

	public void Save(String path){
		try{
			FileOutputStream fileOut = new FileOutputStream( path );
			ObjectOutputStream out = new ObjectOutputStream(fileOut);
			out.writeObject( this );
			out.close();
			fileOut.close();
		}catch( Exception exp ){ System.out.println("Error occured during saving object of class Tramwaj"); }
	}

	public void Load(String path){
		try{
			Tramwaj load;
			FileInputStream fileIn = new FileInputStream(path);
			ObjectInputStream in = new ObjectInputStream(fileIn);
			load = (Tramwaj) in.readObject();
			this.numer = load.numer;
			this.linia = load.linia;
			this.rok_prod = load.rok_prod;
			in.close();
			fileIn.close();
		}catch( Exception exp ){ System.out.println("Error occured during loading object of class Tramwaj"); }
	}

	public class Swing extends JFrame{
		JFrame f;
		Swing(String path){
			super(path);
			JFrame f = new JFrame("Edycja tramwaju");
			f.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );

			Container kontener = f.getContentPane();
			GridLayout layout = new GridLayout(4,2);
			kontener.setLayout(layout);

			JLabel numer_etykieta = new JLabel("Numer");
			kontener.add(numer_etykieta);
			JTextField numer = new JTextField( Integer.toString(Tramwaj.this.numer), 40 );
			kontener.add(numer);

			JLabel linia_etykieta = new JLabel("Linia");
			kontener.add(linia_etykieta);
			JTextField linia = new JTextField( Integer.toString(Tramwaj.this.linia), 40 );
			kontener.add(linia);

			JLabel rok_prod_etykieta = new JLabel("Rok produkcji");
			kontener.add(rok_prod_etykieta);
			JTextField rok_prod = new JTextField( Integer.toString(Tramwaj.this.rok_prod), 40 );
			kontener.add(rok_prod);

			JButton b = new JButton("Zapisz");
			b.addActionListener(new ActionListener(){
						public void actionPerformed( ActionEvent e){
							Tramwaj.this.numer = Integer.parseInt( numer.getText() );
							Tramwaj.this.linia = Integer.parseInt( linia.getText() );
							Tramwaj.this.rok_prod = Integer.parseInt( rok_prod.getText()) ;
							Tramwaj.this.Save(path);
						}
					    });	
			kontener.add(b);

			f.pack();
			f.setVisible(true);
		}	
			
	}
}
