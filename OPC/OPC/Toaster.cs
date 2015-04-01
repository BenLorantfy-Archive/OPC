using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OPC
{
    public class Toaster
    {
        private bool On;

        private int temp;
        private int ambientTemp;
        private int maxHeat;

        private Sensor temperatureSensor;

        private Mutex toastMutex;

        private Thread t;

        public Toaster(int initialTemp, int initialAmbientTemp, int initialMaxHeat)
        {
            On = false;
            temp = initialTemp;
            ambientTemp = initialAmbientTemp;
            maxHeat = initialMaxHeat;
            temperatureSensor = new Sensor(temp);
            toastMutex = new Mutex();

            t = new Thread(new ThreadStart(this.UpdateTemperature));
            t.Start();
        }

        public void TurnOn()
        {
            if (On == false)
            {
                On = true;
            }
        }

        public void TurnOff()
        {
            if (On == true)
            {
                On = false;
            }
        }

        public void SetMaxHeat(int newMaxHeat)
        {
            maxHeat = newMaxHeat;
        }

        public void Destroy()
        {
            t.Abort();
            t.Join();
        }

        public double SensorVoltage()
        {
            double voltage = 0;

            toastMutex.WaitOne(1000);
            voltage = temperatureSensor.ReadVoltage();
            toastMutex.ReleaseMutex();

            return voltage;
        }

        private void UpdateTemperature()
        {
            while (true)
            {
                Thread.Sleep(1000);

                toastMutex.WaitOne(1000);

                if (On == false)
                {
                    if (temp < ambientTemp)
                    {
                        temp += 1;
                    }
                    else if (temp > ambientTemp)
                    {
                        temp -= 1;
                    }
                }
                else
                {
                    temp += 1;
                }
                temperatureSensor.SetTemperature(temp);

                if (temp >= maxHeat)
                {
                    this.TurnOff();
                }

                toastMutex.ReleaseMutex();
            }
        }
    }
}
