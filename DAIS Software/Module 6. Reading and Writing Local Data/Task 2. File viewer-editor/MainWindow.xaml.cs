using System;
using System.Collections.Generic;
using System.IO;
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

namespace Task_2._File_viewer_editor
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
            var path = inputBox.Text;
            GetAllExes(path);
        }

        void GetAllExes(string path)
        {

            try
            {
                var files = Directory.GetFiles(path)
                  .Where(x => System.IO.Path.GetExtension(x) == ".txt" ||
                              System.IO.Path.GetExtension(x) == ".log")
                  .ToList();


                if (files.Count == 0)
                {
                    return;
                }

                var sb = new StringBuilder();

                foreach (var file in files)
                {
                    sb.AppendLine(file);
                }

                resultBox.Text = sb.ToString();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
