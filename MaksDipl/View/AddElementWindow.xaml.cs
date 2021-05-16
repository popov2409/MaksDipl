using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaksDipl.Models;
using MaksDipl.Services;
using Microsoft.Win32;

namespace MaksDipl.View
{
    /// <summary>
    /// Логика взаимодействия для AddElementWindow.xaml
    /// </summary>
    public partial class AddElementWindow : Window
    {
        private BaseDataStore dbStore;
        private Point locate;
        public AddElementWindow(BaseDataStore dbProxy,Point loc)
        {
            InitializeComponent();
            dbStore = dbProxy;
            locate = loc;
            ElementTypeCombobox.ItemsSource = dbProxy.ElementTypes;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {

            if (ElementTypeCombobox.SelectedIndex < 0 || MarkTextBox.Text.Length < 1)
            {
                MessageBox.Show("Укажите тип и маркировку элемента!");
                return;
            }

            int elT = ((KeyValuePair<int, string>)ElementTypeCombobox.SelectedItem).Key;
            Element el = new Element()
            {
                Id = Guid.NewGuid(), ElementType = elT, Mark = MarkTextBox.Text, ImageSource = _photoPath,
                Location = locate,Purpose = PurposeTextBox.Text
            };
            dbStore.AddElement(el);
            this.Close();
        }

        private string _photoPath="";
        private void LoadFotoButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp";
            if (ofd.ShowDialog() == true)
            {
                _photoPath = ofd.SafeFileName;
                ElementPictureImage.Source = new BitmapImage(new Uri(new Uri("file://"),
                    AppDomain.CurrentDomain.BaseDirectory + "images/" + _photoPath));
            }
        }
    }
}
