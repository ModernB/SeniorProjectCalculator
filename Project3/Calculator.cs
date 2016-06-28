using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project3
{
    public enum Operator
    { 
        None,Minus,Add,Multiply,Divide
    }
    public partial class Calculator : Form
    {
        LED L1,L2,L3,L4,L5,L6,L7,L8;
        LinkedList<LED> display = new LinkedList<LED>();
        String input = "";
        private Operator currentOp;
        double total = 0;
        double currVal = 0;
        char[] line;
        bool isHex = false;
        //Stack numbers = new Stack();
        public Calculator()
        {
            InitializeComponent();
            
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            
            L1 = new LED(10, 10);
            L2 = new LED(80, 10);
            L3 = new LED(150, 10);
            L4 = new LED(220, 10);
            L5 = new LED(290, 10);
            L6 = new LED(360, 10);
            L7 = new LED(430, 10);
            L8 = new LED(500, 10);

            //added new code
            radDec.Checked = true;

            //deactivate roman buttons
            btnRomI.Enabled = false;
            btnRom5.Enabled = false;
            btnRom10.Enabled = false;
            btnRom50.Enabled = false;
            btnRom100.Enabled = false;
            btnRom500.Enabled = false;
            btnRom1000.Enabled = false;

            //deactivate title
            lblRomDisplay.Visible = false;
            lblRomTitle.Visible = false;
            lblRomDisplay.Text = "";


            display.AddFirst(L1);
            display.AddFirst(L2);
            display.AddFirst(L3);
            display.AddFirst(L4);
            display.AddFirst(L5);
            display.AddFirst(L6);
            display.AddFirst(L7);
            display.AddFirst(L8);

            isHex = false;
            btnHex.BackColor = Color.White;

            for (int i = 0; i < display.Count; i++)
            {
                for (int j = 0; j < display.ElementAt(i).bars.Count; j++)
                {
                    display.ElementAt(i).bars.ElementAt(j).deactivate();
                    Controls.Add(display.ElementAt(i).bars.ElementAt(j));
                }
            }
            display.ElementAt(0).isZero();
     

        }
      

        public void updateDisplay()
        {
            line = input.ToCharArray();
            if(line.Length > 8)
            {
                Array.Resize(ref line,8);
            }


            //determine how many leds are needed up 8 are needed
            switch(line.Length)
            {
                case 0://if there are no characters
                    display.ElementAt(0).isZero();
                    display.ElementAt(1).isNull();
                    display.ElementAt(2).isNull();
                    display.ElementAt(3).isNull();
                    display.ElementAt(4).isNull();
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 1://if there is one led
                    display.ElementAt(0).displayNumber(line[0]);
                    display.ElementAt(1).isNull();
                    display.ElementAt(2).isNull();
                    display.ElementAt(3).isNull();
                    display.ElementAt(4).isNull();
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 2:
                    display.ElementAt(0).displayNumber(line[1]);
                    display.ElementAt(1).displayNumber(line[0]);
                    display.ElementAt(2).isNull();
                    display.ElementAt(3).isNull();
                    display.ElementAt(4).isNull();
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 3:
                    display.ElementAt(0).displayNumber(line[2]);
                    display.ElementAt(1).displayNumber(line[1]);
                    display.ElementAt(2).displayNumber(line[0]);
                    display.ElementAt(3).isNull();
                    display.ElementAt(4).isNull();
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 4:
                    display.ElementAt(0).displayNumber(line[3]);
                    display.ElementAt(1).displayNumber(line[2]);
                    display.ElementAt(2).displayNumber(line[1]);
                    display.ElementAt(3).displayNumber(line[0]);
                    display.ElementAt(4).isNull();
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 5:
                    display.ElementAt(0).displayNumber(line[4]);
                    display.ElementAt(1).displayNumber(line[3]);
                    display.ElementAt(2).displayNumber(line[2]);
                    display.ElementAt(3).displayNumber(line[1]);
                    display.ElementAt(4).displayNumber(line[0]);
                    display.ElementAt(5).isNull();
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 6:
                    display.ElementAt(0).displayNumber(line[5]);
                    display.ElementAt(1).displayNumber(line[4]);
                    display.ElementAt(2).displayNumber(line[3]);
                    display.ElementAt(3).displayNumber(line[2]);
                    display.ElementAt(4).displayNumber(line[1]);
                    display.ElementAt(5).displayNumber(line[0]);
                    display.ElementAt(6).isNull();
                    display.ElementAt(7).isNull();
                    break;
                case 7:
                    display.ElementAt(0).displayNumber(line[6]);
                    display.ElementAt(1).displayNumber(line[5]);
                    display.ElementAt(2).displayNumber(line[4]);
                    display.ElementAt(3).displayNumber(line[3]);
                    display.ElementAt(4).displayNumber(line[2]);
                    display.ElementAt(5).displayNumber(line[1]);
                    display.ElementAt(6).displayNumber(line[0]);
                    display.ElementAt(7).isNull();
                    break;
                case 8:
                    display.ElementAt(0).displayNumber(line[7]);
                    display.ElementAt(1).displayNumber(line[6]);
                    display.ElementAt(2).displayNumber(line[5]);
                    display.ElementAt(3).displayNumber(line[4]);
                    display.ElementAt(4).displayNumber(line[3]);
                    display.ElementAt(5).displayNumber(line[2]);
                    display.ElementAt(6).displayNumber(line[1]);
                    display.ElementAt(7).displayNumber(line[0]);
                    break;

            }
        }

        public void updateRomanDisplay()
        {
            lblRomDisplay.Text = input;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn0.Text);
                updateDisplay();
            
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
           
                ShowInput(btn1.Text);
                updateDisplay();
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn2.Text);
                updateDisplay();
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn3.Text);
                updateDisplay();
            
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn4.Text);
                updateDisplay();
            
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn5.Text);
                updateDisplay();
            
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn6.Text);
                updateDisplay();
            
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn7.Text);
                updateDisplay();
            
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            
                ShowInput(btn8.Text);
                updateDisplay();
            
        }

        private void btn9_Click(object sender, EventArgs e)
        {
           
                ShowInput(btn9.Text);
                updateDisplay();
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
                currentOp = Operator.None;
                input = "";
                total = 0;
                lblRomDisplay.Text = "";
                updateDisplay();
           
            
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                if (isHex == false)
                {
                    if (radDec.Checked == true)
                    {
                        calculate();
                        int v = Convert.ToInt32(total);
                        input = Convert.ToString(v);
                        updateDisplay();
                    }
                    else if (radRom.Checked == true)
                    {
                        calculate();
                        int v = Convert.ToInt32(total);
                        input = RNfromInt(v);
                        updateRomanDisplay();
                    }
                    
                }
                else 
                {
                    calculate();
                    int v = Convert.ToInt32(total);
                    string hex = v.ToString("X");
                    input = hex;
                    updateDisplay();
                }
                    
            }
            catch (Exception ex)
            { 
                //errorinput = error
            }
        }

        private void calculate()
        {
            switch (currentOp)
            {
                case Operator.Add:
                    total += currVal;
                    break;
                case Operator.Minus:
                    total -= currVal;
                    break;
                case Operator.Divide:
                    total /= currVal;
                    break;
                case Operator.Multiply:
                    total *= currVal;
                    break;
                case Operator.None:
                    break;
            }
            currVal = 0;
            currentOp = Operator.None;

           
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            ApplyOp(Operator.Multiply);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            ApplyOp(Operator.Divide);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplyOp(Operator.Add);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            ApplyOp(Operator.Minus);
        }

        private void ApplyOp(Operator op)
        {
            try
            {
                if (currentOp != Operator.None)
                {
                    calculate();
                }
                else
                {
                    if (radDec.Checked == true)
                    {
                        total = Double.Parse(input);
                    }
                    else if (radRom.Checked == true)
                    {
                        total = decFromRN(input);
                    }
                    
                }
                input = "";
                currentOp = op;
            }
            catch (Exception ex)
            {
                showError();
                input = "";
            }
        }

        private void ShowInput(String v)
        {
            try
            {
                if (radDec.Checked == true)
                {
                    input = input + v;
                    currVal = Double.Parse(input);
                }
                else if(radRom.Checked ==true)
                {
                    input = input + v;
                    currVal = decFromRN(input);
                }
                
            }
            catch (Exception exc)
            {
                showError();
            }
            
 
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            if (isHex == false)
            {
                btnHex.BackColor = Color.Red;
                isHex = true;
            }
            else
            {
                btnHex.BackColor = Color.White;
                isHex = false;
            }
            
        }
        private void showError()
        {
            input = "Error";
            updateDisplay();
        }

        private void radDec_CheckedChanged(object sender, EventArgs e)
        {
            currentOp = Operator.None;
            input = "";
            total = 0;
            currVal = 0;

            //deactivate roman buttons
            btnRomI.Enabled = false;
            btnRom5.Enabled = false;
            btnRom10.Enabled = false;
            btnRom50.Enabled = false;
            btnRom100.Enabled = false;
            btnRom500.Enabled = false;
            btnRom1000.Enabled = false;

            //deactivate title
            lblRomDisplay.Visible = false;
            lblRomTitle.Visible = false;

            //activate numeral buttons
            btn0.Enabled = true;
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
        }

        private void radRom_CheckedChanged(object sender, EventArgs e)
        {
            currentOp = Operator.None;
            input = "";
            total = 0;
            currVal = 0;
            lblRomDisplay.Text = "";

            //reactivate roman buttons
            btnRomI.Enabled = true;
            btnRom5.Enabled = true;
            btnRom10.Enabled = true;
            btnRom50.Enabled = true;
            btnRom100.Enabled = true;
            btnRom500.Enabled = true;
            btnRom1000.Enabled = true;

            //activate title
            lblRomDisplay.Visible = true;
            lblRomTitle.Visible = true;

            //deactivate numeral buttons
            btn0.Enabled = false;
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;

        }
        //loc 74 added
        private void btnRomI_Click(object sender, EventArgs e)
        {
            ShowInput(btnRomI.Text);
            updateRomanDisplay();
        }

        private void btnRom5_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom5.Text);
            updateRomanDisplay();
        }

        private void btnRom10_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom10.Text);
            updateRomanDisplay();
        }

        private void btnRom50_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom50.Text);
            updateRomanDisplay();
        }

        private void btnRom100_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom100.Text);
            updateRomanDisplay();
        }

        private void btnRom500_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom500.Text);
            updateRomanDisplay();
        }

        private void btnRom1000_Click(object sender, EventArgs e)
        {
            ShowInput(btnRom1000.Text);
            updateRomanDisplay();
        }

        //Convert Roman Numeral to Decimal Value
        public int decFromRN(string y)
        {
            int[] intVals = y.ToCharArray().Select(x => { return x == 'I' ? 1 : x == 'V' ? 5 : x == 'X' ? 10 : x == 'L' ? 50 : x == 'C' ? 100 : x == 'D' ? 500 : x == 'M' ? 1000 : 0; }).ToArray();
            int z = 0;
            for (int i = 0; i < y.Length; i++)
            {
                int vac = (i + 1 < intVals.Length && intVals[i + 1] > intVals[i]) ? -1 : 1;
                z += vac * intVals[i];
            }
                return z;
        }

        public string RNfromInt(int x)
        {
            if ((x < 0) || (x > 3999))
            {
                lblRomTitle.Text = "Roman(must be between 0 and 3999)";
                return "";
            }
            if (x < 1)
            { 
                return string.Empty; 
            }
            if (x >= 1000)
            {
                return "M" + RNfromInt(x - 1000);
            }
            if (x >= 900)
            {
                return "CM" + RNfromInt(x - 900); 
            }
            if (x >= 500)
            {
                return "D" + RNfromInt(x - 500);
            } 
            if (x >= 400)
            {
                return "CD" + RNfromInt(x - 400);
            } 
            if (x >= 100)
            {
                return "C" + RNfromInt(x - 100);
            } 
            if (x >= 90)
            {
                return "XC" + RNfromInt(x - 90);
            } 
            if (x >= 50)
            {
                return "L" + RNfromInt(x - 50);
            } 
            if (x >= 40)
            {
                return "XL" + RNfromInt(x - 40);
            } 
            if (x >= 10)
            {
                return "X" + RNfromInt(x - 10);
            } 
            if (x >= 9)
            {
                return "IX" + RNfromInt(x - 9);
            } 
            if (x >= 5)
            {
                return "V" + RNfromInt(x - 5);
            }
            if (x >= 4)
            {
                return "IV" + RNfromInt(x - 4);
            } 
            if (x >= 1)
            {
                return "I" + RNfromInt(x - 1);
            }
            return "";
        }
    }
}
