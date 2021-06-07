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
            Graph.Children.Clear();

            List<RadioButton> radioButtons = Oper.Children.OfType<RadioButton>().ToList();
            radioButtons.AddRange(Ent.Children.OfType<RadioButton>().ToArray());

            try
            {
                RadioButton rbTarget = radioButtons.Where(r => r.GroupName == "LogElem" && r.IsChecked == true).Single();

                DrawSquare(int.Parse(rbTarget.Tag.ToString()));

                RadioButton rbTarget2 = radioButtons.Where(r => r.GroupName == "Entry" && r.IsChecked == true).Single();

                DrawEnters(int.Parse(rbTarget2.Content.ToString()));

                DrawAnswers();
            }
            catch
            {
                MessageBox.Show("Выберите варианты для построения!");
                Graph.Children.Clear();
            }

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var input = Graph.Children.OfType<TextBox>().Where(i => i.Tag.ToString() == "Inp").ToArray();
            var output = Graph.Children.OfType<TextBox>().Where(i => i.Tag.ToString() == "Out").ToArray();

            List<RadioButton> radioButtons = Oper.Children.OfType<RadioButton>().ToList();
            RadioButton rbTarget = radioButtons.Where(r => r.GroupName == "LogElem" && r.IsChecked == true).Single();

            for (var i = 0; i < input.Length; i++)
            {
                if ((input[i].Text == "1") || ( input[i].Text == "0"))
                { 

                }
                else
                {
                    MessageBox.Show("Введите корректные данные сигналов, используя символы 1 и 0");
                    return;
                }
            }

            var inp = rbTarget.Tag.ToString();

            bool flag = true;

            switch (inp)
            {
                case "1":
                    flag = true;
                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i].Text == "0")
                        {
                            flag = false;
                        }

                    }

                    if (flag == false)
                    {
                        output[0].Text = "0";
                        output[1].Text = "1";
                    }
                    else
                    {
                        output[0].Text = "1";
                        output[1].Text = "0";
                    }
                    break;

                case "2":
                    flag = false;
                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i].Text == "1")
                        {
                            flag = true;
                        }
                    }

                    if (flag == false)
                    {
                        output[0].Text = "0";
                        output[1].Text = "1";
                    }
                    else
                    {
                        output[0].Text = "1";
                        output[1].Text = "0";
                    }
                    break;

                case "3":
                    flag = true;
                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i].Text == "0")
                        {
                            flag = false;
                        }

                    }

                    if (flag == true)
                    {
                        output[0].Text = "0";
                        output[1].Text = "1";
                    }
                    else
                    {
                        output[0].Text = "1";
                        output[1].Text = "0";
                    }
                    break;

                case  "4":
                    flag = false;
                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i].Text == "1")
                        {
                            flag = true;
                        }
                    }

                    if (flag == true)
                    {
                        output[0].Text = "0";
                        output[1].Text = "1";
                    }
                    else
                    {
                        output[0].Text = "1";
                        output[1].Text = "0";
                    }
                    break;


                case "5":
                    flag = true;
                    for (var i = 0; i < input.Length - 1; i++)
                    {
                        if (input[i].Text == input[i+1].Text)
                        {

                        }
                        else
                        {
                            flag = false;
                        }

                        if (flag == true)
                        {
                            output[0].Text = "1";
                            output[1].Text = "0";
                        }
                        else
                        {
                            output[0].Text = "0";
                            output[1].Text = "1";
                        }
                    }
                    break;

                case "6":
                    flag = true;
                    for (var i = 0; i < input.Length - 1; i++)
                    {
                        if (input[i].Text != input[i + 1].Text)
                        {

                        }
                        else
                        {
                            flag = false;
                        }

                        if (flag == true)
                        {
                            output[0].Text = "1";
                            output[1].Text = "0";
                        }
                        else
                        {
                            output[0].Text = "0";
                            output[1].Text = "1";
                        }
                    }
                    break;

                case "7":
                    flag = true;
                    for (var i = 0; i < input.Length - 1; i++)
                    {
                        if ((input[i].Text == "1") && (input[i+1].Text == "0"))
                        {
                            flag = false;
                        }
                    }

                    if (flag == true)
                    {
                        output[0].Text = "1";
                        output[1].Text = "0";
                    }
                    else
                    {
                        output[0].Text = "0";
                        output[1].Text = "1";
                    }
                    break;
            }
        }

        private void DrawEnters(int num)
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Green;

            double x1 = 180;
            double y1 = 130;

            for (int i = 0; i < num; i++)
            {
                var line = CreateLine(x1, y1, x1 + 20, y1, color);
                Graph.Children.Add(line);
                DrawTextBoxInp(x1 - 20, y1 - 10);
                y1 += 30;
            }
        }

        private void DrawAnswers()
        {
            SolidColorBrush color = new SolidColorBrush();
            color.Color = Colors.Green;

            double x1 = 250;
            double y1 = 130;
            for (int i = 0; i < 2; i++)
            {
                var line = CreateLine(x1, y1, x1 + 20, y1, color);
                Graph.Children.Add(line);
                DrawTextBoxOut(x1 + 20, y1 - 10);
                y1 += 30;
            }

            Ellipse ellipse = new Ellipse();

            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = Brushes.Green;

            Canvas.SetLeft(ellipse, x1 - 5);
            Canvas.SetTop(ellipse, y1 - 35);

            Graph.Children.Add(ellipse);
        }

        private void DrawTextBoxOut(double x, double y)
        {
            TextBox text = new TextBox();

            text.Text = "0";
            text.Tag = "Out";
            text.Background = Brushes.White;
            text.Width = 20;
            text.Height = 20;

            Canvas.SetTop(text, y);
            Canvas.SetLeft(text, x);

            Graph.Children.Add(text);

        }

        private void DrawTextBoxInp(double x, double y)
        {
            TextBox text = new TextBox();

            text.Text = "0";
            text.Tag = "Inp";
            text.Background = Brushes.White;
            text.Width = 20;
            text.Height = 20;

            Canvas.SetTop(text, y);
            Canvas.SetLeft(text, x);

            Graph.Children.Add(text);

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


            switch (operation)
            {
                case 1:
                    text.Text = "&";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;


                case 2:
                    text.Text = "|";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 3:
                    text.Text = "&-";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 4:
                    text.Text = "|-";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 5:
                    text.Text = "==";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 6:
                    text.Text = "М2";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;

                case 7:
                    text.Text = "->";
                    text.FontSize = 20;
                    Canvas.SetLeft(text, 220);
                    Canvas.SetTop(text, 100);
                    Graph.Children.Add(text);
                    break;
            }

        }
    }
}
