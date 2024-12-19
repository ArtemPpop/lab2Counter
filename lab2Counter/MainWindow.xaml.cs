using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2Counter
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

        // Метод для подсчета гласных, согласных и символов
        private (int vowels, int consonants, int total) CountLetters(string text)
        {
            var vowels = "аеёиоуыэюя";
            var consonants = "бвгдеёжзийклмнопрстфхцчшщ";
            int glasnihCount = 0;
            int soglasnihCount = 0;
            int totalCount = 0;

            foreach (var ch in text.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    glasnihCount++;
                }
                else if (consonants.Contains(ch))
                {
                    soglasnihCount++;
                }
                if (char.IsLetter(ch))
                {
                    totalCount++;
                }
            }

            return (glasnihCount, soglasnihCount, totalCount);
        }

        private async Task CountLettersAsync(string text)
        {
            await Task.Delay(1000);  
            var (glasnih, soglasnih, total) = CountLetters(text);
            lblResult.Content = $"Гласных: {glasnih}\nСогласных: {soglasnih}\nСимволов: {total}";
        }
        private async void btnCount_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Введите текст");
                return;
            }

            await CountLettersAsync(text);
        }
    }
}