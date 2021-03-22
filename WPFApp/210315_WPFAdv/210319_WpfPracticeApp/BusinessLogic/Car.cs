using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _210319_WpfPracticeApp.BusinessLogic
{
    public class Car
    {
        public double Speed { get; set; }
        public Color MainColor { get; set; }

        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDriveLicense { get; set; }

    }
}
