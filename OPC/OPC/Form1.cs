using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kepware.ClientAce.OpcDaClient;

namespace OPC
{
    public partial class Form1 : Form
    {
        // Simulation Info
        private List<double> voltageCoefficient;
        private Toaster coolToaster;

        //Initilize the server object
        DaServerMgt server;
        public Form1()
        {
            // Initialize the form components
            InitializeComponent();

            //Add voltage coefficients to the list
            InitializeVoltageCoeficient();

            //Initial values: toaster temperature, ambient temperature, max heat.
            coolToaster = new Toaster(16, 20, 55);

            //Update termometer values
            UpdateTermometer((int)numMaxTemp.Value);
        }

        private void InitializeVoltageCoeficient()
        {
            voltageCoefficient = new List<double>();
            voltageCoefficient.Add(1.978425 * Math.Pow(10, 1));
            voltageCoefficient.Add(2.001204 * Math.Pow(10, -1) * -1);
            voltageCoefficient.Add(1.036969 * Math.Pow(10, -2));
            voltageCoefficient.Add(2.549687 * Math.Pow(10, -4) * -1);
            voltageCoefficient.Add(3.585153 * Math.Pow(10, -6));
            voltageCoefficient.Add(5.344285 * Math.Pow(10, -8) * -1);
            voltageCoefficient.Add(5.099890 * Math.Pow(10, -10));
            voltageCoefficient.Add(0 * Math.Pow(10, -5) * -1);
        }

        private int VoltToTemp(double volt)
        {
            double temp = 0;

            for (int i = 0; i < voltageCoefficient.Count; i++)
            {
                temp += voltageCoefficient[i] * Math.Pow(volt, i + 1);
            }

            return (int)(temp + 1);
        }

        private void maxTempNumeric_ValueChanged(object sender, EventArgs e)
        {
            UpdateTermometer((int)numMaxTemp.Value);
        }

        private void UpdateTermometer(int maxValue)
        {
            lblMidTemp.Text = ((int)(maxValue / 2)).ToString();

            if (termometer1.Value > maxValue)
            {
                termometer1.Value = maxValue;
            }
            termometer1.Maximum = maxValue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // On fomr load set the disconnect buttone to disabled and the status of the server to disconnected.
            button2.Enabled = false;
            lblConnect.Text = "DISCONNECTED";
            grpSimulation.Enabled = false;
            btnOff.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // On the button click initialize the new server object
            server = new DaServerMgt();

            // Initilize the connection info class
            ConnectInfo connectInfo = new ConnectInfo();
            bool connectFailed = false;

            // Initialize the connect info object data
            connectInfo.LocalId = "en";
            connectInfo.KeepAliveTime = 5000;   
            connectInfo.RetryAfterConnectionError = true;
            
            // Try the server connection
            try
            {
                server.Connect(txtAddress.Text, 0, ref connectInfo, out connectFailed);
            }
            catch (Exception ex)
            {
                connectFailed = true;
                MessageBox.Show("Failed to connect");
                Console.WriteLine(ex);
            }
            
            // Test to make sure the connection succeeded and if it did set the state, disable
            // the connection button and enable the disconnect button
            // also disable the simulation group if not connected
            if (!connectFailed)
            {
                lblConnect.Text = server.ServerState.ToString();
                button1.Enabled = false;
                button2.Enabled = true;
                grpSimulation.Enabled = true;

                //Start the timer
                timer1.Start();
            }

        }

        /*
         * FUNCTION : Send
         *
         * DESCRIPTION : Sends data to OPC server device
         *
         * PARAMETERS : string data : data to send
         * 
         * RETURNS : void
         */
        private void Send(string data)
        {
            // Declare variables
            ItemIdentifier[] itemIdentifiers = new ItemIdentifier[1];
            itemIdentifiers[0] = new ItemIdentifier();
            itemIdentifiers[0].ItemName = "modbusChannel.modbusDevice.modbusTag";

            ItemValue[] itemValues = new ItemValue[1];
            itemValues[0] = new ItemValue();
            itemValues[0].Value = data;

            ReturnCode returnCode = new ReturnCode();
            try
            { // Call Write API method
                returnCode = server.Write(ref itemIdentifiers, itemValues);
                // Check item results
                if (returnCode != ReturnCode.SUCCEEDED)
                {
                    foreach (ItemIdentifier item in itemIdentifiers)
                    {
                        if (!item.ResultID.Succeeded)
                        {
                            Console.WriteLine("Write failed for item: {0}",
                            item.ItemName);
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Write exception. Reason: {0}", ex); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Test to see of the server is connected and if so disconnect
            //display the new status and reste the connect and disconnect buttons
            if (server.IsConnected)
            {
                server.Disconnect();
            }
               
            lblConnect.Text = server.ServerState.ToString();
            button2.Enabled = false;
            button1.Enabled = true;
            grpSimulation.Enabled = false;
            timer1.Stop();
            termometer1.Value = 0;
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            coolToaster.TurnOn();
            btnOff.Enabled = true;
            btnOn.Enabled = false;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            coolToaster.TurnOff();
            btnOff.Enabled = false;
            btnOn.Enabled = true; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Use it to get voltage from the sensor
            double voltage = coolToaster.SensorVoltage();

            try
            {
                if (VoltToTemp(coolToaster.SensorVoltage()) >= termometer1.Maximum)
                {
                    termometer1.Value = termometer1.Maximum;
                }
                else
                {
                    termometer1.Value = VoltToTemp(coolToaster.SensorVoltage());
                }
                Send(VoltToTemp(coolToaster.SensorVoltage()).ToString());
            }
            catch (Exception ex)
            { }
        }

        private void cookLevelBar_Scroll(object sender, EventArgs e)
        {
            coolToaster.SetMaxHeat(45 + cookLevelBar.Value * 10);
        }

        private void numMaxTemp_ValueChanged(object sender, EventArgs e)
        {
            UpdateTermometer((int)numMaxTemp.Value);
        }
    }
}
