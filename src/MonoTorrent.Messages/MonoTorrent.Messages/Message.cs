//
// Message.cs
//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//
// Copyright (C) 2008 Alan McGovern
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System;
using System.Net;

namespace MonoTorrent.Messages
{
    public abstract class Message : IMessage
    {
        public abstract int ByteLength { get; }

        public abstract void Decode (byte[] buffer, int offset, int length);

        public byte[] Encode ()
        {
            byte[] buffer = new byte[ByteLength];
            Encode (buffer, 0);
            return buffer;
        }

        public abstract int Encode (byte[] buffer, int offset);

        public static byte ReadByte (byte[] buffer, int offset)
        {
            return buffer[offset];
        }

        public static byte ReadByte (byte[] buffer, ref int offset)
        {
            byte b = buffer[offset];
            offset++;
            return b;
        }

        public static byte[] ReadBytes (byte[] buffer, int offset, int count)
        {
            return ReadBytes (buffer, ref offset, count);
        }

        public static byte[] ReadBytes (byte[] buffer, ref int offset, int count)
        {
            byte[] result = new byte[count];
            Buffer.BlockCopy (buffer, offset, result, 0, count);
            offset += count;
            return result;
        }

        public static short ReadShort (byte[] buffer, int offset)
        {
            return ReadShort (buffer, ref offset);
        }

        public static short ReadShort (byte[] buffer, ref int offset)
        {
            short ret = IPAddress.NetworkToHostOrder (BitConverter.ToInt16 (buffer, offset));
            offset += 2;
            return ret;
        }

        public static string ReadString (byte[] buffer, int offset, int count)
        {
            return ReadString (buffer, ref offset, count);
        }

        public static string ReadString (byte[] buffer, ref int offset, int count)
        {
            string s = System.Text.Encoding.ASCII.GetString (buffer, offset, count);
            offset += count;
            return s;
        }

        public static int ReadInt (byte[] buffer, int offset)
        {
            return ReadInt (buffer, ref offset);
        }

        public static int ReadInt (byte[] buffer, ref int offset)
        {
            int ret = IPAddress.NetworkToHostOrder (BitConverter.ToInt32 (buffer, offset));
            offset += 4;
            return ret;
        }

        public static long ReadLong (byte[] buffer, int offset)
        {
            return ReadLong (buffer, ref offset);
        }

        public static long ReadLong (byte[] buffer, ref int offset)
        {
            long ret = IPAddress.NetworkToHostOrder (BitConverter.ToInt64 (buffer, offset));
            offset += 8;
            return ret;
        }

        public static int Write (byte[] buffer, int offset, byte value)
        {
            buffer[offset] = value;
            return 1;
        }

        public static int Write (byte[] dest, int destOffset, byte[] src, int srcOffset, int count)
        {
            Buffer.BlockCopy (src, srcOffset, dest, destOffset, count);
            return count;
        }

        public static int Write (byte[] buffer, int offset, ushort value)
        {
            buffer[offset + 0] = (byte) (value >> 8);
            buffer[offset + 1] = (byte) value;
            return 2;
        }

        public static int Write (byte[] buffer, int offset, short value)
        {
            buffer[offset + 0] = (byte) (value >> 8);
            buffer[offset + 1] = (byte) value;
            return 2;
        }
        public static int Write (byte[] buffer, int offset, int value)
        {
            buffer[offset + 0] = (byte) (value >> 24);
            buffer[offset + 1] = (byte) (value >> 16);
            buffer[offset + 2] = (byte) (value >> 8);
            buffer[offset + 3] = (byte) value;
            return 4;
        }

        public static int Write (byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte) (value >> 24);
            buffer[offset + 1] = (byte) (value >> 16);
            buffer[offset + 2] = (byte) (value >> 8);
            buffer[offset + 3] = (byte) value;
            return 4;
        }

        public static int Write (byte[] buffer, int offset, long value)
        {
            buffer[offset + 0] = (byte) (value >> 56);
            buffer[offset + 1] = (byte) (value >> 48);
            buffer[offset + 2] = (byte) (value >> 40);
            buffer[offset + 3] = (byte) (value >> 32);
            buffer[offset + 4] = (byte) (value >> 24);
            buffer[offset + 5] = (byte) (value >> 16);
            buffer[offset + 6] = (byte) (value >> 8);
            buffer[offset + 7] = (byte) value;
            return 8;
        }

        public static int Write (byte[] buffer, int offset, ulong value)
        {
            buffer[offset + 0] = (byte) (value >> 56);
            buffer[offset + 1] = (byte) (value >> 48);
            buffer[offset + 2] = (byte) (value >> 40);
            buffer[offset + 3] = (byte) (value >> 32);
            buffer[offset + 4] = (byte) (value >> 24);
            buffer[offset + 5] = (byte) (value >> 16);
            buffer[offset + 6] = (byte) (value >> 8);
            buffer[offset + 7] = (byte) value;
            return 8;
        }

        public static int Write (byte[] buffer, int offset, byte[] value)
        {
            return Write (buffer, offset, value, 0, value.Length);
        }

        public static int WriteAscii (byte[] buffer, int offset, string text)
        {
            for (int i = 0; i < text.Length; i++)
                buffer[offset + i] = (byte) text[i];
            return text.Length;
        }
    }
}