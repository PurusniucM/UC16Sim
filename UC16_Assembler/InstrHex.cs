using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UC16_Assembler
{
    public class InstrHex
    {
         List<string> InstructiuniHex;
         List<int> Tip;
         Hashtable etichete_adrese;
         string eticheta;
         string opCode;
         string regRez;
         string regOp1;
         string regOp2;
         string offset;
         string etichetaDest;
         string valoare;

         public InstrHex()
        {
            InstructiuniHex = new List<string>();
            Tip             = new List<int>();
            etichete_adrese = new Hashtable();

        }

         public string tratez_offset(string _offset)
         {
             if (_offset[0] == 'D')
             {
                 return "00" + _offset[_offset.Length - 3] + _offset[_offset.Length - 2];
             }
             else if (_offset[0] == 'I')
             {
                 return "04" + _offset[_offset.Length - 3] + _offset[_offset.Length - 2];
             }
             else if (_offset[0] == 'P')
             {
                 return "08" + _offset[_offset.Length - 3] + _offset[_offset.Length - 2];
             }
             else return "eroare citire offset\n";
         }

        public string tratez_instructiune()
        {
            string retVal = "";
            switch (opCode)
            {
                case "0":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "1":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "2":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "3":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "4":
                    retVal = opCode + regRez + regOp1 + valoare;
                    break;
                case "5":
                    retVal = opCode + regRez + regOp1 + valoare;
                    break;
                case "6":
                    return "FFFF";
                case "7":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "8":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "9":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "A":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "B":
                    retVal = opCode + regRez + regOp1 + regOp2;
                    break;
                case "C":
                    retVal = opCode + regRez + regOp1 + "0";
                    break;
                case "D":
                    retVal = opCode + regRez + regOp1 + "0";
                    break;
                case "bri":
                    retVal = "E800";
                    break;
                case "brv":
                    retVal = "E400";
                    break;
                case "brn":
                    retVal = "E200";
                    break;
                case "brz":
                    retVal = "E100";
                    break;
                case "bii":
                    retVal = "F800";
                    break;
                case "biv":
                    retVal = "F400";
                    break;
                case "bin":
                    retVal = "F200";
                    break;
                case "biz":
                    retVal = "F100";
                    break;
                default:
                    break;
            }
            return retVal;
        }
        public string tratez_eticheta_dest()
        {
            string retVal = "Nu exista eticheta " + etichetaDest;
            if (etichete_adrese.Contains(etichetaDest))
            {
                retVal = etichete_adrese[etichetaDest].ToString();
            }
            return retVal;
        }
        public void tratez_eticheta(string _codHexa)
        {
            etichete_adrese.Add(_codHexa, eticheta);
        }
        public void reset_membri()
        {
            eticheta     = "";
            opCode       = "";
            regRez       = "";
            regOp1       = "";
            regOp2       = "";
            offset       = "";
            etichetaDest = "";
            valoare      = "";
        }
        public void tradus_in_hexa(int tip)
         {
             switch (tip)
             {
                 case 1:
                     //nu are aplicatie
                     break;
                 case 2:
                     //nu are aplicatie
                     break;
                 case 3:
                    // InstructiuniHex.Add(tratez_offset(offset));
                    // Tip.Add(tip);
                     break;
                 case 4:
                     //nu are aplicatie
                     break;
                 case 5:
                     InstructiuniHex.Add(tratez_instructiune());
                     InstructiuniHex.Add(tratez_eticheta_dest());
                     Tip.Add(tip);
                     break;
                 case 6:
                     string codHexa = "";
                     codHexa = tratez_instructiune();
                     InstructiuniHex.Add(codHexa);
                     InstructiuniHex.Add(tratez_eticheta_dest());
                     tratez_eticheta(codHexa);
                     break;
                 case 7:
                     InstructiuniHex.Add(tratez_instructiune());
                     InstructiuniHex.Add(tratez_offset(offset));
                     break;
                 case 8:
                     string codHexa2 = "";
                     codHexa2 = tratez_instructiune();
                     InstructiuniHex.Add(codHexa2);
                     InstructiuniHex.Add(tratez_offset(offset));
                     tratez_eticheta(codHexa2);
                     break;
                 case 9:
                     InstructiuniHex.Add(tratez_instructiune());
                     break;
                 case 10:
                     string codHexa3 = "";
                     codHexa3 = tratez_instructiune();
                     InstructiuniHex.Add(codHexa3);
                     tratez_eticheta(codHexa3);
                     break;
                 default:
                     break;
             }
         }
        public void Adauga_linie(Cod linieCod)
         {
             eticheta       = linieCod.Eticheta;
             opCode         = linieCod.OpCode;
             regRez         = linieCod.RegResult;
             regOp1         = linieCod.RegOp1;
             regOp2         = linieCod.RegOp2;
             offset         = linieCod.Offset;
             etichetaDest   = linieCod.EtichetaDestinatie;
             valoare        = linieCod.Valoare;
             tradus_in_hexa(linieCod.Tip);
             reset_membri();

         }

        public List<string> InstructiuniHexa
         {
             get
             {
                 return InstructiuniHex;
             }
         }
        public string InstructiuneHex(int a)
        {
            if (a<InstructiuniHex.Count)
            {
                return InstructiuniHex[a];
            }
            else
            {
                return null;
            }
            
        }
    }
}
