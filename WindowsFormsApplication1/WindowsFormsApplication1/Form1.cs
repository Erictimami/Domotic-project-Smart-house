using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MccDaq;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private MccDaq.MccBoard DaqBoard;
        public Form1()
        {
            InitializeComponent();
            MccDaq.ErrorInfo ULStat = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.PrintAll, MccDaq.ErrorHandling.DontStop);
            DaqBoard = new MccDaq.MccBoard(0);
            ULStat = DaqBoard.DConfigPort(MccDaq.DigitalPortType.FirstPortA, MccDaq.DigitalPortDirection.DigitalOut);
            ULStat = DaqBoard.DOut(MccDaq.DigitalPortType.FirstPortA, 0);
            ULStat = DaqBoard.DConfigPort(MccDaq.DigitalPortType.FirstPortB, MccDaq.DigitalPortDirection.DigitalIn);

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MccDaq.ErrorInfo ULStat;
            ULStat = DaqBoard.FlashLED();
           // Debug.Print(ULStat.Message.ToString());
           
        }

        private void Aenter_Click(object sender, EventArgs e)
        {
            //Ain une seule lecture

            MccDaq.ErrorInfo ULStat;
            float ch0;
            float ch1;
            float ch2;
            float ch3;
                     // double HighResEngUnits;
            
            System.UInt16 DataValue0;
            System.UInt16 DataValue1;
            System.UInt16 DataValue2;
            System.UInt16 DataValue3;
                             // System.UInt32 DataValue32;
            int chan0;
            int chan1;
            int chan2;
            int chan3;
                             // int Options = 0;
            MccDaq.Range Range;
            Range = Range.Bip10Volts;     //  select Bip10Volts (member of Range enumeration)
            chan0 = 0;
            chan1 = 1; //  set input channel
            chan2 = 2;
            chan3 = 3;
            ULStat = DaqBoard.AIn(chan0, Range, out DataValue0); //acquisition
            ULStat = DaqBoard.AIn(chan1, Range, out DataValue1); //acquisition
            ULStat = DaqBoard.AIn(chan2, Range, out DataValue2); //acquisition
            ULStat = DaqBoard.AIn(chan3, Range, out DataValue3); //acquisition
            ULStat = DaqBoard.ToEngUnits(Range, DataValue0, out ch0); //conversion
            ULStat = DaqBoard.ToEngUnits(Range, DataValue1, out ch1); //conversion
            ULStat = DaqBoard.ToEngUnits(Range, DataValue2, out ch2); //conversion
            ULStat = DaqBoard.ToEngUnits(Range, DataValue3, out ch3); //conversion
                            //  ULStat = DaqBoard.AIn32(Chan, Range, out DataValue32, Options);
                            //  ULStat = DaqBoard.ToEngUnits32(Range, DataValue32, out HighResEngUnits);
                            // Debug.Print(EngUnits.ToString());
                            //Debug.Print(DataValue.ToString());
            textBox8.Text = ch0.ToString();
            textBox9.Text = ch1.ToString();
            textBox10.Text = ch2.ToString();
            textBox11.Text = ch3.ToString();
                            //textBox2.Text = HighResEngUnits.ToString();
            
                                //Ainscan plusieurs lecture foreground
                                //  Parameters:
                                //    LowChan    :the first channel of the scan
                                //    HighChan   :the last channel of the scan
                                //    Count      :the total number of A/D samples to collect
                                //    Rate       :sample rate
                                //    Range      :the range for the board
                                //    MemHandle  :Handle for Windows buffer to store data in
                                //    Options    :data collection options
                                // MccDaq.Range Range;
                                //MccDaq.ScanOptions Options;
                                //int Rate;
                                //int Count;
                                //int LowChan;
                                // const int FirstPoint = 0;   //  set first element in buffer to transfer to array
                                // private ushort[] ADData = new ushort[NumPoints]; //  dimension an array to hold the input values
                                //private int MemHandle = 0;	//  define a variable to contain the handle for memory allocated 
                                //LowChan = 0; //  first channel to acquire
                                //HighChan = 3;
                                //Count = 64;	//  total number of data points to collect
                                //Rate = 100;			//  per channel sampling rate ((samples per second) per channel)
                                //Options = MccDaq.ScanOptions.ConvertData;
                                //Range = MccDaq.Range.Bip10Volts; // set the range
                                //ULStat = DaqBoard.AInScan(LowChan, HighChan, Count, ref Rate, Range, MemHandle, Options);
                                //ULStat = MccDaq.MccService.WinBufToArray(MemHandle, out ADData[0], FirstPoint, Count);
                                //textBox1.Text = ADData[0].ToString();
                                //textBox2.Text = ADData[1].ToString();
                                //textBox3.Text = ADData[2].ToString();
                                //textBox4.Text = ADData[3].ToString();
        }

        private void Denter_Click(object sender, EventArgs e)
        {
            //Din


            MccDaq.ErrorInfo ULStat;
            short D1;

            ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortB, out D1);
            textBox1.Text = D1.ToString();

            //Convert from any base to any base in C#*
            //texBox2.text = Convert.ToString(Convert.ToInt32(D1, short) , SByte); dead


            //the integer and convert it to a binary string
            textBox3.Text = Convert.ToString(D1, 2);

            // string to Binary 
            byte[] arr = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
            Debug.Print(arr.ToString());
            textBox4.Text = arr.ToString(); //dead

            //  parse D1 into bit values to indicate on/off status
            for (int i = 7; i > 0; --i)
            {
                if ((D1 & (1 << i)) != 0)
                    textBox7.Text = textBox7.Text + "1";
                else
                    textBox7.Text = textBox7.Text + "0";
            }

            textBox5.Text = textBox7.Text[1].ToString();
            textBox6.Text = textBox7.Text.Substring(1, 2);
        }

        private void Dexit_Click(object sender, EventArgs e)
        {
            // sortie digitale

            MccDaq.ErrorInfo ULStat;
            int pinToChange = 1; // 1 en sortie (pin 22)
            ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, pinToChange, MccDaq.DigitalLogicState.High); // mettre sortie à l'état haut
            //textBox6.Text = pinToChange.ToString();

            int outChange = 2; // 2 en sortie (pin 23)
            ULStat = DaqBoard.DBitOut(MccDaq.DigitalPortType.FirstPortA, outChange, MccDaq.DigitalLogicState.Low);
        }



    }
}
