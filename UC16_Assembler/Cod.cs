using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace UC16_Assembler
{
    public class Cod
    {
        static string[] instUC16 = { "ad", "sb", "ml", "dv", "adi", "sbi", "rti", "sh", "and", "or", "xor", "msk", "ld", "st"};
        string instructiune;

        string eticheta;
        string opCode;
        string regRez;
        string regOp1;
        string regOp2;
        string offset;
        string etichetaDest;
        string valoare;

        int tip = 0;
        List<string> mesajErr;

        public Cod(string _instructiune)
        {
            instructiune = _instructiune;
            eticheta     = "";
            opCode       = "";
            regRez       = "";
            regOp1       = "";
            regOp2       = "";
            mesajErr     = new List<string>();
            offset       = "";
            etichetaDest = "";
            valoare      = "";
        }
        #region Proprietati
        public string Valoare
        {
            get
            {
                return valoare;
            }
        }
        public int Tip
        {
            get
            {
                return tip;
            }
        }
        public string Instructiune
        {
            get
            {
                return instructiune;
            }
        }
        public string Eticheta
        {
            get
            {
                return eticheta;
            }
        }
        public string OpCode
        {
            get
            {
                return opCode;
            }
        }
        public string RegResult
        {
            get
            {
                return regRez;
            }
        }
        public string RegOp1
        {
            get
            {
                return regOp1;
            }
        }
        public string RegOp2
        {
            get
            {
                return regOp2;
            }
        }
        public string Offset
        {
            get
            {
                return offset;
            }
        }
        public string EtichetaDestinatie
        {
            get
            {
                return etichetaDest;
            }
        }
        public  List<string> Erori
        {
            get
            {
                return mesajErr;
            }
        }
        #endregion
        #region Metode
        public bool caracterPermis(char inputData)
        {
            bool ret_Val = true;
          
                if ((char.IsLetter(inputData)) || (char.IsNumber(inputData)))
                {
                }
                else
                {
                    mesajErr.Add("Eticheta incepe cu un caracter nepermis: ("+ inputData+")\n");
                    ret_Val = false;
                }         
            return ret_Val;
        }

        public bool esteEticheta(string sir )
        {
            bool ret_Val = false;
            if (caracterPermis(sir[0]))         //check if first character is fobidden
            {
                if (sir[(sir.Length - 1)] == ':')   //check if it is a label
                {
                    ret_Val = true;
                }
            }
            return ret_Val;
        }

        public bool esteInstructiune(string sir)
        {
            bool ret_Val = false;
            for (int i = 0; i < instUC16.Length; i++)
            {
                if (sir == instUC16[i] )
                {
                    opCode = i.ToString("X");
                    ret_Val = true;
                    break;
                }
                else if ((sir == "bri") || (sir == "brv") || (sir == "brn") || (sir == "brz"))
                {
                    opCode = sir;
                    ret_Val = true;
                    break;
                }
                else if ((sir == "bii") || (sir == "biv") || (sir == "bin") || (sir == "biz"))
                {
                    opCode = sir;
                    ret_Val = true;
                    break;
                }
            }
            return ret_Val;
        }

        public bool esteReg(string sir)                 //extrag numarul registrului
        {
            bool ret_Val = false;
            if (sir[0] =='r')
            {
                if (sir.Length==3)
                {
                    if (sir[2] == ',')
                    {
                        int val = Convert.ToInt32((sir[1].ToString()), 16);
                        if (val < 16)
                        {
                            ret_Val = true;
                        }
                        else
                        {
                            mesajErr.Add("\nRegistrul \"" + sir + "\" nu exista");
                        }
                    }
                    else { mesajErr.Add("\nEste asteptata \",\" dupa expresia: \"" + sir + "\""); }
                }
                else 
                {
                    int val2;

                    if (Int32.TryParse(sir[1].ToString(), out val2))
                    {
                        int val = Convert.ToInt32((sir[1].ToString()), 16);
                        if (val < 16)
                        {
                            ret_Val = true;
                        }
                        else
                        {
                            mesajErr.Add("\nRegistrul \"" + sir + "\" nu exista");
                        }
                    }
                    else
                    {
                        mesajErr.Add("\nRegistrul \"" + sir + "\" nu exista");
                    }
                    
                    
                }

            }
            return ret_Val;
        }

        public bool esteInt(string sir)
        {
            bool ret_Val = false;
            sir.TrimEnd(',');
            int valoare;
            if (Int32.TryParse(sir,out valoare))
            {
                ret_Val = true;
            }
            return ret_Val;
        }

        public bool esteOffset(string sirr)
        {
            bool ret_Val = false;
            if (sirr.Length == 10)
            {
                string temp_string = "" + sirr[0] + sirr[1];
                if (temp_string  == "IO")
                {
                    offset = "04" + sirr[7] + sirr[8];
                    ret_Val = true;
                }
                else if (temp_string == "DM")
                {
                    offset = "00" + sirr[7] + sirr[8];
                    ret_Val = true;
                }
                else if (temp_string == "PM")
                {
                    offset = "08" + sirr[7] + sirr[8];
                    ret_Val = true;
                }
                
            }
            return ret_Val;
        }

        public bool esteEtichetaDest(string sir, string _eticheta)
        {
            bool ret_Val = false;
            _eticheta.TrimEnd(':');
            if (sir == _eticheta)
            {
                ret_Val = true;
            }
            return ret_Val;
        }

        //take the member instruction and processes it
        public bool procesatInstruct(Cod nextIn)
        {
            bool rez = false;
            string[] bucataInstr = instructiune.Split(' ');
            int x = (bucataInstr.Length);
            switch (x)
            {
                case 1:
                    bucataInstr[0].Trim();
                    if (esteEticheta(bucataInstr[0]))
                    {
                        eticheta = bucataInstr[0];
                        tip = 1;
                        rez = true;
                    }
                    else if (esteInstructiune(bucataInstr[0])) 
                    {
                        tip = 2;
                        rez = true;
                    }
                    else if (esteOffset(bucataInstr[0]))
                    {
                        tip = 3;
                        //offset = bucataInstr[0];
                        rez = true;
                    }
                    else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[0] + ")\n"); }
                
                    break;

                case 2:
                    foreach (string item in bucataInstr)
                    {
                        item.Trim();
                    }

                    if (esteEticheta(bucataInstr[0]))
                    {
                        eticheta = bucataInstr[0];
                        if (esteInstructiune(bucataInstr[1]))
                        {
                            tip = 4;
                            rez = true;
                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else if (esteInstructiune(bucataInstr[0])) 
                    {
                        if (esteEtichetaDest(bucataInstr[1], eticheta))
                        {
                            tip = 5;
                            etichetaDest = bucataInstr[1];
                            rez = true;
                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[0] + ")\n"); }                   
                    break;

                case 3:
                    foreach (string item in bucataInstr)
                    {
                        item.Trim();
                    }
                    if (esteEticheta(bucataInstr[0]))
                    {
                        eticheta = bucataInstr[0];
                        if (esteInstructiune(bucataInstr[1]))
                        {
                            if (esteEtichetaDest(bucataInstr[2], eticheta))
                            {
                                tip = 6;
                                etichetaDest = bucataInstr[2];
                                rez = true;
                            }
                            else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[2] + ")\n"); }

                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else if (esteInstructiune(bucataInstr[0]))
                    {
                        if (esteReg(bucataInstr[1]))
                        {
                            regRez = bucataInstr[1][1].ToString ();
                            if (esteReg(bucataInstr[2]))
                            {
                                tip = 7;
                                regOp1 = bucataInstr[2][1].ToString();
                                offset = nextIn.instructiune;
                                rez = true;
                            }
                            else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[2] + ")\n"); }
                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[0] + ")\n"); }

                    break;

                case 4:
                    foreach (string item in bucataInstr)
                    {
                        item.Trim();
                    }
                    if (esteEticheta(bucataInstr[0]))
                    {
                        eticheta = bucataInstr[0];
                        if (esteInstructiune(bucataInstr[1]))
                        {
                            if (esteReg(bucataInstr[2]))
                            {
                                regRez = bucataInstr[2][1].ToString();
                                if (esteReg(bucataInstr[3]))
                                {
                                    tip = 8;
                                    regOp1 = bucataInstr[3][1].ToString();
                                    rez = true;
                                }
                                else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[2] + ")\n"); }
                            }

                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else if (esteInstructiune(bucataInstr[0]))
                    {
                        if (esteReg(bucataInstr[1]))
                        {
                            regRez = bucataInstr[1][1].ToString();
                            if (esteReg(bucataInstr[2]))
                            {
                                regOp1 = bucataInstr[2][1].ToString();
                                if (esteReg(bucataInstr[3]))
                                {
                                    tip = 9;
                                    regOp2 = bucataInstr[3][1].ToString();
                                    rez = true;
                                }
                                else if (esteInt(bucataInstr[3]))
                                {
                                    tip = 9;
                                    valoare = bucataInstr[3];
                                    rez = true;
                                }
                                else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[3] + ")\n"); }
                            }
                            else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[2] + ")\n"); }
                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[0] + ")\n"); }
                    break;

                case 5:
                    foreach (string item in bucataInstr)
                    {
                        item.Trim();
                    }
                    if (esteEticheta(bucataInstr[0]))
                    {
                        eticheta = bucataInstr[0];
                        if (esteInstructiune(bucataInstr[1]))
                        {
                            if (esteReg(bucataInstr[2]))
                            {
                                regRez = bucataInstr[2][1].ToString();
                                if (esteReg(bucataInstr[3]))
                                {
                                    regOp1 = bucataInstr[3][1].ToString();
                                    if (esteReg(bucataInstr[4]))
                                    {
                                        regOp2 = bucataInstr[4][1].ToString();
                                        tip = 10;
                                        rez = true;
                                    }
                                    else if (esteInt(bucataInstr[4]))
                                    {
                                        tip = 10;
                                        valoare = bucataInstr[4];
                                        rez = true;
                                    }
                                }
                                else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[2] + ")\n"); }
                            }
                        }
                        else { mesajErr.Add("Instructiune necunoscuta: (" + bucataInstr[1] + ")\n"); }
                    }
                    break;

                default:
                    mesajErr.Add("\nLinia \"" + bucataInstr + "\" contine erori si nu poate fi procesata");
                    break;
            }

            return rez;
        }
        #endregion
    }
}
