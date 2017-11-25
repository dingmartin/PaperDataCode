using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HeadTailBreaks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void HeadPercentage_TextChanged(object sender, EventArgs e)
        {
            if(HeadPercentage.Text!="")
                TailPercentage.Text = (100 - double.Parse(HeadPercentage.Text)).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TailPercentage.Text = (100 - double.Parse(HeadPercentage.Text)).ToString();

            //BreakResult.Text = "111";
        }

        private void HeadPercentage_MouseLeave(object sender, EventArgs e)
        {
            if (double.Parse(HeadPercentage.Text) > 50 || HeadPercentage.Text == "")
                HeadPercentage.Text = "50";
        }
        private void HeadPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            //if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            //if (e.KeyChar > 0x20)
            //{
            //    try
            //    {
            //        double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
            //    }
            //    catch
            //    {
            //        e.KeyChar = (char)0;   //处理非法字符
            //    }
            //}
            try
            {
                if (!IsNumberic(e.KeyChar.ToString()) && (int)(e.KeyChar) != 8 && e.KeyChar != Convert.ToChar(Keys.Return))
                {
                    e.Handled = true;
                    return;
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
        private bool IsNumberic(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"\d|\.");
            return reg1.IsMatch(str);
        }
        private void data_TextChanged(object sender, EventArgs e)
        {
            data.Text = data.Text.TrimEnd();
            if (data.Text != "" && data.Text != "or Paste data here...")
                InputFileAddress.Enabled = false;
            else
                InputFileAddress.Enabled = true;
            //data.Focus();
            if (data.Text != "")
            {
                data.SelectionStart = data.Text.Length - 1;
                data.ScrollToCaret();
            }
        }

        private void data_MouseEnter(object sender, EventArgs e)
        {
            
        }
        public int getHtindex(List<double> list, ref List<double> meanlist)
        {
            if (list.Count == 0)
                return 0;
            int htIndex = 0;
            double mean = getMean(list);
            double percentInhead = 0.2;
            int cntInhead = 0;
            int percentInTail = 0;
            htIndex = 0;
            while ((int)(percentInhead * 100) <= 40)
            {
                htIndex++;
                List<double> numlisttemp = new List<double>();
                mean = getMean(list);
                meanlist.Add(mean);
                foreach (double b in list)
                {
                    if (b >= mean)
                        numlisttemp.Add(b);
                }
                cntInhead = numlisttemp.Count;
                // int cntInTail = numberlist.Count - cntInhead;
                percentInhead = (double)cntInhead / (double)list.Count;
                percentInTail = 100 - (int)(percentInhead * 100);
                list = numlisttemp;
            }
            meanlist.RemoveAt(meanlist.Count - 1);
            return htIndex;

        }
        public double getMean(List<double> list)
        {
            double mean = 0;
            double sum = 0;
            foreach (double b in list)
                sum = sum + b;
            mean = sum / list.Count;
            return mean;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (data.Enabled)
            {
                double CRG = 0;
                int htIn = FromTextBox(ref CRG);
                htIndex.Text = htIn.ToString();
                //CRGIndex.Text = Math.Round(CRG, 2).ToString();
                //FromAddress();
                //string copy = BreakResult.Text;
                string copy = Finaltext1;
                Clipboard.SetDataObject(copy);
                MessageBox.Show("Done!  Result copied to clipboard");
            }
            else 
            {
                double CRG = 0;
                int htIn = FromAddress(ref CRG);
                htIndex.Text = htIn.ToString();
                //CRGIndex.Text = Math.Round(CRG, 2).ToString();
                //FromAddress();
                //string copy = BreakResult.Text;
                string copy = Finaltext1;
                Clipboard.SetDataObject(copy);
                MessageBox.Show("Result copied in clipboard");
            
            
            }
        }
        public double getCRG(List<double> meanlist) 
        {
            double CRG = 0;
            int count = meanlist.Count;
            if (count == 1)
                CRG = meanlist[0];
            else if (count > 1) 
            {
                for (int i = 1; i < meanlist.Count; i++) 
                {
                    double temp = (double)meanlist[i] / meanlist[i - 1];
                    CRG += temp;
                }
            
            }
            return CRG;
        }

        string text1 = "";
        private int FromTextBox(ref double CRG)
        {
           
                List<double> numberlist = new List<double>();
                double number = 0;
                int linecnt = 0;
                string rline = data.Text;
                string[] rlinesplit = rline.Split('\n');

                for (int i = 0; i < rlinesplit.Length; i++)
                {
                    //if (rlinesplit[i])
                    if (rlinesplit[i].Length != 0)
                    {
                        double n=0;
                        rlinesplit[i] = rlinesplit[i].Remove(rlinesplit[i].Length - 1);
                        bool isNumeric = double.TryParse(rlinesplit[i],out n);
                        if (isNumeric)
                        {
                            number = double.Parse(rlinesplit[i]);
                            numberlist.Add(number);
                        }
                    }
                }

                List<double> meanlist = new List<double>();
                getHtindex(numberlist, ref meanlist);
                CRG = getCRG(meanlist);

                //iterative mean calculation    

                double percentInhead = 0.2;
                int cntInhead = 0;
                int percentInTail = 0;
                int cntInTail = 0;
                double mean = 0;
                //string SaveAddress = @"C:\PhD work\OSM\historyWorldOSM\coedit network\option2\1111\HierarchyRule1.txt";
                //System.IO.FileStream fs = new System.IO.FileStream(SaveAddress, FileMode.Append);
                //StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string text = "";
                text1 = "";
                string Finaltext = "";
                Finaltext1 = "";
                text = "#Data" + "\t" + "#head" + "\t" + "%head" + "\t" + "#tail" + "\t" + "%tail" + "\t" + "mean";
                Finaltext = text;
                Finaltext1 = text;
                //sw.WriteLine(text);
                int htIndex = 0;

                while ((int)(percentInhead * 100) <= int.Parse(HeadPercentage.Text))
                {
                    htIndex++;
                    List<double> numlisttemp = new List<double>();
                    mean = getMean(numberlist);
                    foreach (double b in numberlist)
                    {
                        if (b >= mean)
                            numlisttemp.Add(b);
                    }
                    cntInhead = numlisttemp.Count;
                    cntInTail = numberlist.Count - cntInhead;
                    // int cntInTail = numberlist.Count - cntInhead;
                    percentInhead = (double)cntInhead / (double)numberlist.Count;
                    percentInTail = 100 - (int)(percentInhead * 100);
                    text = numberlist.Count + "\t" + cntInhead + "\t" + (int)(percentInhead * 100) + "%" + "\t" + cntInTail + "\t" + percentInTail + "%" + "\t" + Math.Round(mean, 2);
                    text1 = numberlist.Count + "\t" + cntInhead + "\t" + (int)(percentInhead * 100) + "%" + "\t" + cntInTail + "\t" + percentInTail + "%" + "\t" + mean;
                    if ((int)(percentInhead * 100) <= int.Parse(HeadPercentage.Text))
                    {
                        Finaltext = Finaltext + "\r\n" + text;
                        Finaltext1 = Finaltext1 + "\r\n" + text1;
                    }
                    numberlist = numlisttemp;
                }
                BreakResult.Text = Finaltext;
                BreakResult.WordWrap = true;
                //sw.Close();
                //fs.Close();

               
                //MessageBox.Show((htIndex).ToString());
                return htIndex;
            
          
        }
        struct numCnt 
        {
            public double value;
            public double count;
        
        }
        string Finaltext1 = "";
        private int FromAddress(ref double CRG)
        {
            string OpenAddress = @InputFileAddress.Text;
            StreamReader sr = new StreamReader(OpenAddress);
            List<double> numberlist = new List<double>();
            
            double number = 0;
            int linecnt = 0;
            while (sr.Peek() > 0)
            {
                //if (linecnt == 0)
                //{
                //    linecnt++;
                //    string rl = sr.ReadLine();
                //    continue;
                //}
                string rline = sr.ReadLine();
                string[] rlinesplit = rline.Split('\t');
                if (rlinesplit.Length == 2)
                {
                    for (int i = 0; i < int.Parse(rlinesplit[1]); i++)
                    {
                        double n = 0;
                        
                        bool isNumeric = double.TryParse(rlinesplit[0], out n);
                        if (isNumeric)
                        {
                            number = double.Parse(rlinesplit[0]);
                            numberlist.Add(number);
                        }

                     
                    }
                
                    
                }
                else
                {
                    double n = 0;

                    bool isNumeric = double.TryParse(rline, out n);
                    if (isNumeric)
                    {
                        number = double.Parse(rline);
                        numberlist.Add(number);
                    }
                  
                }
            }
            int htIndex = 0;

            List<double> meanlist = new List<double>();
            getHtindex(numberlist, ref meanlist);
            CRG = getCRG(meanlist);
            //iterative mean calculation    
          
                double percentInhead = 0.2;
                int cntInhead = 0;
                int percentInTail = 0;
                int cntInTail = 0;
                double mean = 0;
                //string SaveAddress = @"C:\PhD work\OSM\historyWorldOSM\coedit network\option2\1111\HierarchyRule1.txt";
                //System.IO.FileStream fs = new System.IO.FileStream(SaveAddress, FileMode.Append);
                //StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string text = "";
                text1 = "";
                string Finaltext = "";
                Finaltext1 = "";
                text = "#Data" + "\t" + "#head" + "\t" + "%head" + "\t" + "#tail" + "\t" + "%tail" + "\t" + "mean";
                Finaltext = text;
                Finaltext1 = text;
                //sw.WriteLine(text);


                while ((int)(percentInhead * 100) <= int.Parse(HeadPercentage.Text))
                {
                    htIndex++;
                    List<double> numlisttemp = new List<double>();
                    mean = getMean(numberlist);
                    foreach (double b in numberlist)
                    {
                        if (b >= mean)
                            numlisttemp.Add(b);
                    }
                    cntInhead = numlisttemp.Count;
                    if (cntInhead == 0)
                        break;
                    cntInTail = numberlist.Count - cntInhead;
                    // int cntInTail = numberlist.Count - cntInhead;
                    percentInhead = (double)cntInhead / (double)numberlist.Count;
                    percentInTail = 100 - (int)(percentInhead * 100);
                    text = numberlist.Count + "\t" + cntInhead + "\t" + (int)(percentInhead * 100) + "%" + "\t" + cntInTail + "\t" + percentInTail + "%" + "\t" + Math.Round(mean, 2);
                    text1 = numberlist.Count + "\t" + cntInhead + "\t" + (int)(percentInhead * 100) + "%" + "\t" + cntInTail + "\t" + percentInTail + "%" + "\t" + mean;
                    if ((int)(percentInhead * 100) <= int.Parse(HeadPercentage.Text))
                    {
                        Finaltext = Finaltext + "\r\n" + text;
                        Finaltext1 = Finaltext1 + "\r\n" + text1;
                    }
                    numberlist = numlisttemp;
                }
                BreakResult.Text = Finaltext;
                BreakResult.WordWrap = true;
                //sw.Close();
                //fs.Close();

              
            //MessageBox.Show((htIndex).ToString());

       
             return htIndex; 
        }

        private void BreakResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string copy = BreakResult.Text;
            Clipboard.SetDataObject(copy); 

        }

        private void data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }
        #region AllowDrop
        protected void SetAllTextBox()
        {
            foreach (Control txt in this.Controls)
            {
                if (txt is TextBox)
                {
                    txt.AllowDrop = true;
                    txt.DragDrop += new DragEventHandler(txt_ObjDragDrop);
                    txt.DragEnter += new DragEventHandler(txt_ObjDragEnter);
                }
                else
                {
                    if (txt.Controls.Count > 0)
                    {
                        SetAllTextBox(txt);
                    }
                }
            }


        }

        protected void SetAllTextBox(Control org)
        {
            foreach (Control txt in org.Controls)
            {
                if (txt is TextBox)
                {
                    txt.AllowDrop = true;
                    txt.DragDrop += new DragEventHandler(txt_ObjDragDrop);
                    txt.DragEnter += new DragEventHandler(txt_ObjDragEnter);
                }
                else
                {
                    if (txt.Controls.Count > 0)
                    {
                        SetAllTextBox(txt);
                    }
                }
            }
        }

        private void txt_ObjDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void txt_ObjDragDrop(object sender, DragEventArgs e)
        {
            ((TextBox)sender).Text
                = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
        }
        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void InputFileAddress_TextChanged(object sender, EventArgs e)
        {
            if (InputFileAddress.Text != "")
                data.Enabled = false;
            else
                data.Enabled = true;
        }

        private void data_MouseClick(object sender, MouseEventArgs e)
        {
            //data.Text = "";
        }

        private void data_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void data_MouseLeave(object sender, EventArgs e)
        {
            //if (data.Text == "")
            //{
            //    data.Text = "or Paste data here...";
            //}
        }

        private void clearText_Click(object sender, EventArgs e)
        {

            data.Text = "";

        }

    }
}
