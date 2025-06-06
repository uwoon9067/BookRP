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
        public MainWindow()
        {
            InitializeComponent();
            ClassificationBox.ItemsSource = Classification.List;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!BookNameBox.ValidateNotEmpty("책 제목")) return;
            if (!WriterBox.ValidateNotEmpty("글쓴이")) return;
            if (!ClassificationBox.ValidateComboBox("책 분류")) return;
        }
    }
}