/*
 * FILE         |   Toaster.cs
 * PROJECT      |   IAD Assignmet #2
 * DATE         |   31/03/2015
 * AUTHORS      |   Ben Lorantfy, Grigory Kozyrev
 * DETAILS      |   This is the toaster class, which simulates toaster object.
 *              |   It is able to chage temperature, switch on/off state and read data from the sensor.
 */
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

            //Start Temperature Update thread
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
            //Destroy Temperature Update thread
            t.Abort();
            t.Join();
        }

        //Returns voltage on the sensor
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
                //Wait for one second
                Thread.Sleep(1000);

                //Get a mutex
                toastMutex.WaitOne(1000);

                if (On == false)
                {
                    //If toaster is off, change teperature to be closer to ambient
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
                    //Increase the temperature
                    temp += 1;
                }
                //Set new temperature for the sensor
                temperatureSensor.SetTemperature(temp);

                //Turn off toaster if max heat is reached
                if (temp >= maxHeat)
                {
                    this.TurnOff();
                }

                //Release mutex
                toastMutex.ReleaseMutex();
            }
        }
    }
}
