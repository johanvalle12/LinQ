using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariosMetodosInteresantes
{
    class MyWord
    {
        public static int Length { get; set; }
        public static string Word { get; set; }
        public MyWord(int length, string word)
        {
            Length = length;
            Word = word;
        }
    }
}
