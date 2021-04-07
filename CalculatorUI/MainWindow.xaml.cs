using System;
using System.Collections.Generic;
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

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operation = "";
        private long number1 = 0;
        private long number2 = 0;
        private long result = 0;
        private int resultFlag = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ManageInput(int buttonInput)
        {

            if (resultFlag == 1 && operation == "") // reset calculator when entering a number instead of further operations, after a calulation is done 
            {
                operation = "";
                number1 = 0;
                number2 = 0;
                result = 0;
                currentInputTextBox.Text = "0";
                totalInputTextBox.Text = "";
                resultFlag = 0;
            }

            if (operation == "")
            {
                number1 = (number1 * 10) + buttonInput;
                currentInputTextBox.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + buttonInput;
                currentInputTextBox.Text = number2.ToString();
            }
                
        }

        private void Calculate(long num1, long num2)
        {
            switch (operation)
            {
                case "/":
                    result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
            }
        }

        
        private void buttonNum_Click(object sender, RoutedEventArgs e)
        {
            ManageInput(Int32.Parse(((Button)sender).Content.ToString()));
        }


        private void buttonOperation_Click(object sender, RoutedEventArgs e)
        {
            operation = ((Button)sender).Content.ToString();
            totalInputTextBox.Text = number1.ToString() + " " + operation + " ";
        }


        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {

            if (operation != "")
            {
                totalInputTextBox.Text = number1.ToString() + " " + operation + " " + number2 + " =";
                Calculate(number1, number2);
                currentInputTextBox.Text = result.ToString();
                operation = "";
                number1 = result;
                number2 = 0;
                result = 0;
                resultFlag = 1;
            }
            else
            {
                // do nothing on purpose
            }
            
        }


        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            operation = "";
            number1 = 0;
            number2 = 0;
            result = 0;
            currentInputTextBox.Text = "0";
            totalInputTextBox.Text = "";
        }

        private void buttonClearCurrent_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }
            currentInputTextBox.Text = "0";
        }

        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= (-1);
                currentInputTextBox.Text = number1.ToString();
            }
            else
            {
                number2 *= (-1);
                currentInputTextBox.Text = number2.ToString();
            }
        }
    }
}
