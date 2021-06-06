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
        private Point locate;
        private Element element;
        public AddElementWindow()
        {
            InitializeComponent();
            
            ElementTypeCombobox.ItemsSource = BaseDataStore.ElementTypes;
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
                Location = locate,Purpose = PurposeTextBox.Text,Rotate = RotateComboBox.SelectedIndex*90
            };
            BaseDataStore.AddElement(el);
            element = el;
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

        public Element NewElement(Point locPoint)
        {
            locate = locPoint;
            this.ShowDialog();
            return element;
        }

        private void ElementTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ElementTypeCombobox.SelectedIndex < 0)
            {
                RotateComboBox.SelectedIndex = 0;
                RotateComboBox.IsEnabled = false;
                return;
            }
            ElCanvas.Children.Clear();
            switch (ElementTypeCombobox.SelectedIndex)
            {
                case 0:
                {
                    ElCanvas.Children.Add(new Diod(new Element() {Mark = "Д", Location = new Point(5, 5)}));
                    break;
                }
                case 1:
                {
                    ElCanvas.Children.Add(new Knopka1(new Element() { Mark = "В", Location = new Point(5, 5) }));
                    break;
                }
                case 2:
                {
                    ElCanvas.Children.Add(new Knopka2(new Element() { Mark = "В", Location = new Point(5, 5) }));
                    break;
                }
                case 3:
                {
                    ElCanvas.Children.Add(new Knopka3(new Element() { Mark = "Р", Location = new Point(5, 5) }));
                    break;
                }
                case 4:
                {
                    ElCanvas.Children.Add(new Connector1(new Element() { Mark = "Ш", Location = new Point(5, 5) }));
                    break;
                }
            }

            RotateComboBox.IsEnabled = true;
        }

        private void RotateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ElCanvas.Children.Count==0) return;
            int k = RotateComboBox.SelectedIndex;
            (ElCanvas.Children[0] as IControlInterface)?.Rotate(RotateComboBox.SelectedIndex*90);
        }
    }
}
