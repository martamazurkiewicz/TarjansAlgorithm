using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Graph graph;
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            InitializeNumberOfVerticesBox();
        }

        private void InitializeNumberOfVerticesBox()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 31; i++)
            {
                list.Add(i);
            }
            numberOfVerticesBox.ItemsSource = list;
        }
        private void NumberOfVerticesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //index of items in combobox starts from 0, actual items starts from 1
            graph = new Graph(((ComboBox)sender).SelectedIndex + 1);
            DisplayAdjacencyList();
        }
        private void DisplayAdjacencyList()
        {
            adjacencyListLabel.Visibility = Visibility.Visible;
            verticesBox.Visibility = Visibility.Visible;
            GenerateVerticesLabels();
        }

        private void GenerateVerticesLabels()
        {
            for (int i = 0; i < graph.vertexes.Count; i++)
            {
                GenerateVortexLabel(i);
            }
        }
        private void GenerateVortexLabel(int i)
        {
            var temp = new Label();
            temp.Content = i + 1;
            temp.FontSize = 16;
            temp.Height = 30;
            temp.Width = 30;
            temp.Margin = new Thickness(80, 140 + 30 * i, 0, 0);
            temp.HorizontalAlignment = HorizontalAlignment.Left;
            temp.Background = new SolidColorBrush(Colors.White);
            temp.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(temp);
        }
    }
}
