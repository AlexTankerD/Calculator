using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using Calculator.Windows;
namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int tim = 0;

        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement element in Mainroot.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "AC")
            {
                TextBlock.Text = "";
            }
            else if (str == "=")
            {
                try
                {
                    string value = new DataTable().Compute(TextBlock.Text, null).ToString();
                    TextBlock.Text = "";
                    TextBlock.Text = value;
                }
                catch (System.Data.SyntaxErrorException)
                {
                    TextBlock.Text = "Ошибка";
                    await Task.Delay(400);
                    TextBlock.Text = "";
                }
                catch (System.Data.EvaluateException)
                {
                    TextBlock.Text = "Ошибка";
                    await Task.Delay(400);
                    TextBlock.Text = "";
                }


            }
            else if (str == "←")
            {
                string DeleteSymbol = TextBlock.Text;
                if (DeleteSymbol.Length > 0)
                {
                    DeleteSymbol = DeleteSymbol.Remove(DeleteSymbol.Length - 1);
                }


                TextBlock.Text = DeleteSymbol;

            }
            else if (str == "😀")
            {
                if (tim > 3)
                {
                    TextBlock.Text = "";
                }
                switch (tim)
                {
                    case 0:
                        TextBlock.FontSize = 14;
                        TextBlock.Text = "";
                        foreach (char x in "НЕ НАЖИМАЙ НА КНОПКУ")
                        {
                            TextBlock.Text += x;
                            await Task.Delay(40);
                        }
                        await Task.Delay(400);
                        TextBlock.Text = "";
                        break;
                    case 1:
                        TextBlock.FontSize = 14;
                        TextBlock.Text = "";
                        foreach (char x in "НЕ СМЕЙ НАЖИМАТЬ НА НЕЕ")
                        {
                            TextBlock.Text += x;
                            await Task.Delay(40);
                        }
                        await Task.Delay(400);
                        TextBlock.Text = "";
                        break;
                    case 2:
                        TextBlock.FontSize = 14;
                        TextBlock.Text = "";
                        foreach (char x in "ЭТО БЫЛО ПОСЛЕДНЕЕ ПРЕДУПРЕЖДЕНИЕ")
                        {
                            TextBlock.Text += x;
                            await Task.Delay(40);
                        }
                        await Task.Delay(400);
                        TextBlock.Text = "";
                        break;
                    case 3:
                        Window1 window1 = new Window1();

                        window1.Show();
                        break;

                }
                tim++;
            }
            else
            {
                TextBlock.Text += str;
            }
        }

    }
}
