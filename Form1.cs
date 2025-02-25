using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp3
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            calculator=new Calculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        void btn1_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "1";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "1";
                    break;
            };
            calculator.display += "1";
            Displayer.Text = calculator.display;
        }
        void btn2_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "2";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "2";
                    break;
            };
            calculator.display += "2";
            Displayer.Text = calculator.display;
        }
        void btn3_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "3";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "3";
                    break;
            };
            calculator.display += "3";
            Displayer.Text = calculator.display;
        }
        void btn4_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "4";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "4";
                    break;
            };
            calculator.display += "4";
            Displayer.Text = calculator.display;
        }
        void btn5_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "5";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "5";
                    break;
            };
            calculator.display += "5";
            Displayer.Text = calculator.display;
        }
        void btn6_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "6";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "6";
                    break;
            };
            calculator.display += "6";
            Displayer.Text = calculator.display;
        }
        void btn7_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "7";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "7";
                    break;
            };
            calculator.display += "7";
            Displayer.Text = calculator.display;
        }
        void btn8_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "8";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "8";
                    break;
            };
            calculator.display += "8";
            Displayer.Text = calculator.display;
        }
        void btn9_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "9";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "9";
                    break;
            };
            calculator.display += "9";
            Displayer.Text = calculator.display;
        }
        void btn0_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += "0";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += "0";
                    break;
            };
            calculator.display += "0";
            Displayer.Text = calculator.display;
        }
        void btn10_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.op = "+";
                    calculator.display += "+";
                    calculator.status = Calculator.Status.Number2;
                    break;
                case Calculator.Status.Number2:
                    MessageBox.Show("暂只支持二数运算");
                    calculator.flush();
                    break;
            };
            Displayer.Text = calculator.display;
        }
        void btn11_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.op = "-";
                    calculator.display += "-";
                    calculator.status = Calculator.Status.Number2;
                    break;
                case Calculator.Status.Number2:
                    MessageBox.Show("暂只支持二数运算");
                    calculator.flush();
                    break;
            };
            Displayer.Text = calculator.display;
        }
        void btn12_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.op = "*";
                    calculator.display += "*";
                    calculator.status = Calculator.Status.Number2;
                    break;
                case Calculator.Status.Number2:
                    MessageBox.Show("暂只支持二数运算");
                    calculator.flush();
                    break;
            };
            Displayer.Text = calculator.display;
        }
        void btn13_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.op = "/";
                    calculator.display += "/";
                    calculator.status = Calculator.Status.Number2;
                    break;
                case Calculator.Status.Number2:
                    MessageBox.Show("暂只支持二数运算");
                    calculator.flush();
                    break;
            };
            Displayer.Text = calculator.display;
        }
        void btn14_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.display = calculator.number1;
                    break;
                case Calculator.Status.Number2:
                    if (calculator.number2=="") {
                        calculator.display = calculator.number1;
                    }
                    else { 
                        calculator.display = Convert.ToString(calculator.Calculate()); 
                    }
                    break;
            };
            Displayer.Text = calculator.display;
            calculator.flush();
        }
        void btn15_click(object sender, EventArgs e)
        {
            switch (calculator.status)
            {
                case Calculator.Status.Number1:
                    calculator.number1 += ".";
                    break;
                case Calculator.Status.Number2:
                    calculator.number2 += ".";
                    break;
            };
            calculator.display += ".";
            Displayer.Text = calculator.display;
        }
    }
}
