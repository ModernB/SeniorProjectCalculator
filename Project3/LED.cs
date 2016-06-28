using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project3 
{
    class LED 
    {
        int xVal= 0;
        int yVal= 0;
        Bar b1, b2, b3, b4, b5, b6, b7;
        public LinkedList<Bar> bars = new LinkedList<Bar>();
        public LED()
        {
            buildChar();
        }

        public LED(int x, int y)
        {
            xVal = x;
            yVal = y;
            buildChar();
        }


        public void buildChar()
        {
            b1 = new Bar(xVal + 10, yVal);
            bars.AddLast(b1);
            b2 = new Bar(xVal, yVal + 10);
            bars.AddLast(b2);
            b2.makeVertical();
            b3 = new Bar(xVal + 50, yVal + 10);
            b3.makeVertical();
            bars.AddLast(b3);
            b4 = new Bar(xVal + 10, yVal + 50);
            bars.AddLast(b4);
            b5 = new Bar(xVal, yVal + 60);
            b5.makeVertical();
            bars.AddLast(b5);
            b6 = new Bar(xVal + 50, yVal + 60);
            b6.makeVertical();
            bars.AddLast(b6);
            b7 = new Bar(xVal + 10, yVal + 100);
            bars.AddLast(b7);
        }

        public void displayNumber( Char ch)
        {
            char val = ch;
            if (val == '0')
            {
                this.isZero();
            }
            else if (val == '1')
            {
                this.isOne();
            }
            else if (val == '2')
            {
                this.isTwo();
            }
            else if (val == '3')
            {
                this.isThree();
            }
            else if (val == '4')
            {
                this.isFour();
            }
            else if (val == '5')
            {
                this.isFive();
            }
            else if (val == '6')
            {
                this.isSix();
            }
            else if (val == '7')
            {
                this.isSeven();
            }
            else if (val == '8')
            {
                this.isEight();
            }
            else if (val == '9')
            {
                this.isNine();
            }
            else if (val == 'A')
            {
                this.isA();
            }
            else if (val == 'B')
            {
                this.isB();
            }
            else if (val == 'C')
            {
                this.isC();
            }
            else if (val == 'D')
            {
                this.isD();
            }
            else if (val == 'E')
            {
                this.isE();
            }
            else if (val == 'F')
            {
                this.isF();
            }
            else if (val == 'r')
            {
                this.isR();
            }
            else if (val == 'o')
            {
                this.isO();
            }

        }

        public void setPointX(int x)
        {
            xVal = x;
        }

        public void setPointY(int y)
        {
            yVal = y;
        }

        public void isZero()
        {
            b1.activate();
            b2.activate();
            b3.activate();
            b4.deactivate();
            b5.activate();
            b6.activate();
            b7.activate();
        }

        public void isOne()
        {
            b1.deactivate();
            b2.deactivate();
            b3.activate();
            b4.deactivate();
            b5.deactivate();
            b6.activate();
            b7.deactivate();
        }

        public void isTwo()
        {
            b1.activate();
            b2.deactivate();
            b3.activate();
            b4.activate();
            b5.activate();
            b6.deactivate();
            b7.activate();
        }

        public void isThree()
        {
            b1.activate();
            b2.deactivate();
            b3.activate();
            b4.activate();
            b5.deactivate();
            b6.activate();
            b7.activate();
        }

        public void isFour()
        {
            b1.deactivate();
            b2.activate();
            b3.activate();
            b4.activate();
            b5.deactivate();
            b6.activate();
            b7.deactivate();
        }

        public void isFive()
        {
            b1.activate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.deactivate();
            b6.activate();
            b7.activate();
        }

        public void isSix()
        {
            b1.activate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.activate();
        }

        public void isSeven()
        {
            b1.activate();
            b2.deactivate();
            b3.activate();
            b4.deactivate();
            b5.deactivate();
            b6.activate();
            b7.deactivate();
        }

        public void isEight()
        {
            b1.activate();
            b2.activate();
            b3.activate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.activate();
        }

        public void isNine()
        {
            b1.activate();
            b2.activate();
            b3.activate();
            b4.activate();
            b5.deactivate();
            b6.activate();
            b7.activate();
        }

        public void isA()
        {
            b1.activate();
            b2.activate();
            b3.activate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.deactivate();
        }

        public void isB()
        {
            b1.deactivate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.activate();
        }

        public void isC()
        {
            b1.activate();
            b2.activate();
            b3.deactivate();
            b4.deactivate();
            b5.activate();
            b6.deactivate();
            b7.activate();
        }

        public void isD()
        {
            b1.deactivate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.activate();
        }

        public void isE()
        {
            b1.activate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.deactivate();
            b7.activate();
        }

        public void isF()
        {
            b1.activate();
            b2.activate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.deactivate();
            b7.deactivate();
        }

        public void isR()
        {
            b1.deactivate();
            b2.deactivate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.deactivate();
            b7.deactivate();
        }

        public void isO()
        {
            b1.deactivate();
            b2.deactivate();
            b3.deactivate();
            b4.activate();
            b5.activate();
            b6.activate();
            b7.activate();
        }



        public void isNull()
        {
            b1.deactivate();
            b2.deactivate();
            b3.deactivate();
            b4.deactivate();
            b5.deactivate();
            b6.deactivate();
            b7.deactivate();
        }
        public void isNegative()
        {
            b1.deactivate();
            b2.deactivate();
            b3.deactivate();
            b4.activate();
            b5.deactivate();
            b6.deactivate();
            b7.deactivate();
        }
    }
}
