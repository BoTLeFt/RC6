using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RC6_1
{   
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class RC6
        {
            // Константы для операций сдвига
            public const int W = 32;
            public const int R = 16;

            // Переменные для файлов
            public Byte[] File;
            public uint FileLen;

            // Список итоговых данных
            public List<Byte> Result = new List<Byte>();

            // Сдвиг вправо
            public UInt32 ShiftR(UInt32 z_value, int z_shift)
            {
                return ((z_value >> z_shift) | (z_value << (W - z_shift)));
            }

            // Сдвиг влево
            public UInt32 ShiftL(UInt32 z_value, int z_shift)
            {
                return ((z_value << z_shift) | (z_value >> (W - z_shift)));
            }

            // Определения числа сдвигов
            public int CountOfShift(int TVar)
            {
                int Lg = (int)(Math.Log((double)W) / Math.Log(2.0));

                TVar = TVar << (W - Lg);
                TVar = TVar >> (W - Lg);

                return TVar;
            }

            // Генерации ключа
            public void Generator(UInt32 TKey)
            {
                UInt32 P32 = 0xB7E15163;
                UInt32 Q32 = 0x9E3779B9;
                UInt32 i, A, B;
                UInt32 ByteOne, ByteTwo, ByteThree, ByteFour;

                ByteOne = TKey >> 24;
                ByteTwo = TKey >> 8;
                ByteTwo = ByteTwo & 0x0010;
                ByteThree = TKey << 8;
                ByteThree = ByteThree & 0x0100;
                ByteFour = TKey << 24;

                TKey = ByteOne | ByteTwo | ByteThree | ByteFour;

                key[0] = P32;

                for (i = 1; i < 2 * R + 4; i++)
                    key[i] = key[i - 1] + Q32;

                i = A = B = 0;

                int v = 3 * Math.Max(1, 2 * R + 4);

                for (int s = 1; s <= v; s++)
                {
                    A = key[i] = ShiftL(key[i] + A + B, CountOfShift(3));
                    B = TKey = ShiftL(TKey + A + B, CountOfShift((int)(A + B)));

                    i = (i + 1) % (2 * R + 4);
                }
            }

            // Пеобразования массива UInt32 к списку байт
            public void ConvertFromUInt32ToByteArray(UInt32[] array)
            {
                List<byte> results = new List<byte>();
                Result.Clear();

                foreach (UInt32 value in array)
                {
                    byte[] converted = BitConverter.GetBytes(value);
                    results.AddRange(converted);
                }

                // Формирование списка зашифрованных / расшифрванных байт данных
                Result.AddRange(results);
            }

            // Преобразования массива байт в массив UInt32
            public UInt32[] ConvertFromByteArrayToUIn32(byte[] array, int position)
            {
                List<UInt32> results = new List<UInt32>();
                int length = position + 16;            // Размер блока конвертируемых данных. Читаем по 16 байт.

                for (int i = position; i < length; i += 4)
                {
                    byte[] temp = new byte[4];

                    for (int j = 0; j < 4; ++j)
                    {
                        if (i + j < array.Length)
                            temp[j] = array[i + j];
                        else
                            temp[j] = 0x00;         // заполняем недостающие блоки в случае достижения конца файла
                    }

                    results.Add(BitConverter.ToUInt32(temp, 0));
                }

                return results.ToArray();
            }

            // Расшифровка
            public void Decode()
            {
                UInt32[] Temp;

                for (int i = 0; i < FileLen; i += 16)
                {
                    Temp = ConvertFromByteArrayToUIn32(File, i);

                    Temp[1] = (Temp[1] + key[0]);
                    Temp[3] = (Temp[3] + key[1]);

                    for (int j = 1; j <= R; j++)
                    {
                        UInt32 t = ShiftL((Temp[1] * (2 * Temp[1] + 1)),
                                            CountOfShift((int)(Math.Log((double)W) / Math.Log(2.0))));
                        UInt32 u = ShiftL((Temp[3] * (2 * Temp[3] + 1)),
                                            CountOfShift((int)(Math.Log((double)W) / Math.Log(2.0))));

                        Temp[0] = (ShiftL(Temp[0] ^ t, CountOfShift((int)u)) + key[2 * j]);
                        Temp[2] = (ShiftL(Temp[2] ^ u, CountOfShift((int)t)) + key[2 * j + 1]);

                        UInt32 temp = Temp[0];
                        Temp[0] = Temp[1];
                        Temp[1] = Temp[2];
                        Temp[2] = Temp[3];
                        Temp[3] = temp;
                    }

                    Temp[0] = (Temp[0] + key[2 * R + 2]);
                    Temp[2] = (Temp[2] + key[2 * R + 3]);

                    ConvertFromUInt32ToByteArray(Temp);                 // Конвертируем в выходной массив расшифрованных данных
                }

                Temp = null;
            }

            // Шифрование
            public void Encode()
            {
                UInt32[] TTemp;

                for (int i = 0; i < FileLen; i += 16)
                {
                    TTemp = ConvertFromByteArrayToUIn32(File, i);

                    TTemp[0] = (TTemp[0] - key[2 * R + 2]);
                    TTemp[2] = (TTemp[2] - key[2 * R + 3]);

                    for (int j = R; j >= 1; j--)
                    {
                        UInt32 temp = TTemp[3];
                        TTemp[3] = TTemp[2];
                        TTemp[2] = TTemp[1];
                        TTemp[1] = TTemp[0];
                        TTemp[0] = temp;

                        UInt32 t = ShiftL((TTemp[1] * (2 * TTemp[1] + 1)),
                                            CountOfShift((int)(Math.Log((double)W) / Math.Log(2.0))));
                        UInt32 u = ShiftL((TTemp[3] * (2 * TTemp[3] + 1)),
                                            CountOfShift((int)(Math.Log((double)W) / Math.Log(2.0))));

                        TTemp[0] = (ShiftR((TTemp[0] - key[2 * j]), CountOfShift((int)u))) ^ t;
                        TTemp[2] = (ShiftR((TTemp[2] - key[2 * j + 1]), CountOfShift((int)t))) ^ u;
                    }

                    TTemp[1] = (TTemp[1] - key[0]);
                    TTemp[3] = (TTemp[3] - key[1]);

                    ConvertFromUInt32ToByteArray(TTemp);          // Конвертируем в выходной массив зашифрованных данных
                }

                TTemp = null;
            }
            // Ключ
            public UInt32[] key = new UInt32[2 * R + 4];
        }
        public void EncryptButton_Click(object sender, EventArgs e)
        {
            var ob = new RC6();
            UInt32 key = UInt32.Parse(TextBoxKey.Text);
            ob.File = System.Text.Encoding.Default.GetBytes(TextBoxOpenText.Text); // Чтение шифруемых данных
            ob.FileLen = (uint)ob.File.Length;
            ob.Generator((UInt32)key);        // формирование ключа
            ob.Encode();                              // шифрование
            TextBoxCrypted.Text = System.Text.Encoding.Default.GetString(ob.Result.ToArray()); //Вывод на экран зашифрованных данных
        }

        public void DecryptButton_Click(object sender, EventArgs e)
        {
            var ob = new RC6();
            UInt32 key = UInt32.Parse(TextBoxKey.Text);
            ob.File = System.Text.Encoding.Default.GetBytes(TextBoxCrypted.Text); //Подготовка данных к расшифрованию
            ob.FileLen = (uint)ob.File.Length;
            ob.Generator((UInt32)key);
            ob.Decode();    // расшифрование
            TextBoxOpenText.Text = System.Text.Encoding.Default.GetString(ob.Result.ToArray()); //Вывод на экран расшифрованных данных
        }


    }
}
