using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BaseConverter
{
    public class Converter
    {
        public string Base { get; set; } = "";
        public Encoding TextEncoding { get; set; } = Encoding.ASCII;

        public Converter(string baseString) {
            Base = baseString;
        }

        public string Convert(string input)
        {
            StringBuilder output = new StringBuilder();

            BitArray bits = new BitArray(TextEncoding.GetBytes(input));

            int length = (int)Math.Ceiling(Math.Log(Base.Length, 2));
            int index = 0;
            while (index < bits.Length) {
                int value = BitHelper.GetInteger(bits, index, length);
                output.Append(Base[value]);

                index += length;
            }

            return output.ToString();
        }
        public string ConvertBack(string input) {
            List<bool> boolBits = new List<bool>();
            for (int i = 0; i < input.Length; i++) {
                List<bool> charBool = BitHelper.GetBoolBitsFromInt(Base.IndexOf(input[i]));
                boolBits.AddRange(charBool);
            }

            byte[] bytes = BitHelper.PackBools(boolBits);

            return TextEncoding.GetString(bytes);
        }
    }

    public enum EncodingType { 
        ASCII,
        Unicode,
        Default,
        UTF_7,
        UTF_8,
        UTF_32
    }
}
