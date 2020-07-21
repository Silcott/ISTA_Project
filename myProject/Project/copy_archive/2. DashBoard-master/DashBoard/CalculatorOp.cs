using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard
{
    class CalculatorOp
    {
        decimal currentValue;
        decimal operand1;
        decimal operand2;
        string op; 

        public decimal CurrentValue
        {
            set { currentValue = value; }
            get { return currentValue; }
        }
        public decimal Operand1
        {
            set { operand1 = value; }
            get { return operand1; }
        }
        public decimal Operand2
        {
            set { operand2 = value; }
            get { return operand2; }
        }

        public string Op
        {
            set { op = value; }
            get { return op; }
        }

        public decimal Add()
        {
            return Operand1 + Operand2;
        }
        public decimal Subtract()
        {
            return Operand1 - Operand2;
        }
        public decimal Multiply()
        {
            return Operand1 * Operand2;
        }
        public decimal Divide()
        {
            if (Operand2 == 0)
            {
                return 0;
            }
            else
            {
                return Operand1 / Operand2;
            }
        }
    }
}
