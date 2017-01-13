using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC16_Assembler
{
   public class InstrBin
    {
       List<string> InstructiuniBin;


       public InstrBin()
       {
           InstructiuniBin = new List<string>();
       }

       public string hexToBin(string _data)
       {
           string s = String.Join(" ", _data.Select(x => Convert.ToString(Convert.ToInt32(x + "", 16), 2).PadLeft(4, '0')));
           return s;
       }

       public void Adauga_linie(List<string> liniiHexa)
       {
           foreach (string item in liniiHexa)
           {
               InstructiuniBin.Add(hexToBin(item));
           }
       }

       public List<string> InstructiuniBinare
       {
           get
           {
               return InstructiuniBin;
           }
       }

    }
}
