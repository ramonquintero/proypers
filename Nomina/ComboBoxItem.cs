﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboboxItem(string txt, int val)
        {
            Text = txt;
            Value = (Object) val;
        }

        public override string ToString()
        {
            return Text;
        }

        public int GetValue()
        {
            return (int)Value;
        }
    }
}
