using System.Windows;
using System.Windows.Controls;

namespace BookRP
{
    public static class InputValidator
    {
        public static bool ValidateNotEmpty(this TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"{fieldName}을(를) 비워둘 수 없습니다.", "Book RichPresence");
                textBox.Focus();

                return false;
            }

            return true;
        } 

        public static bool ValidateComboBox(this ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedIndex < 0 || comboBox.SelectedItem == null)
            {
                MessageBox.Show($"{fieldName}을(를) 선택해야 합니다.", "Book RichPresence");
                comboBox.Focus();
                return false;
            }

            return true;
        } 
    }
}
