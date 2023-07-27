namespace SS_CS_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task7_1_1();
            // Task7_1_2();
            // Task7_2();
            Task7_3();

        }

        public static void Task7_1_1()
        {
            string sourcePath = "d:\\Repos\\SS_CS_Files\\data.txt";
            string destinationPath = "d:\\Repos\\SS_CS_Files\\rez.txt";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("The file does not exist");
                return;
            }

            string destFolder = Path.GetDirectoryName(sourcePath);

            if (!Directory.Exists(destFolder))
            {
                Console.WriteLine("The destination folder does not exist");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(sourcePath))
                {
                    string text = reader.ReadToEnd();

                    using (StreamWriter writer = new StreamWriter(destinationPath, false))
                    {
                        writer.Write(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Task7_1_2()
        {
            string sourcePath = "d:\\Repos\\SS_CS_Files\\data.txt";
            string destinationPath = "d:\\Repos\\SS_CS_Files\\rez.txt";

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("The file does not exist");
                return;
            }

            string destFolder = Path.GetDirectoryName(sourcePath);

            if (!Directory.Exists(destFolder))
            {
                Console.WriteLine("The destination folder does not exist");
                return;
            }

            try
            {
                string text = File.ReadAllText(sourcePath);

                File.WriteAllText(destinationPath, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void Task7_2()
        {
            string dRoot = "D:\\";
            string destination = "D:\\DriveD.txt";

            try
            {
                string[] entries = Directory.GetFileSystemEntries(dRoot);

                using (StreamWriter writer = new StreamWriter(destination))
                {
                    foreach (string entry in entries)
                    {
                        if (File.Exists(entry))
                        {
                            FileInfo info = new FileInfo(entry);

                            if (info.Attributes.HasFlag(FileAttributes.Hidden))
                            {
                                continue;
                            }
                            writer.WriteLine($"File {info.Name} has extention: {info.Extension}, size: {info.Length}B");
                        }
                        else if (Directory.Exists(entry))
                        {
                            DirectoryInfo info = new DirectoryInfo(entry);

                            if (info.Attributes.HasFlag(FileAttributes.Hidden))
                            {
                                continue;
                            }
                            writer.WriteLine($"Directory {info.Name}, size: {DirSize(info)}B");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static long DirSize(DirectoryInfo dir)
        {
            return dir.GetFiles().Sum(fi => fi.Length) +
                   dir.GetDirectories().Sum(di => DirSize(di));
        }

        public static void Task7_3()
        {
            string dRoot = "D:\\";
            try
            {
                string[] files = Directory.GetFiles(dRoot, "*.txt");
                foreach (string file in files)
                {
                    Console.WriteLine(File.ReadAllText(file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}