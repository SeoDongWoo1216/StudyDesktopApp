using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210316_197_IoTSensorMonApp
{
    internal class SensorData // internal은 여기 어셈블리 내에서만 쓰겠다는 뜻
    {
        public DateTime Current { get; set; }  // 현재 시간 값
        public int Value { get; set; }         // 센서 값
        public bool SimulFlag { get; set; }    // 시뮬레이션 여부(T/F)

        // 생성자 생성(빈 곳에서 알트엔터로 생성가능)
        public SensorData(DateTime current, int value, bool simulFlag)
        {
            Current = current;
            Value = value;
            SimulFlag = simulFlag;
        }

        

    }
}
