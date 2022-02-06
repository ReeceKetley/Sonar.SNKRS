using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Crypto
{
    private static string _ky = "varIjI18iQpWIWo77IfSBj9Pn23m79VZw0ZnDlXSUFM=";
    private static string _iv = "mVawTBrQvzz0nTkPiwO2ujlKvaCaLiH9qZVqxZkdUL0=";
    public static byte[] Decrypt(byte[] pwd, byte[] data)
    {
        return Encrypt(pwd, data);
    }

    public static string DecryptRJ256(string prm_text_to_decrypt)
    {
        string s = prm_text_to_decrypt;
        RijndaelManaged managed = new RijndaelManaged {
            Padding = PaddingMode.Zeros,
            Mode = CipherMode.CBC,
            KeySize = 0x100,
            BlockSize = 0x100
        };
        byte[] bytes = Convert.FromBase64String(_ky);
        byte[] rgbIV = Convert.FromBase64String(_iv);
        ICryptoTransform transform = managed.CreateDecryptor(bytes, rgbIV);
        byte[] buffer = Convert.FromBase64String(s);
        byte[] buffer4 = new byte[buffer.Length];
        MemoryStream stream = new MemoryStream(buffer);
        new CryptoStream(stream, transform, CryptoStreamMode.Read).Read(buffer4, 0, buffer4.Length);
        return Encoding.ASCII.GetString(buffer4);
    }

    public static byte[] Encrypt(byte[] pwd, byte[] data)
    {
        int num2;
        int num5;
        int[] numArray = new int[0x100];
        int[] numArray2 = new int[0x100];
        byte[] buffer = new byte[data.Length];
        for (num2 = 0; num2 < 0x100; num2++)
        {
            numArray[num2] = pwd[num2 % pwd.Length];
            numArray2[num2] = num2;
        }
        int index = num2 = 0;
        while (num2 < 0x100)
        {
            index = ((index + numArray2[num2]) + numArray[num2]) % 0x100;
            num5 = numArray2[num2];
            numArray2[num2] = numArray2[index];
            numArray2[index] = num5;
            num2++;
        }
        int num = index = num2 = 0;
        while (num2 < data.Length)
        {
            num++;
            num = num % 0x100;
            index += numArray2[num];
            index = index % 0x100;
            num5 = numArray2[num];
            numArray2[num] = numArray2[index];
            numArray2[index] = num5;
            int num4 = numArray2[(numArray2[num] + numArray2[index]) % 0x100];
            buffer[num2] = (byte) (data[num2] ^ num4);
            num2++;
        }
        return buffer;
    }

    public static string EncryptRJ256(string prm_text_to_encrypt)
    {
        string s = prm_text_to_encrypt;
        RijndaelManaged managed = new RijndaelManaged {
            Padding = PaddingMode.Zeros,
            Mode = CipherMode.CBC,
            KeySize = 0x100,
            BlockSize = 0x100
        };
        byte[] bytes = Convert.FromBase64String(_ky);
        byte[] rgbIV = Convert.FromBase64String(_iv);
        ICryptoTransform transform = managed.CreateEncryptor(bytes, rgbIV);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
        byte[] buffer = Encoding.ASCII.GetBytes(s);
        stream2.Write(buffer, 0, buffer.Length);
        stream2.FlushFinalBlock();
        return Convert.ToBase64String(stream.ToArray());
    }
}

