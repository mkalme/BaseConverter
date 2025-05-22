using System;
using System.Collections;
using System.Collections.Generic;

namespace BaseConverter {
    class BitHelper {
        public static int GetInteger(BitArray bitArray, int index, int length) {
            int value = 0;

            int i = index;
            while (i < bitArray.Length && i - index < length) {
                if (bitArray[i]) value += 1 << i - index;
                
                i++;
            }

            return value;
        }
        public static List<bool> GetBoolBitsFromInt(int value) {
            int length = (int)Math.Ceiling(Math.Log(value, 2));

            List<bool> output = new List<bool>();

            BitArray bits = new BitArray(new int[] { value });
            for (int i = 0; i < length; i++) {
                output.Add(bits[i]);
            }

            return output;
        }

        public static byte[] PackBools(List<bool> boolBits)
        {
            int len = boolBits.Count;
            int bytes = len >> 3;
            if ((len & 0x07) != 0) ++bytes;

            byte[] output = new byte[bytes];
            for (int i = 0; i < boolBits.Count; i++) {
                if (boolBits[i]) output[i >> 3] |= (byte)(1 << (i & 0x07));
            }

            return output;
        }
    }
}
