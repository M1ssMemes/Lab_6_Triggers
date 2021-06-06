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

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<RadioButton> radioButtons = Oper.Children.OfType<RadioButton>().ToList();

            RadioButton rbTarget = radioButtons.Where(r => r.GroupName == "LogElem" && r.IsChecked == true).Single();
            DrawSquare(int.Parse(rbTarget.Tag.ToString()));

            RadioButton rbTarget2 = radioButtons.Where(r => r.GroupName == "Entry" && r.IsChecked == true).Single();
            DrawEnters(int.Parse(rbTarget2.Content.ToString()));
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DrawEnters(int num)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Green;

            double x1 = 180;
            double y1 = 130;

            switch (num)
            {
                case 2:
                    for (int i = 0; i < num; i++)
                    {
                        var line = CreateLine(x1, y1, x1 + 20, y1, color);
                        Graph.Children.Add(line);

                        DrawText(x1 - 10, y1 - 5, i);

                        y1 += 30;
                    }
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

            }

        }

        private void DrawText(double x, double y, int i)
        {
            TextBox text = new TextBox();

            text.Text = "0";
            text.Tag = i.ToString();



        }

        public Line CreateLine(double x1, double y1, double x2, double y2, SolidColorBrush color)
        {
            var line = new Line();
            line.Stroke = color;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Tag = color.Color.ToString();
            return line;
        }

        private void DrawSquare(int operation)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Green;


            System.Windows.Shapes.Rectangle rect;
            rect = new System.Windows.Shapes.Rectangle();

            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.White);
            rect.StrokeThickness = 2;


            rect.Width = 50;
            rect.Height = 200;

            Canvas.SetLeft(rect, 200);
            Canvas.SetTop(rect, 100);

            Graph.Children.Add(rect);

            TextBlock text = new TextBlock();
            color.Color = Colors.Black;
            text.Foreground = color;
            text.FontSize = 50;

            switch (operation)
            {
                case 1:
                    text.Text = "-";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 2:
                    text.Text = "&";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 3:
                    text.Text = "|";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 4:
                    text.Text = "& -";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 5:
                    text.Text = "|-";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 6:
                    text.Text = "==";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 7:
                    text.Text = "М2";
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;
            }

        }

        public Line CreateLine(double x1, double y1, double x2, double y2, SolidColorBrush color)
        {
            var line = new Line();
            line.Stroke = color;
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            return line;
        }
    }
}
