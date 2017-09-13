/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 13/09/2017
 * Hora: 6:50
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
using Gabriel.Cat.Extension;
using PokemonGBAFrameWork;

namespace PokemonGBATextReader
{
	/// <summary>
	/// Interaction logic for WindowsBuscar.xaml
	/// </summary>
	public partial class WindowsBuscar : Window
	{
		RomGba rom;
		int offsetEncontrado;
		int lenght;
		public WindowsBuscar(RomGba rom)
		{
			this.rom=rom;
			lenght=-1;
			InitializeComponent();
		}

		public int OffsetEncontrado {
			get {
				return offsetEncontrado;
			}
		}

		public int Lenght {
			get {
				return lenght;
			}
		}
		public bool Encontrado
		{
			get{return offsetEncontrado>0;}
		}

		void btnBuscar_Click(object sender, RoutedEventArgs e)
		{
			byte[] bytesText=BloqueString.ToByteArray(txtTextoABuscar.Text);
			bytesText=bytesText.SubArray(bytesText.Length-1);//quito el FE para que busque frases sin acabar
			lenght=bytesText.Length;
			offsetEncontrado=rom.Data.SearchArray(bytesText);
			if(Encontrado)
				this.Close();
			else tbMensajeNoEncontrado.Visibility=Visibility.Visible;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}