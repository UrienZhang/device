using System;
using System.Windows;
using System.Windows.Controls;

namespace Desk
{
     /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
    
    public class MyWindow : Window
    {
        private Label label1;

        public MyWindow()
        {
            Width = 300;
            Height = 300;

            Grid grid = new Grid();
            Content = grid;

            Button button1 = new Button();
            button1.Content = "Say Hello!";
            button1.Height = 23;
            button1.Margin = new Thickness(96, 50, 107, 0);
            button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            button1.Click += new RoutedEventHandler(button1_Click);
            grid.Children.Add(button1);

            label1 = new Label();
            label1.Margin = new Thickness(84, 115, 74, 119);
            grid.Children.Add(label1);


        }

        void button1_Click(object sender, RoutedEventArgs e)
        {
            label1.Content = "Hello WPF!";
        }

        [STAThread]
        public static void Main()
        {
            Application app = new Application();

            app.Run(new MyWindow());
        }
    }
}

