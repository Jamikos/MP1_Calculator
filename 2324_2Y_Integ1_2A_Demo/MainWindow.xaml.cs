using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _2324_2Y_Integ1_2A_Demo
{
    public partial class MainWindow : Window
    {
        Button[] btnNums = new Button[10];
        float num1 = 0;
        float num2 = 0;
        int ope = -1;

        public MainWindow()
        {
            InitializeComponent();

            btnNums[0] = btn0;
            btnNums[1] = btn1;
            btnNums[2] = btn2;
            btnNums[3] = btn3;
            btnNums[4] = btn4;
            btnNums[5] = btn5;
            btnNums[6] = btn6;
            btnNums[7] = btn7;
            btnNums[8] = btn8;
            btnNums[9] = btn9;

            for (int x = 0; x < btnNums.Length; x++)
                btnNums[x].Content = x;

            tbCalc.Text = "0";
            btnAdd.Content = "+";
            btnMin.Content = "-";
            btnMult.Content = "×";
            btnDiv.Content = "÷";
            btnEnter.Content = "=";
            btnClr.Content = "C";
            btnDot.Content = ".";
            btnPercent.Content = "%";
            btnPosNeg.Content = "±";
        }

        private void numberEnter(float x)
        {
            if (tbCalc.Text == "0")
            {
                tbCalc.Text = "";
            }

            string input = tbCalc.Text;
            input += x;

            if(input.Length > 12)
                input = input.Substring(1);

            if (ope == -1)
                num1 = float.Parse(input);
            else
            {
                num2 = float.Parse(input);

                ResetColor(btnAdd);
                ResetColor(btnMin);
                ResetColor(btnMult);
                ResetColor(btnDiv);
            }

            tbCalc.Text = input;
        }

        #region KeypadEvents
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            numberEnter(9);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(8);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(7);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(6);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(5);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(4);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(3);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(2);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(1);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            numberEnter(0);

        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!tbCalc.Text.Contains("."))
            {
                string input = tbCalc.Text;

                if (input == "")
                    input = "0";

                input += ".";

                tbCalc.Text = input;
            }
        }
        #endregion

        #region OperationEvents
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ResetColor(btnMin);
            ResetColor(btnMult);
            ResetColor(btnDiv);
            ope = 0;
            tbCalc.Text = "";
            ChangeColor(btnAdd);
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            ResetColor(btnAdd);
            ResetColor(btnMult);
            ResetColor(btnDiv);
            ope = 1;
            tbCalc.Text = "";
            ChangeColor(btnMin);
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            ResetColor(btnAdd);
            ResetColor(btnMin);
            ResetColor(btnDiv);
            ope = 2;
            tbCalc.Text = "";
            ChangeColor(btnMult);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            ResetColor(btnAdd);
            ResetColor(btnMin);
            ResetColor(btnMult);
            ope = 3;
            tbCalc.Text = "";
            ChangeColor(btnDiv);
        }

        private void btnClr_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            ope = -1;
            tbCalc.Text = "0";
            ResetColor(btnAdd);
            ResetColor(btnMin);
            ResetColor(btnMult);
            ResetColor(btnDiv);
        }

        private void btnPosNeg_Click(object sender, RoutedEventArgs e)
        {
            string input = tbCalc.Text;

            if (!string.IsNullOrEmpty(input))
            {
                float currentNum = float.Parse(input);
                currentNum = -currentNum;

                tbCalc.Text = currentNum.ToString();

                if (ope == -1)
                    num1 = currentNum;
                else
                    num2 = currentNum;
            }
        }

        private void btnPercent_Click(object sender, RoutedEventArgs e)
        {
            string input = tbCalc.Text;

            if (!string.IsNullOrEmpty(input))
            {
                float currentNum = float.Parse(input);
                currentNum = currentNum/100;

                tbCalc.Text = currentNum.ToString();

                if (ope == -1)
                    num1 = currentNum;
                else
                    num2 = currentNum;
            }
        }
        #endregion

        private void ChangeColor(Button selectedButton)
        {
            selectedButton.Foreground = new SolidColorBrush(Color.FromRgb(247, 144, 1));
            selectedButton.Background = Brushes.White;
        }
        private void ResetColor(Button selectedButton)
        {
            selectedButton.Foreground = Brushes.White;
            selectedButton.Background = new SolidColorBrush(Color.FromRgb(247, 144, 1));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            ResetColor(btnAdd);
            ResetColor(btnMin);
            ResetColor(btnMult);
            ResetColor(btnDiv);

            switch (ope)
            {
                case 0:
                    num1 += num2;
                    break;
                case 1:
                    num1 -= num2;
                    break;
                case 2:
                    num1 *= num2;
                    break;
                case 3:
                    num1 /= num2;
                    break;
            }
            
            if(ope > -1)
            {
                tbCalc.Text = num1.ToString();
                ope = -1;
                num2 = 0;
            }
        }        
    }
}
