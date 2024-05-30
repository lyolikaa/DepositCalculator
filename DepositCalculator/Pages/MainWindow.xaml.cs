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
                double principal = Convert.ToDouble(txtPrincipal.Text);
                double interestRate = Convert.ToDouble(txtInterestRate.Text);
                double timePeriod = Convert.ToDouble(txtTimePeriod.Text);

                double amount = principal * (1 + (interestRate / 100) * timePeriod);

                lblResult.Content = $"Total Amount: {amount:C}";

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