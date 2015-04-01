/*
 * FILE         |   Sensor.cs
 * PROJECT      |   IAD Assignmet #2
 * DATE         |   31/03/2015
 * AUTHORS      |   Ben Lorantfy, Grigory Kozyrev
 * DETAILS      |   This is the temperature sensor for the toaster. It has a body temperature parameter,
 *              |   and is able to return voltage, which is calculated with specific formula,
 *              |   depending on current temperature.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC
{
    class Sensor
    {
        private int tempearture;
        private List<double> temperatureCoefficient;

        public Sensor(int initialTemp)
        {
            tempearture = initialTemp;

            //Set polynomal coefficients for convert function
            temperatureCoefficient = new List<double>();
            temperatureCoefficient.Add(5.0381187815 * Math.Pow(10, -2));
            temperatureCoefficient.Add(3.0475836930 * Math.Pow(10, -5));
            temperatureCoefficient.Add(8.5681065720 * Math.Pow(10, -8) * -1);
            temperatureCoefficient.Add(1.3228195295 * Math.Pow(10, -10));
            temperatureCoefficient.Add(1.7052958337 * Math.Pow(10, -13) * -1);
            temperatureCoefficient.Add(2.0948090697 * Math.Pow(10, -16));
            temperatureCoefficient.Add(1.2538395336 * Math.Pow(10, -19) * -1);
            temperatureCoefficient.Add(1.5631725697 * Math.Pow(10, -23));
        }

        public double ReadVoltage()
        {
            return TempToVolt(tempearture);
        }

        public bool SetTemperature(int newTemperature)
        {
            bool retVal = false;

            //Temperature must be from 0 to 760 (it is a sensor characterstic)
            if ((newTemperature > 0) && (newTemperature < 760))
            {
                tempearture = newTemperature;
                retVal = true;
            }

            return retVal;
        }

        //Function calculate voltage in milivolts from temperature in Celsius
        private double TempToVolt(int temp)
        {
            double voltage = 0;


            for (int i = 0; i < temperatureCoefficient.Count; i++)
            {
                voltage += temperatureCoefficient[i] * Math.Pow(temp, i + 1);
            }

            return voltage;
        }
    }
}
