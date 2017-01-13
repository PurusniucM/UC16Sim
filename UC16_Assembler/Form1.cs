using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace UC16_Assembler
{
    public partial class Form3 : Form
    {
        //sizes
        int nr_registri         = 16;
        int tBox_4_bit_length   = 30;      //dimensions for 16 bit register or memory representation
        int tBoxheight          = 20;
        int tBox_1_bit_length   = 22;      //dimensions for 1 bit flag representation
        int lblSize             = 13;
        int simulator_len       = 1000;
        int simulator_height    = 550;
        int pc_length           = 120;

        //locations
        int tB_reg_X    = 615;            //position of first register column
        int tB_Y        = 57;
        int tB_memC1_X  = 710;            //start position of first column of memory locations
        int tB_memC2_X  = 820;            //start position of second column of memory locations
        int tB_memC3_X  = 930;
        int tB_flag_X   = 535;            //position of first flag in flag column
        int lbl_reg_X   = 590;            //position of register labels column
        int lbl_memC1_X = 665;            //position of first label for first memory column
        int lbl_memC2_X = 775;            //position of first label for second memory column
        int lbl_memC3_X = 885;            //position of first label for second memory column
        int lbl_Y       = 60;
        int pc_Xpos     = 15;
        int pc_Ypos     = 355;

        int LineCount = 0;

        string open_fileName = "";

        String numeReg      = "Reg-";     //names of addresses labels
        String numeMemC1    = "Mm1-";
        String numeMemC2    = "Mm2-";
        String numeMemC3    = "Mm3-";
        String numeFlag     = "Flg-";
        String numelabel    = "Lbl-";        

        Label[] lbl_registri;             //objects arrays
        Label[] lbl_memorie_col1;
        Label[] lbl_memorie_col2;
        Label[] lbl_memorie_col3;
        Label[] lbl_flags;
        TextBox[] registri ;
        TextBox[] memorieC1;
        TextBox[] memorieC2;
        TextBox[] memorieC3;
        TextBox[] Flags;
        TextBox program_counter;

        Cod[] LinieCod;
        InstrHex CodHexa = new InstrHex();
        InstrBin CodBinar = new InstrBin();

        #region Control generating functions

        private void sim_window_resize()
        {
            this.ClientSize = new Size(simulator_len, simulator_height);
        }

        //Adding any label
        private void add_anyLabel(string text, int X_pos, int Y_pos)
        {
            Label lbl_pc = new Label();
            lbl_pc.Location = new Point(X_pos, Y_pos );
            lbl_pc.AutoSize = true;
            lbl_pc.ForeColor = Color.FromArgb(0, 192, 192);
            lbl_pc.Text = text;
            this.Controls.Add(lbl_pc);
        }

        //Adding Program counter
        private void add_PC()
        {
            program_counter = new TextBox();
            program_counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            program_counter.Enabled = false;
            program_counter.Location = new Point(pc_Xpos, pc_Ypos);
            program_counter.Size = new Size(pc_length, tBoxheight);
            program_counter.Name = "Program_Counter";
            this.Controls.Add(program_counter);
            add_anyLabel("Program Counter", pc_Xpos, (pc_Ypos+ tBoxheight + 5));
        }

        //Adding labels forr registers/memories
        private void add_Label(Label Lbl, int pcs, int X, int Y, string nume, int index)  //labels for all registers and memory locations
        {
            Lbl = new Label();
            Lbl.AutoSize = true;
            Lbl.Location = new Point(X, Y);
            Lbl.Name = numelabel + index.ToString();
            Lbl.Text = nume;
            Lbl.ForeColor = Color.FromArgb(0,192,192);
            Lbl.Size = new System.Drawing.Size(lblSize, lblSize);
            this.Controls.Add(Lbl);
        }

        private void add_TextB_16_bit(out TextBox[] R, int pcs, string nume)      // text boxes adding for registers or memory locations
        {
            int Y = tB_Y;
            int Yfl = pc_Ypos;
            int yrlbl = lbl_Y;
            R = new TextBox[pcs];
            for (int i = 0; i < pcs; i++)
            {
                R[i] = new TextBox();
                R[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                R[i].ReadOnly = true;
                
                this.Controls.Add(R[i]);
                if (nume == numeReg)
                {
                    lbl_registri=new Label[pcs];
                    R[i].Text = "0000";
                    R[i].Name = i.ToString("X");
                    R[i].Location = new Point(tB_reg_X, tB_Y);
                    R[i].Size = new Size(tBox_4_bit_length, tBoxheight);
                    add_Label(lbl_registri[i], pcs, lbl_reg_X, lbl_Y, R[i].Name, i);                    
                }
                else if (nume == numeMemC1)
                {
                    lbl_memorie_col1=new Label[pcs];
                    R[i].Text = "0000";
                    R[i].Name =("0x00"+((i*2).ToString("X").PadLeft(2,'0')));
                    R[i].Location = new Point(tB_memC1_X, tB_Y);
                    R[i].Size = new Size(tBox_4_bit_length, tBoxheight);
                    add_Label(lbl_memorie_col1[i], pcs, lbl_memC1_X, lbl_Y, R[i].Name, i);
                }
                else if (nume == numeMemC2)
                {
                    int ym2lbl = lbl_Y;
                    lbl_memorie_col2=new Label[pcs];
                    R[i].Text = "0000";
                    R[i].Name = ("0x04"+((i * 2).ToString("X")).PadLeft(2, '0'));
                    R[i].Location = new Point(tB_memC2_X, tB_Y);
                    R[i].Size = new Size(tBox_4_bit_length, tBoxheight);
                    add_Label(lbl_memorie_col2[i], pcs, lbl_memC2_X, lbl_Y, R[i].Name, i);
                }
                else if (nume == numeMemC3)
                {
                    int ym2lbl = lbl_Y;
                    lbl_memorie_col3 = new Label[pcs];
                    R[i].Text = "0000";
                    R[i].Name = ("0x08"+((((i * 2).ToString("X")).PadLeft(2, '0'))));
                    R[i].Location = new Point(tB_memC3_X, tB_Y);
                    R[i].Size = new Size(tBox_4_bit_length, tBoxheight);
                    add_Label(lbl_memorie_col3[i], pcs, lbl_memC3_X, lbl_Y, R[i].Name, i);
                }
                else
                {
                    lbl_flags = new Label[pcs];
                    R[i].Text = "0";
                    R[i].Location = new Point(tB_flag_X, pc_Ypos);
                    R[i].Size = new Size(tBox_1_bit_length, tBoxheight);                    
                }

                pc_Ypos += tBoxheight + 5;
                tB_Y += tBoxheight + 5;
                lbl_Y += lblSize + 12;  
            }
            pc_Ypos = Yfl;
            tB_Y = Y;
            lbl_Y = yrlbl;
        }

        #endregion

        #region Other Functions
        public  void deselect_tot( RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = richTextBox.BackColor;
        }
        public  void select_linie( RichTextBox richTextBox, int nrLinie, Color color)
        {
            var lines = richTextBox.Lines;
            if (nrLinie < 0 || nrLinie >= lines.Length)
                return;
            var start = richTextBox.GetFirstCharIndexFromLine(nrLinie); 
            var length = lines[nrLinie].Length;
            richTextBox.Select(start, length);                 
            richTextBox.SelectionBackColor = color;
        }
        public void decolorez_text( RichTextBox richTextBox)
        {
            richTextBox.SelectAll();
            richTextBox.SelectionColor = richTextBox.ForeColor;
        }
        public void colorez_text(RichTextBox richTextBox, int nrLinie, Color color)
        {
            var lines = richTextBox.Lines;
            if (nrLinie < 0 || nrLinie >= lines.Length)
                return;
            var start = richTextBox.GetFirstCharIndexFromLine(nrLinie);
            var length = lines[nrLinie].Length;
            richTextBox.Select(start, length);
            richTextBox.SelectionColor = color;
        }
        public void afiseaza_erori(List<string> sirErori, int index)
        {
            if (sirErori.Count>0)
            {
                int nrItem = 0;
                select_linie(rtbContinut, index, Color.HotPink);
                foreach (var item in sirErori)
	            {
                    rtbError.AppendText(item + "\n");
                    colorez_text(rtbContinut,nrItem++,Color.Red);
	            }
               
            }
        }
        public void afisez_cod(RichTextBox txtB, List<string> sirInstr)
        {
            foreach (string item in sirInstr)
            {
                txtB.AppendText(item + "\n");
            }
        }
        public void afisez_codHex(RichTextBox txtB, List<string> sirInstr)
        {
            foreach (string item in sirInstr)
            {
                txtB.AppendText("X\""+item +"\""+ "\n");
            }
        }
        public void initializarePC()
        {
            if (CodHexa.InstructiuneHex(0) != null)
            {
                program_counter.Text = CodHexa.InstructiuneHex(0);
            }
            else 
            { 
                rtbError.AppendText("Nu exista cod asamblat!\n");
                colorez_text(rtbError, 0, Color.Red);
            }
        }
        public void setFlags(int rezTemp, string sirTemp, TextBox reg)
        {
            if (rezTemp == 0)
            {
                Flags[2].Text = "1";
                Flags[2].BackColor = Color.Yellow;
                Flags[2].ForeColor = Color.Red;
            }
            else
            {
                Flags[2].Text = "0";
                Flags[2].BackColor = Color.White;
                Flags[2].ForeColor = Color.Black;
            }
            if (rezTemp < 0)
            {
                Flags[1].Text = "1";
                Flags[1].BackColor = Color.Yellow;
                Flags[1].ForeColor = Color.Red;
            }
            else
            {
                Flags[1].Text = "0";
                Flags[1].BackColor = Color.White;
                Flags[1].ForeColor = Color.Black;
            }
            if (sirTemp.Length > 4)
            {
                Flags[0].Text = "1";
                reg.Text = (sirTemp[sirTemp.Length - 4].ToString() + sirTemp[sirTemp.Length - 3] + sirTemp[sirTemp.Length - 2] + sirTemp[sirTemp.Length - 1]);
                reg.BackColor = Color.Yellow;
                Flags[0].BackColor = Color.Yellow;
                Flags[0].ForeColor = Color.Red;
                reg.ForeColor = Color.Red;
            }
            else
            {
                Flags[0].Text = "0";
                Flags[0].BackColor = Color.White;
                Flags[0].ForeColor = Color.Black;
                reg.Text = sirTemp;
                reg.BackColor = Color.Yellow;
                reg.ForeColor = Color.Red;
            }
        }
        public void salt(int tipSalt)
        {
            if (tipSalt == 1)
            {
                if (Flags[2].Text=="1")
                {
                    program_counter.Text = CodHexa.InstructiuneHex(++LineCount);
                }
            }
            else if (tipSalt == 2)
            {

            }
            else if (tipSalt == 4)
            {

            }
            else if (tipSalt == 8)
            {

            }
        }
        public void executa_instructiune(string instructiune)
        {
            for (int i = 0; i < 16; i++)
            {
                registri[i].BackColor = Color.White;
                memorieC1[i].BackColor = Color.White;
                memorieC2[i].BackColor = Color.White;
                memorieC3[i].BackColor = Color.White;
            }
            int[] v = new int[instructiune.Length];
            for (int i = 0; i < instructiune.Length; i++)
            {
                v[i]= Convert.ToInt32(instructiune[i].ToString(), 16);
            }
            string sirTemp = "";
            int rezTemp = 0;
            switch (instructiune[0])
            {
                case'0':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu succes!");
                    }
                    
                    break;
                case '1':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) - (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '2':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) * (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '3':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) / (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '4':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + v[3]);
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '5':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + v[3]);
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '6':
                    break;
                case '7':
                    if (v[3]==0)
                    {
                        rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) * Convert.ToInt32(Math.Pow(2, (Convert.ToInt32(registri[v[3]].Text, 16)))));
                    }
                    else
                    {
                        rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) / Convert.ToInt32(Math.Pow(2, (Convert.ToInt32(registri[v[3]].Text, 16)))));
                    }
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '8':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) & (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case '9':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) | (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case 'A':
                    rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) ^ (Convert.ToInt32(registri[v[3]].Text, 16)));
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu secces!");
                    }
                    break;
                case 'B':
                    break;
                case 'C':
                    string instructiune2 = LinieCod[++LineCount].Offset;
                    int[] v2 = new int[instructiune2.Length];
                    string memLocIndex = instructiune2[2].ToString() + instructiune2[3];
                    int indexConvert = (Convert.ToInt32(memLocIndex, 16)) / 2;
                    for (int i = 0; i < instructiune2.Length; i++)
                    {
                        v2[i] = Convert.ToInt32(instructiune2[i].ToString(), 16);
                    }

                    if (v2[1] == 0)
                    {
                        rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + (Convert.ToInt32(memorieC1[indexConvert].Text, 16)));
                    }
                    else if (v2[1] == 4)
                    {
                        rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + (Convert.ToInt32(memorieC2[indexConvert].Text, 16)));
                    }
                    else if (v2[1] == 8)
                    {
                        rezTemp = ((Convert.ToInt32(registri[v[2]].Text, 16)) + (Convert.ToInt32(memorieC3[indexConvert].Text, 16)));
                    }
                    sirTemp = rezTemp.ToString("X");
                    setFlags(rezTemp, sirTemp, registri[v[1]]);
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu succes!");
                    }
                    break;
                case 'D':
                    string instructiune3 = LinieCod[++LineCount].Offset;
                    int[] v3 = new int[instructiune3.Length];
                    string memLocIndex2 = instructiune3[2].ToString() + instructiune3[3];
                    for (int i = 0; i < instructiune3.Length; i++)
                    {
                        v3[i] = Convert.ToInt32(instructiune3[i].ToString(), 16);
                    }
                    rezTemp = Convert.ToInt32(registri[v[1]].Text, 16) + Convert.ToInt32(registri[v[2]].Text, 16);
                    sirTemp = rezTemp.ToString("X");
                    if (v3[1] == 0)
                    {
                        setFlags(rezTemp, sirTemp, memorieC1[(Convert.ToInt32(memLocIndex2, 16)) / 2]);
                    }
                    else if (v3[1] == 4)
                    {
                        setFlags(rezTemp, sirTemp, memorieC2[(Convert.ToInt32(memLocIndex2, 16)) / 2]);
                    }
                    else if (v3[1] == 8)
                    {
                        setFlags(rezTemp, sirTemp, memorieC3[(Convert.ToInt32(memLocIndex2, 16)) / 2]);
                    }
                    if ((CodHexa.InstructiuneHex(++LineCount)) != null)
                    {
                        program_counter.Text = CodHexa.InstructiuneHex(LineCount);
                    }
                    else
                    {
                        stripBtnRun.Enabled = false;
                        rtbError.AppendText("Fisier compilat cu succes!");
                    }
                    break;
                case 'E':
                    break;
                case 'F':
                    break;
                default:
                    break;
            }
        }

        #endregion

        public Form3()
        {
            InitializeComponent();
        }

        //generating simulation window
        private void stripBtnStartSimulation_Click(object sender, EventArgs e)
        {
            if (stripBtnRun.Enabled==false)
            {
                sim_window_resize();
                add_TextB_16_bit(out registri, 16, numeReg);
                add_TextB_16_bit(out memorieC1, 16, numeMemC1);
                add_TextB_16_bit(out memorieC2, 16, numeMemC2);
                add_TextB_16_bit(out memorieC3, 16, numeMemC3);
                add_TextB_16_bit(out Flags, 3, numeFlag);
                add_PC();
                add_anyLabel("Registri", lbl_reg_X, 41);
                add_anyLabel("Locatii memorie", lbl_memC2_X, 41);
                add_anyLabel("Flag-uri", tB_flag_X - 15, pc_Ypos - 17);
                add_anyLabel("O", tB_flag_X - 20, pc_Ypos + 5);
                add_anyLabel("N", tB_flag_X - 20, pc_Ypos + 30);
                add_anyLabel("Z", tB_flag_X - 20, pc_Ypos + 55);
                stripBtnRun.Enabled = true;
                program_counter.Text = CodHexa.InstructiuneHex(0);
            }

        }

        //open code file
        private void stripBtnOpenFile_Click(object sender, EventArgs e)//
        {
            rtbBinar.Clear();
            rtbHexa.Clear();
            rtbError.Clear();
            rtbContinut.Clear();
           DialogResult userClickedOK = openFileDia.ShowDialog();
           if (userClickedOK == DialogResult.OK)
           {
                try 
	                {
                        Stream fisier = openFileDia.OpenFile();
                        using (StreamReader reader = new StreamReader(fisier))
                        {
                            string linie;
                            int ind = 0;
                            List<string> date = new List<string>();
                            while ((linie = reader.ReadLine()) != null)
                            {
                                date.Add(linie);
                                rtbContinut.AppendText(linie + "\n");
                            }
                            LinieCod = new Cod[date.Count];
                            foreach (string item in date)
                            {
                                LinieCod[ind++] = new Cod(item);
                            }
                            rtbError.AppendText("Fisier deschis cu succes\n");
                            reader.Close();
                        } 
	                }
	            catch (IOException ex)
	                {
                        rtbError.AppendText("Eroare la citire: " +ex.Message + "\n");
	                }   
           }
        }
        
        //saving code to file
        private void stripBtnSaveFile_Click(object sender, EventArgs e)
        {
            rtbError.Clear();
            MemoryStream userInput = new MemoryStream();
            try
            {
                rtbContinut.SaveFile(userInput, RichTextBoxStreamType.PlainText);
                DialogResult result = saveFileDialog1.ShowDialog();
                Stream fileStream;

                if (result == DialogResult.OK)
                {
                    fileStream = saveFileDialog1.OpenFile();
                    userInput.Position = 0;
                    userInput.WriteTo(fileStream);
                    fileStream.Close();
                    rtbError.AppendText("Fisier salvat cu succes\n");
                }
            }
            catch (IOException ex)
            {
                rtbError.AppendText("Eroare la scriere:"+ex.Message+"\n"); 
            }
        }

        private void stripBtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stripBtnAssemble_Click(object sender, EventArgs e)
        {
            LineCount = 0;
            rtbBinar.Clear();
            rtbHexa.Clear();
            rtbError.Clear();
            deselect_tot(rtbContinut);
            decolorez_text(rtbError);
            decolorez_text(rtbContinut);
            for (int i = 0; i < LinieCod.Length; i++)
            {
                if (i+1 < LinieCod.Length)
                {
                    LinieCod[i].procesatInstruct(LinieCod[(i+1)]);
                }
                else
                {
                    LinieCod[i].procesatInstruct(LinieCod[i]);
                }
                
                afiseaza_erori(LinieCod[i].Erori, i);
                CodHexa.Adauga_linie(LinieCod[i]);
            }
            CodBinar.Adauga_linie(CodHexa.InstructiuniHexa);
            afisez_codHex(rtbHexa, CodHexa.InstructiuniHexa);
            afisez_cod(rtbBinar, CodBinar.InstructiuniBinare);

            if (rtbError.TextLength ==0)
            {
                rtbError.AppendText("Fisier asamblat cu succes!\n");
            }
        }

        private void stripBtnRun_Click(object sender, EventArgs e)
        {
            deselect_tot(rtbHexa);
            select_linie(rtbHexa, LineCount, Color.Blue);
            deselect_tot(rtbContinut);
            select_linie(rtbContinut, LineCount, Color.Blue);
            deselect_tot(rtbBinar);
            select_linie(rtbBinar, LineCount, Color.Blue);
            rtbError.Clear();
            executa_instructiune(program_counter.Text);
        }

        private void stripBtnHelp_Click(object sender, EventArgs e)
        {
            Form help = new HelpFRM();
            help.Show();
        }
    }
}
