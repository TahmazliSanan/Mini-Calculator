using System.Data;
using System.Text.RegularExpressions;

namespace MiniCalculator.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button is not null)
            {
                txtInput.Text += button.Text;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                string input = txtInput.Text;
                input = input.Replace("x", "*");

                if (Regex.IsMatch(input, @"\/\s*0(\D|$)"))
                {
                    txtInput.Text = "Cannot divide by zero!";
                    txtInput.ForeColor = Color.Red;
                    return;
                }

                DataTable dataTable = new DataTable();
                object result = dataTable.Compute(input, null);
                txtInput.Text = result.ToString();
            }
            catch (SyntaxErrorException)
            {
                txtInput.Text = "Syntax Error!";
                txtInput.ForeColor = Color.Red;
            }
            catch (EvaluateException)
            {
                txtInput.Text = "Invalid Expression!";
                txtInput.ForeColor = Color.Red;
            }
            catch (Exception)
            {
                txtInput.Text = "Error!";
                txtInput.ForeColor = Color.Red;
            }
        }
    }
}
