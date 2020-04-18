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

        //function which determine what happen when the user chooses the number of vertices 
        private void NumberOfVerticesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //index of items in combobox starts from 0, actual items starts from 1
            graph = new Graph(((ComboBox)sender).SelectedIndex + 1);
            GenerateAdjacencyList();
        }
        private void GenerateAdjacencyList()
        {
            adjacencyListGrid.Children.Clear();
            adjacencyListLabel.Visibility = Visibility.Visible;
            verticesBox.Visibility = Visibility.Visible;
            neighborsBox.Visibility = Visibility.Visible;
            exampleFormatBox.Visibility = Visibility.Visible;
            DisplayAdjacencyList();
        }

        private void DisplayAdjacencyList()
        {
            for (int i = 0; i < graph.AdjacencyList.Count; i++)
            {
                GenerateVerticesLabels(i);
                GenerateNeighborsTextBoxes(i);
            }
            GenerateProceedButton(graph.AdjacencyList.Count);
        }

        private void GenerateVerticesLabels(int labelNumber)
        {
            var temp = new Label
            {
                Content = labelNumber + 1,
                FontSize = 18,
                Height = 30,
                Width = 30,
                Margin = new Thickness(160, 3 + 35 * labelNumber, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            adjacencyListGrid.Children.Add(temp);
        }

        private void GenerateNeighborsTextBoxes(int boxNumber)
        {
            var temp = new TextBox
            {
                FontSize = 18,
                Height = 30,
                Width = 500,
                Margin = new Thickness(200, 3 + 35 * boxNumber, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                BorderBrush = new SolidColorBrush(Colors.LightGray)
            };
            neighborsTextBoxes.Add(temp);
            adjacencyListGrid.Children.Add(temp);
        }

        private void GenerateProceedButton(int topMargin)
        {
            var button = new Button 
            {
                Content = "Zatwierdź",
                FontSize = 18,
                Height = 40,
                Width = 100,
                Margin = new Thickness(600, 3 + 35 * topMargin, 0, 0),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            button.Click += Button_Click;
            adjacencyListGrid.Children.Add(button);
        }

        public void Button_Click(object sender, EventArgs e)
        {
            bool textBoxesContentCorrect = true;
            for (int i = 0; i < neighborsTextBoxes.Count; i++)
                if (!RegexTextBox(neighborsTextBoxes[i]))
                    textBoxesContentCorrect = false;
            if (!textBoxesContentCorrect)
                return;
            else
                graph.AddNeighbors(ConvertNeighborsTextBoxesContentToStringArray());
        }

        private bool RegexTextBox(TextBox tmp)
        {
            if (Regex.IsMatch(tmp.Text, @"^([1-9]\d*(\s,[1-9]\d*|,[1-9]\d*|,\s[1-9]\d*|)*|)$"))
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
        private List<string[]> ConvertNeighborsTextBoxesContentToStringArray()
        {
            List<string[]> lists = new List<string[]>();
            foreach (var item in neighborsTextBoxes)
            {
                item.Text = Regex.Replace(item.Text, @"\s+", String.Empty);
                lists.Add(item.Text.Split(','));
            }
            return lists;
        }
    }
}
