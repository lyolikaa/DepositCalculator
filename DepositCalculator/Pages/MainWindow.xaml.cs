using System.Linq;
using System.Windows;
using DepositCalculator.ViewModels;

namespace DepositCalculator
{
    public partial class MainWindow : Window
    {
        private CalcViewModel _vm = new ();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var validation = _vm.ValidateInput(); 
                if (!string.IsNullOrEmpty(validation))
                {
                    lblResult.Content = $"Invalid input: {validation}";
                    return;
                };


                lblResult.Content = $"Total Amount: {_vm.Calculate()} {_vm.Currency.Sign}";

            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}