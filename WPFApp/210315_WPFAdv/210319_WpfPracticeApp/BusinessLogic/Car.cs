using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _210319_WpfPracticeApp.BusinessLogic
{
    public class Car : Notifier
    {
        // private double speed { get set}  // 아래와 똑같음
        private double speed;
        public double Speed 
        {
            get { return speed; }
            set
            {
                if (value > 350)
                {
                    speed = 350;
                }
                else
                {
                    speed = value;
                }
                OnPropertyChanged("Speed"); // 속성값이 변경된 것을 알려줌(프로그램)
            }
        }

        private Color maincolor;
        public Color MainColor 
        {
            get { return maincolor; } 
            set
            {
                maincolor = value;
                OnPropertyChanged("MainColor");
            }
        }
        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDriveLicense { get; set; }

    }
}
