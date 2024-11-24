using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesDirectories
{
    public class Source
    {
        public void GetFilesFoldersDirectory() 
        {
            #region collect all files and folders from given special folder

            //getting desktop path C:\Users\arunk\OneDrive\Desktop
            string mainFolder =Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //Gets all sub folders in all levels
            List<string> folders = Directory.GetDirectories(mainFolder, "*.*", SearchOption.AllDirectories).ToList();

            //Gets all files from all sub folders in all levels
            List<string> files = Directory.GetFiles(mainFolder, "*.*", SearchOption.AllDirectories).ToList();

            //Console.WriteLine($"No of folders: {folders.Count}");
            //Console.WriteLine($"No of files: {files.Count}");

            #endregion

            
            #region Get specific file
            //Gets current working directory
            //C:\Users\arunk\source\repos\FilesDirectories\FilesDirectories\bin\Debug
            string folderPath =Directory.GetCurrentDirectory();

            //checks weather the directory exists or not
            bool checkForDirectory=Directory.Exists(folderPath);

            //Combines multiple stings and store it in a single path
            //C:\Users\arunk\OneDrive\Desktop\aravind bio.xlsx
            string filePath = Path.Combine(mainFolder, "aravind bio.xlsx");

            //Gives the location of our executing file
            //C:\Users\arunk\source\repos\FilesDirectories\FilesDirectories\bin\Debug
            folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //Will give combined path,here we have added @"\" or "\\" to the path explicitly,
            //But Path.Combine will implicitly add \ to the path
            filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\Test.xlsx";

            //Getting specific files from a directory with search keyword
            List<string> specificFiles=Directory.GetFiles(mainFolder,"*.prt",SearchOption.TopDirectoryOnly).ToList();

            //will take SearchOption.TopDirectoryOnly as default if we do not mention any search option
            specificFiles = Directory.GetFiles(mainFolder, "*.xlsx").ToList();

            #endregion


            #region creating and deleting a directory
            //Folder Path in desktop
            string folder = Path.Combine(mainFolder, "FileManagerPractice");

            //if fiven folder does not exists create folder
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                Console.WriteLine($"{folder} directory created..");
            }

            //if the folder already exist delete it
            else
            {
                Console.WriteLine($"Directory {folder} Exists");

                //Give true if you want to delete subfolders and files in that given folder
                Directory.Delete(folder, true);
                Console.WriteLine($"Directory {folder} Deleted");

            }
            #endregion


            #region deleting a file

            if(File.Exists(filePath))
            {
                Console.WriteLine($"File exists {filePath}");
                //Give file path along with file name and file extension
                File.Delete(filePath);
                Console.WriteLine($"File Deleted {filePath} Deleted");
            }
            else
            {
                Console.WriteLine($"File doesnot exist: {filePath}");
                File.Create(filePath);
                Console.WriteLine($"File Created: {filePath}");
            }
            #endregion
        }

        public void ExcelOpp()
        {

        }

        private static bool IsFileOpen(string path)
        {
            try
            {
                File.Open(path,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                System.IO.File.Open(path, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None).Close();
                return false;
            }
            catch (System.IO.IOException)
            {
                return true;
            }
        }
    }
}
