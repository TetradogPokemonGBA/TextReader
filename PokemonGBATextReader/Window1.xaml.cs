/*
 * Creado por SharpDevelop.
 * Usuario: tetra
 * Fecha: 24/05/2017
 * Hora: 3:56
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using PokemonGBAFrameWork;
using Gabriel.Cat;
namespace PokemonGBATextReader
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		RomGba rom;
		public Window1()
		{
			InitializeComponent();
		}
		void MiCargar_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog open=new OpenFileDialog();
			open.Filter="Pokemon GBA|*.gba";
			if(open.ShowDialog().GetValueOrDefault())
			{
				rom=new RomGba(open.FileName);
				btnCargarTexto.IsEnabled=true;
			}else if(rom!=null){
				MessageBox.Show("No se ha cambiado la rom!");
			}else{
				MessageBox.Show("No se ha cargado nada...");
			}
			   
		}
		void BtnCargarTexto_Click(object sender, RoutedEventArgs e)
		{
			const char INDICADORHEX='x';
			int offset,lenght;
			txtTextoCargado.Text="";
			if(!string.IsNullOrEmpty(txtOffset.Text)&&!string.IsNullOrEmpty(txtLongitud.Text))
			{
				try{
				if(txtOffset.Text.Length>2 &&txtOffset.Text[1]==INDICADORHEX)
					offset=(int)((Hex)txtOffset.Text.Substring(2));
				else offset=Convert.ToInt32(txtOffset.Text);
				
				if(txtLongitud.Text.Length>2 &&txtLongitud.Text[1]==INDICADORHEX)
					lenght=(int)((Hex)txtLongitud.Text.Substring(2));
				else lenght=Convert.ToInt32(txtLongitud.Text);
				
				txtTextoCargado.Text=BloqueString.ToString(rom.Data.SubArray(offset,lenght));
				}catch{
					MessageBox.Show("El formato para escribir en hexadecimal es 0xNumero en hexadecimal, si no ha sido por eso te has pasado con el numero...es demasiado grande","A Ocurrido un error",MessageBoxButton.OK,MessageBoxImage.Warning);
				}
			}else{
				MessageBox.Show("falts poner la informacion para la traducción [inicio,longitud]","Atención",MessageBoxButton.OK,MessageBoxImage.Exclamation);
			}
		}
		void MiSobre_Click(object sender, RoutedEventArgs e)
		{
			if(MessageBox.Show("Esta app esta bajo licencia GNU v3 el autor es pikachu240 y se la dedico a sangus103\n¿Quieres ver el codigo fuente?","Sobre la app",MessageBoxButton.YesNo,MessageBoxImage.Information)==MessageBoxResult.Yes)
				System.Diagnostics.Process.Start("https://github.com/TetradogPokemonGBA/TextReader");
		}
	}
}