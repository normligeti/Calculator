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
        private double num1, num2;
        private string numberInput = "";
        private string operation = "";
        private bool isOperationClicked = false;
        private bool isEqualsClicked = false;
        private const int maxDigitCount = 12;

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
            totalInputTextBlock.Text = num1.ToString() + " " + operation + " " + num2.ToString() + " =";
            currentInputTextBlock.Text = result.ToString();
        }

        private void buttonNum_Click(object sender, RoutedEventArgs e)
        {
            if (currentInputTextBlock.Text == "0" || isOperationClicked)
            {
                currentInputTextBlock.Text = "";
            }
            if (isEqualsClicked)
            {
                currentInputTextBlock.Text = "";
                totalInputTextBlock.Text = "";
                numberInput = "";
                operation = "";
            }

            if (currentInputTextBlock.Text.Count() < maxDigitCount)
            {
                currentInputTextBlock.Text += ((Button)sender).Content.ToString();
                isOperationClicked = false;
                isEqualsClicked = false;
            }
        }

        private void buttonComma_Click(object sender, RoutedEventArgs e)
        {
            if (!currentInputTextBlock.Text.Contains(","))
            {
                currentInputTextBlock.Text += ((Button)sender).Content.ToString();
                isOperationClicked = false;
                isEqualsClicked = false;
            }
        }

        private void buttonOperation_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "" || isOperationClicked || isEqualsClicked)
            {
                operation = ((Button)sender).Content.ToString();
                numberInput = currentInputTextBlock.Text;
                totalInputTextBlock.Text = numberInput + " " + operation + " ";
                isOperationClicked = true;
                isEqualsClicked = false;
            }
            else
            {
                num1 = double.Parse(numberInput);
                num2 = double.Parse(currentInputTextBlock.Text);
                CalculateAndShowResult();
                operation = ((Button)sender).Content.ToString();
                numberInput = currentInputTextBlock.Text;
                isOperationClicked = true;
            }
        }

        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {
            if (operation != "")
            {
                if (!isEqualsClicked)
                {
                    num1 = double.Parse(numberInput);
                    num2 = double.Parse(currentInputTextBlock.Text);
                }
                else
                {
                    num1 = double.Parse(currentInputTextBlock.Text);
                }
                CalculateAndShowResult();
                isEqualsClicked = true;
            }
        }

        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            numberInput = "";
            operation = "";
            isOperationClicked = false;
            isEqualsClicked = false;
            currentInputTextBlock.Text = "0";
            totalInputTextBlock.Text = "";
        }

        private void buttonClearCurrent_Click(object sender, RoutedEventArgs e)
        {
            currentInputTextBlock.Text = "0";
        }

        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            double i = double.Parse(currentInputTextBlock.Text);
            i *= -1;
            currentInputTextBlock.Text = i.ToString();
        }

    }
}
