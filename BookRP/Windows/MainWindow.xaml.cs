using DiscordRPC;
using System.Resources;
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

namespace BookRP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DiscordRP _discordRP = new();

        public MainWindow()
        {
            InitializeComponent();
            ClassificationBox.ItemsSource = Classification.List;
            _discordRP.Initialize();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs()) return;

            string bookName = BookNameBox.Text;
            string writer = WriterBox.Text;
            string translator = TranslatorBox.Text;
            string classificationText = ClassificationBox.Text;

            _discordRP.UpdatePresence(CreateRichPresence(
                bookName,
                writer,
                translator,
                classificationText
                ));
        }

        private bool ValidateInputs()
        {
            return BookNameBox.ValidateNotEmpty("책 제목")
                && WriterBox.ValidateNotEmpty("글쓴이")
                && ClassificationBox.ValidateComboBox("책 분류");
        }

        private RichPresence CreateRichPresence(
            string bookName,
            string writer,
            string translator,
            string classificationText)
        {
            string imageKey = "000";
            if (Classification.Dictionary.TryGetValue(classificationText, out string? code))
            {
                imageKey = code;
            }

            string state = $"{writer} 지음";
            if (!string.IsNullOrWhiteSpace(translator))
            {
                state += $" {translator} 옮김";
            }

            return new RichPresence
            {
                Type = ActivityType.Watching,
                Details = bookName,
                State = state,
                Assets = new()
                {
                    LargeImageKey = imageKey,
                    LargeImageText = classificationText
                }
            };
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _discordRP.ClearPresense();
        }
    }
}
