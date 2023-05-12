namespace DeleteFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if( args.Length < 2 )
            {
                Console.WriteLine("Incorrect usage of method");
                Console.WriteLine("Correct variant: DeleteFiles <path_to_folder> <file_type> [<file_type> ...]");
                return;
            }

            string folder = args[0];
            string[] fileTypes = new string[args.Length-1];
            Array.Copy(args, 1, fileTypes, 0, fileTypes.Length);

            try
            {
                DeleteFiles(folder, fileTypes);
                Console.WriteLine("Deleting completed!");
                Environment.Exit(0);
            }
            catch(Exception ex )
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

        }

        static void DeleteFiles(string folder, string[] fileTypes)
        { 
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            if(!directoryInfo.Exists) 
                throw new DirectoryNotFoundException(folder);
            

            foreach (string fileType in fileTypes)
            {
                FileInfo[] fileInfo = directoryInfo.GetFiles("*."+fileType);

                foreach (FileInfo file in fileInfo)
                {
                    file.Delete();
                    Console.WriteLine("File deleted: " + file.FullName);
                }
            }
        }
    }
}