using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<TextBox> neighborsTextBoxes;
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            InitializeNumberOfVerticesBox();
            neighborsTextBoxes = new List<TextBox>();
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
            adjacencyListGrid.Children.Clear();
            DisplayAdjacencyList();
        }
        private void DisplayAdjacencyList()
        {
            adjacencyListLabel.Visibility = Visibility.Visible;
            verticesBox.Visibility = Visibility.Visible;
            neighborsBox.Visibility = Visibility.Visible;
            exampleFormatBox.Visibility = Visibility.Visible;
            GenerateAdjacencyList();
        }

        private void GenerateAdjacencyList()
        {
            for (int i = 0; i < graph.vertexes.Count; i++)
            {
                GenerateVortexLabel(i);
                GenerateNeighborsTextBoxes(i);
            }
            GenerateProceedButton(graph.vertexes.Count);
        }

        private void GenerateProceedButton(int i)
        {
            var button = new Button 
            {
                Name = "proceedButton",
                Content = "Zatwierdź",
                FontSize = 18,
                Height = 40,
                Width = 100,
                Margin = new Thickness(600, 3 + 35 * i, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            button.Click += ProceedButton_Click;
            adjacencyListGrid.Children.Add(button);
        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            bool textBoxesContentCorrect = true;
            for (int i = 0; i < neighborsTextBoxes.Count; i++)
            {
                if (!RegexTextBox(neighborsTextBoxes[i]))
                    textBoxesContentCorrect = false;
            }
            if (!textBoxesContentCorrect)
                return;
            else
            {
                ClearNeighborsLists();
            }
        }

        private void ClearNeighborsLists()
        {
            List<string[]> lists = new List<string[]>();
            for (int i = 0; i < neighborsTextBoxes.Count; i++)
            {
                neighborsTextBoxes[i].Text = Regex.Replace(neighborsTextBoxes[i].Text, @"\s+", String.Empty);
                lists[i] = neighborsTextBoxes[i].Text.Split(',');
            }
            ConvertNeighborsListsToIntegers(lists);
        }

        private void ConvertNeighborsListsToIntegers(List<string[]> neighborsLists)
        {
            List<int[]> lists = new List<int[]>();
            for (int i = 0; i < neighborsLists.Count; i++)
            {
                lists[i] = Array.ConvertAll(neighborsLists[i], int.Parse);
            }
            graph.AddNeighbors(lists);
        }

        private void GenerateVortexLabel(int i)
        {
            var temp = new Label
            {
                Content = i + 1,
                FontSize = 18,
                Height = 30,
                Width = 30,
                Margin = new Thickness(160, 3 + 35 * i, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            adjacencyListGrid.Children.Add(temp);
        }
        private void GenerateNeighborsTextBoxes(int i)
        {
            var temp = new TextBox
            {
                Name = "neighborsListVortex" + i,
                FontSize = 18,
                Height = 30,
                Width = 500,
                Margin = new Thickness(200, 3 + 35 * i, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                BorderBrush = new SolidColorBrush(Colors.LightGray)
        };
            neighborsTextBoxes.Add(temp);
            adjacencyListGrid.Children.Add(temp);
        }

        private bool RegexTextBox(TextBox tmp)
        {
            if(Regex.IsMatch(tmp.Text, @"^([1-9]{1}(\d)*(,|,\s)?)*$"))
            {
                tmp.BorderBrush = new SolidColorBrush(Colors.LightGray);
                return true;
            }
            else
            {
                tmp.BorderBrush = new SolidColorBrush(Colors.Red);
                return false;
            }
        }
    }
}
