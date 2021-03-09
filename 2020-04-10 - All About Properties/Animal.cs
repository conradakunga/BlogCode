using System;
using System.Drawing;

namespace PropertiesConsole
{
    public class Animal
    {
        public byte NumberOfLegs { get; }
        public string Name { get; set; }
        public byte NumberOfOffpring { get; private set; } = 0;
        private Color m_Color;
        public Color Colour
        {
            get
            {
                return m_Color;
            }
            set
            {
                if (value == Color.Transparent)
                    throw new ApplicationException("Animal cannot be transparent");
                else
                    m_Color = value;
            }
        }
        public Animal(byte numberOfLegs)
        {
            NumberOfLegs = numberOfLegs;
        }
        public void Reproduce() => NumberOfOffpring++;
    }
}

