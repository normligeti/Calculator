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
        double num1, num2;
        private string numberInput = "";
        private string operation = "";
        private bool isOperationClicked = false;
        private bool isEqualsClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateAndShowResult()
        {
            double result = 0;

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
            totalInputTextBox.Text = num1.ToString() + " " + operation + " " + num2.ToString() + " =";
            currentInputTextBox.Text = result.ToString();
        }

        private void buttonNum_Click(object sender, RoutedEventArgs e)
        {

            if (currentInputTextBox.Text == "0" || isOperationClicked)
            {
                currentInputTextBox.Text = "";
            }
            if (isEqualsClicked)
            {
                currentInputTextBox.Text = "";
                totalInputTextBox.Text = "";
                numberInput = "";
                operation = "";
            }
            currentInputTextBox.Text += ((Button)sender).Content.ToString();
            isOperationClicked = false;
            isEqualsClicked = false;

        }

        private void buttonComma_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInputTextBox.Text.Contains(","))
            {
                currentInputTextBox.Text += ((Button)sender).Content.ToString();
            }
        }

        private void buttonOperation_Click(object sender, RoutedEventArgs e)
        {
            operation = ((Button)sender).Content.ToString();
            numberInput = currentInputTextBox.Text;
            totalInputTextBox.Text = numberInput + " " + operation + " "; 
            isOperationClicked = true;
            isEqualsClicked = false;
        }


        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {
            if (operation != "")
            {
                if (!isEqualsClicked)
                {
                    num1 = double.Parse(numberInput);
                    num2 = double.Parse(currentInputTextBox.Text);
                }
                else
                {
                    num1 = double.Parse(currentInputTextBox.Text);
                }
                CalculateAndShowResult();
                isEqualsClicked = true;
            }
        }


        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonClearCurrent_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
