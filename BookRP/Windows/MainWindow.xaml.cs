using DiscordRPC;
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
            if (!BookNameBox.ValidateNotEmpty("책 제목")) return;
            if (!WriterBox.ValidateNotEmpty("글쓴이")) return;
            if (!ClassificationBox.ValidateComboBox("책 분류")) return;

            string BookName = BookNameBox.Text;
            string Writer = WriterBox.Text;
            string Translator = TranslatorBox.Text;
            string ClassificationText = ClassificationBox.Text;
            string imageKey = Classification.Dictionary.TryGetValue(ClassificationText, out var code) ? code : "000" ;

            RichPresence richPresence = new()
            {
                Type = ActivityType.Watching,
                Details = $"{BookName}",
                State = $"{Writer} 지음",
                Assets = new()
                {
                    LargeImageKey = imageKey,
                    LargeImageText = ClassificationText
                }
            };

            if (!string.IsNullOrWhiteSpace(TranslatorBox.Text))
            {
                richPresence.State = $"{Writer} 지음 {Translator} 옮김";
            }
            
            _discordRP.UpdatePresence(richPresence);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            _discordRP.ClearPresense();
        }
    }
}