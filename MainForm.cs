using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Comport
{
    public partial class MainForm : Form
    {
        SerialPort m_COM;
        Boolean threadrunning = true;
        static int Output_line_count = 0;
        static int sent_line_count = 0;
        const int Max_line = 50;   
     
        public MainForm()
        {
            String[] sPort;

            InitializeComponent();

            IDC_Input.Text = "";

            m_COM = new SerialPort();


            sPort = SerialPort.GetPortNames();
            foreach (String tmp in sPort)
                IDC_PortName.Items.Add(tmp);
            IDC_PortName.SelectedIndex = 0;
            IDC_BaudRate.SelectedIndex = 0;
            IDC_type.SelectedIndex = 0;
            IDC_OutputDisplayMode.SelectedIndex = 0;
            IDC_InputDisplayMode.SelectedIndex = 0;

        }

        private void IDC_Send_Click(object sender, EventArgs e)
        {
          
            // search device
            if ((IDC_Connect.Text == "Disconnect") && (IDC_Input.Text != ""))
            {
                if (IDC_type.Text == "Hex")
                {
                    SendPacket(IDC_Input.Text);
                }
                else if (IDC_type.Text == "ASCII")
                {
                    SendPacket(convertAsciiTextToHex(IDC_Input.Text));
                }
            }
            else
            {
                //PrintSent("Fail");
            }
        }

        private Boolean Convert2Byte(String sInput, out Byte[] bOutput)
        {
            Char[] caTemp;
            Byte[] baTemp;
            int i, j;


            caTemp = sInput.ToCharArray();

            baTemp = new Byte[caTemp.Length];
            bOutput = null;

            for (i = 0, j = 0; i < caTemp.Length; i++)
            {
                if ((caTemp[i] >= '0') & (caTemp[i] <= '9'))
                    baTemp[j++] = (Byte)(caTemp[i] - '0');
                else if ((caTemp[i] >= 'A') & (caTemp[i] <= 'F'))
                    baTemp[j++] = (Byte)(caTemp[i] - 'A' + 10);
                else if ((caTemp[i] >= 'a') & (caTemp[i] <= 'f'))
                    baTemp[j++] = (Byte)(caTemp[i] - 'a' + 10);
            }
            if ((j % 2) == 1)            
                j--;
            if(j == 0)
                return false;

            bOutput = new Byte[j / 2];
            for (i = 0; i < j / 2; i++)
                bOutput[i] = (Byte)((baTemp[i * 2] << 4) | (baTemp[i * 2 + 1]));

            return true;
        }

        private Boolean SearchForDevice(String portName)
        {
            // set serial port
 //           m_COM.BaudRate = 9600;
            m_COM.BaudRate = Convert.ToInt32(IDC_BaudRate.Text);
            m_COM.DataBits = 8;
            m_COM.Handshake = Handshake.None;
            m_COM.Parity = Parity.None;
            m_COM.StopBits = StopBits.One;
      //      m_COM.StopBits = StopBits.Two;

            m_COM.PortName = portName;
            try { m_COM.Open(); return true; }
            //                catch { continue; }
            catch {
                IDC_Output.Text = "Fail to open port";
                return false; }
        }

        private String convertAsciiTextToHex(String i_asciiText)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < i_asciiText.Length; i++)
            {
                sBuffer.Append(Convert.ToInt32(i_asciiText[i]).ToString("x"));
            }
            return sBuffer.ToString().ToUpper();
        }

        private void SendPacket(String data)
        {
            Byte[] baData;

            if (Convert2Byte(data, out baData))
            {
                SendPacket(baData);
                PrintSent(baData);
            }
        }

        private void SendPacket(Byte[] data)
        {
            // check it is open or not
            if (!m_COM.IsOpen)
                return;

            m_COM.Write(data, 0, data.Length);
        }

        // Create a PrintLine Delegate used in multi thread 
        private delegate void SendPacketDelegate(Byte[] Msg);

        // A similar method with PrintLine used in cross thread
        private void SafeSendPacket(Byte[] Msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SendPacketDelegate(SendPacket), Msg);
            }
        }
        private void PrintSent(Byte[] Msg)
        {
            if (IDC_InputDisplayMode.Text == "BOTH")
            {
                char[] cMsg = ASCIIEncoding.ASCII.GetString(Msg).ToCharArray();
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                int remaining = Msg.Length;
                int index = 0;
                IDC_Sent.Text += timestring + "\r\n"; sent_line_count++;
                
                while (remaining > 0)
                {
                    if (remaining > 16)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            IDC_Sent.Text += Msg[i + index].ToString("X2");
                            IDC_Sent.Text += "|";
                        }
                        IDC_Sent.Text += "\r\n"; sent_line_count++;
                        for (int i = 0; i < 16; i++)
                        {
                            if (((int)cMsg[i + index] > 32) && (int)cMsg[i + index] < 127)
                                IDC_Sent.Text += cMsg[i + index];
                            else
                                IDC_Sent.Text += " ";
                            IDC_Sent.Text += " |";
                        }
                        IDC_Sent.Text += "\r\n"; sent_line_count++;
                        index += 16;
                        remaining -= 16;
                    }
                    else
                    {
                        for (int i = 0; i < remaining; i++)
                        {
                            IDC_Sent.Text += Msg[i + index].ToString("X2");
                            IDC_Sent.Text += "|";
                        }
                        IDC_Sent.Text += "\r\n"; sent_line_count++;
                        for (int i = 0; i < remaining; i++)
                        {
                            if (((int)cMsg[i + index] > 32) && (int)cMsg[i + index] < 127)
                                IDC_Sent.Text += cMsg[i+ index];
                            else
                                IDC_Sent.Text += " ";
                            IDC_Sent.Text += " |";
                        }
                        IDC_Sent.Text += "\r\n"; sent_line_count++;
                        remaining = 0;
                    }
                }
                //IDC_Sent.Text += "\r\n";

                IDC_Sent.SelectionStart = IDC_Sent.Text.Length;
                IDC_Sent.ScrollToCaret();
            }
            else if (IDC_InputDisplayMode.Text == "ASCII")
            {
                char[] cMsg = ASCIIEncoding.ASCII.GetString(Msg).ToCharArray();
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Sent.Text += timestring + "ASCII  \r\n"; sent_line_count++;
                for (int i = 0; i < Msg.Length; i++)
                {
                    if (((int)cMsg[i] > 32) && (int)cMsg[i] < 127)
                        IDC_Sent.Text += cMsg[i];
                    else
                        IDC_Sent.Text += " ";
                }
                IDC_Sent.Text += "\r\n"; sent_line_count++;
                IDC_Sent.SelectionStart = IDC_Sent.Text.Length;
                IDC_Sent.ScrollToCaret();
            }
            else if (IDC_InputDisplayMode.Text == "HEX")
            {
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Sent.Text += timestring + "HEX    \r\n"; sent_line_count++;
                for (int i = 0; i < Msg.Length; i++)
                {
                    IDC_Sent.Text += Msg[i].ToString("X2");
                    //IDC_Sent.Text += "|";
                }
                IDC_Sent.Text += "\r\n"; sent_line_count++;

                IDC_Sent.SelectionStart = IDC_Sent.Text.Length;
                IDC_Sent.ScrollToCaret();
            }
            else if (IDC_InputDisplayMode.Text == "NONE")
            {
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Sent.Text += timestring + "SENT    \r\n"; sent_line_count++;
                IDC_Sent.SelectionStart = IDC_Sent.Text.Length;
                IDC_Sent.ScrollToCaret();
            }
            if (sent_line_count > Max_line)
            {
                int i;
                i = sent_line_count - Max_line;
                while (i > 0)
                {
                    i--;
                    sent_line_count--;
                    IDC_Sent.Text = IDC_Sent.Text.Remove(0, IDC_Sent.Text.IndexOf("\r\n") + 2);
                    if (IDC_Sent.Text.Substring(0, 2) == "\r\n")
                        IDC_Sent.Text = IDC_Sent.Text.Remove(0, 2);
                }
                IDC_Sent.SelectionStart = IDC_Sent.Text.Length;
                IDC_Sent.ScrollToCaret();
            }
            
        }
        private void RecePacket()
        {
            int iTemp;
            int iLen;
            Byte[] data;
            Byte[] Displaydata;
            iLen = 0;
            data = new Byte[5000];

            if (m_COM.IsOpen == true)
            {
                while ((m_COM.BytesToRead > 0) && (iLen < 5000))
                {
                    iTemp = m_COM.ReadByte();
                    data[iLen++] = (byte)iTemp;
                    Thread.Sleep(10);
                }

                if (iLen > 0)
                {
                    Displaydata = new Byte[iLen];
                    for (int i = 0; i < iLen; i++)
                        Displaydata[i] = data[i];
                    
                    SafePrintOutput(Displaydata);
                    if(IDC_Loop.Checked == true)
                        SafeSendPacket(Displaydata);
                }
            }            
        }

        private void ReceiveData()
        {
            while (IDC_Connect.Text == "Disconnect")
            {
                RecePacket();
                if (threadrunning == false)
                    break;
            }
            
        }

        private void PrintOutput(Byte[] Msg)
        {
            if (IDC_OutputDisplayMode.Text == "BOTH")
            {
                char[] cMsg = ASCIIEncoding.ASCII.GetString(Msg).ToCharArray();
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                int remaining = Msg.Length;
                int index = 0;
                IDC_Output.Text += timestring + "\r\n"; Output_line_count++;
                while (remaining > 0)
                {
                    if (remaining > 16)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            IDC_Output.Text += Msg[i + index].ToString("X2");
                            IDC_Output.Text += "|";
                        }
                        IDC_Output.Text += "\r\n"; Output_line_count++;
                        for (int i = 0; i < 16; i++)
                        {
                            if (((int)cMsg[i + index] > 32) && (int)cMsg[i + index] < 127)
                                IDC_Output.Text += cMsg[i + index];
                            else
                                IDC_Output.Text += " ";
                            IDC_Output.Text += " |";
                        }
                        IDC_Output.Text += "\r\n"; Output_line_count++;
                        index += 16;
                        remaining -= 16;
                    }
                    else
                    {
                        for (int i = 0; i < remaining; i++)
                        {
                            IDC_Output.Text += Msg[i + index].ToString("X2");
                            IDC_Output.Text += "|";
                        }
                        IDC_Output.Text += "\r\n"; Output_line_count++;
                        for (int i = 0; i < remaining; i++)
                        {
                            if (((int)cMsg[i + index] > 32) && (int)cMsg[i + index] < 127)
                                IDC_Output.Text += cMsg[i + index];
                            else
                                IDC_Output.Text += " ";
                            IDC_Output.Text += " |";
                        }
                        IDC_Output.Text += "\r\n"; Output_line_count++;
                        remaining = 0;
                    }
                }
                //IDC_Output.Text += "\r\n";

                IDC_Output.SelectionStart = IDC_Output.Text.Length;
                IDC_Output.ScrollToCaret();
            }
            else if (IDC_OutputDisplayMode.Text == "ASCII")
            {
                char[] cMsg = ASCIIEncoding.ASCII.GetString(Msg).ToCharArray();
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Output.Text += timestring + "ASCII  \r\n"; Output_line_count++;
                for (int i = 0; i < Msg.Length; i++)
                {
                    if(((int)cMsg[i] > 32) && (int)cMsg[i] < 127)
                    IDC_Output.Text += cMsg[i];
                    else
                    IDC_Output.Text += " ";
                }
                IDC_Output.Text += "\r\n"; Output_line_count++;
                IDC_Output.SelectionStart = IDC_Output.Text.Length;
                IDC_Output.ScrollToCaret();
            }
            else if (IDC_OutputDisplayMode.Text == "HEX")
            {
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Output.Text += timestring + "HEX    \r\n"; Output_line_count++;
                for (int i = 0; i < Msg.Length; i++)
                {
                    IDC_Output.Text += Msg[i].ToString("X2");
                    //IDC_Output.Text += "|";
                }
                IDC_Output.Text += "\r\n"; Output_line_count++;

                IDC_Output.SelectionStart = IDC_Output.Text.Length;
                IDC_Output.ScrollToCaret();
            }
            else if (IDC_OutputDisplayMode.Text == "NONE")
            {
                string timestring = DateTime.Now.ToString("HH:mm:ss ");
                IDC_Output.Text += timestring + "received    \r\n"; Output_line_count++;
                IDC_Output.SelectionStart = IDC_Output.Text.Length;
                IDC_Output.ScrollToCaret();
            }
            if (Output_line_count > Max_line)
            {
                int i;
                i = Output_line_count - Max_line;
                while (i > 0)
                {
                    i--;
                    Output_line_count--;
                    IDC_Output.Text = IDC_Output.Text.Remove(0, IDC_Output.Text.IndexOf("\r\n") + 2);
                    if (IDC_Output.Text.Substring(0, 2) == "\r\n")
                        IDC_Output.Text = IDC_Output.Text.Remove(0, 2);
                }
                IDC_Output.SelectionStart = IDC_Output.Text.Length;
                IDC_Output.ScrollToCaret();
            }
        }
        // Create a PrintLine Delegate used in multi thread 
        private delegate void PrintOutputDelegate(Byte[] Msg);

        // A similar method with PrintLine used in cross thread
        private void SafePrintOutput(Byte[] Msg)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new PrintOutputDelegate(PrintOutput), Msg);
            }
        }

        private void CloseDevice()
        {
            try { m_COM.Close(); }
            catch { };
        }

        private void IDC_Connect_Click(object sender, EventArgs e)
        {
            if (IDC_Connect.Text == "Connect")
            {
                if (SearchForDevice(IDC_PortName.SelectedItem.ToString()))
                {
                    IDC_Connect.Text = "Disconnect";
                }
            }
            else
            {
                CloseDevice();
                IDC_Connect.Text = "Connect";
            }
            Thread RunThread = new Thread(new ThreadStart(ReceiveData));
            RunThread.Start();

        }

        private void IDC_Search_Click(object sender, EventArgs e)
        {
            String[] sPort;
            sPort = SerialPort.GetPortNames();
            IDC_PortName.Items.Clear();
            foreach (String tmp in sPort)
                IDC_PortName.Items.Add(tmp);
            IDC_PortName.SelectedIndex = 0;
        }

        private void IDC_Clear_Click(object sender, EventArgs e)
        {
            IDC_Output.Text = "";
            Output_line_count = 0;
        }

        private void IDC_ClearInput_Click(object sender, EventArgs e)
        {
            //IDC_Input.Text = "";
            IDC_Sent.Text = "";
            sent_line_count = 0;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Thread.Sleep(1);
            threadrunning = false;
            //Thread.CurrentThread.Abort();
            //Application.Exit();
        }

        private void IDC_test_Click(object sender, EventArgs e)
        {
            int i = 1000;
            Byte[] outPacket;
            outPacket = new Byte[1] { 0x7F };
            SendPacket(outPacket);
        }


    }
}
