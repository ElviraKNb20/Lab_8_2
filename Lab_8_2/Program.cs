using System;
using System.IO;
using System.Text;

namespace Lab_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = "1.bin";
            string file2 = "2.bin";
            string file3 = "3.bin";
            string file4 = "4.bin";
            string file5 = "5.bin";
            void Add(string file)
            {
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Create))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Default))
                        {
                            Console.Write($"Запишiть дiйсне число у файл {file}: ");
                            double n = Convert.ToDouble(Console.ReadLine());
                            bw.Write(n);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void Read(string file)
            {
                try
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
                        {
                            double n = br.ReadDouble();
                            Console.WriteLine($"Число у файлi {file}: {n}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            void Exchange(string path1, string path2)
            {
                try
                {
                    if ((!File.Exists(path1) || !File.Exists(file2)) || !File.Exists(path1) && !File.Exists(file2))
                    {
                        Console.WriteLine($"Не iснує усiх потрiбних файлiв!!!");
                    }
                    else
                    {
                        string text = "";
                        double n = 0.0;
                        using (FileStream fs = new FileStream(path1, FileMode.Open))
                        {
                            using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
                            {
                                n = br.ReadDouble();
                            }
                        }

                        using (FileStream fs = new FileStream(path2, FileMode.Create))
                        {
                            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Default))
                            {
                                bw.Write(n);
                                Console.WriteLine($"Здiйснено обмiн мiж {path1} - ({n}) та {path2}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Add(file1);
            Add(file2);
            Console.WriteLine("Виконуємо обмiн:");
            Exchange(file1, file3);
            Exchange(file2, file4);
            Exchange(file3, file5);
            Exchange(file4, file2);
            Exchange(file5, file1);
            Console.WriteLine("Результати обмiну:");
            Read(file1);
            Read(file2);
        }
    }
}
