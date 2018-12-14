using System;
using System.Windows;
using System.Windows.Controls;

namespace Inn
{
     /// <summary>
    /// </summary>
    public class Program
    {
        public static void Main() 
        {
            InnHost h = new InnHost();
            h.Start();
        }
    }
}

