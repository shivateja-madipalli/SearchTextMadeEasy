using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using WindowsAppForSearchingWords;
using BasicWCF.Required_Classes;
using System.Windows.Forms;

namespace BasicWCF
{
    public class FileUploader : IFileUploader
    {
        FileInfo fi;
        String FileExtention;
        void IFileUploader.StoreTheFile(FileInfo composite)
        {
            //This is the initial state of the service
            try
            {
                if (composite != null)
                {
                    fi = composite;
                    StreamReader sr = fi.OpenText();
                    Hashtable returnht = WholeProcess(sr.ReadToEnd());

                    //throw new ArgumentNullException("composite");
                }
                ClassType ct = new ClassType();

            }
            catch (Exception e)
            {
                //throw the error message

            }
        }

        private Hashtable WholeProcess(String v)
        {
            try
            {               
                Hashtable ht = new Hashtable();
                List<Words> _data = new List<Words>();
                // 2
                // Build up string into this StringBuilder.
                StringBuilder b = new StringBuilder();

                // 3
                // Split the input and handle spaces and punctuation.
                string[] a = v.Split(new char[] { ' ', ',', ';', '.' },
                    StringSplitOptions.RemoveEmptyEntries);

                // 4
                // Loop over each word
                int i = 1;
                foreach (string current in a)
                {
                    // 5
                    // Lowercase each word
                    string lower = current.ToLower();
                    Words _word = new Words();
                    _word.word = lower;
                    if (ht.ContainsKey(lower))
                    {
                        int value = (int)ht[lower];
                        _word = _data.Find(x => x.word == lower);
                        ht[lower] = value + 1;
                        _word.count = value + 1;
                    }
                    else
                    {
                        ht.Add(lower, i);
                        _word.word = lower;
                        _word.count = i;
                        _data.Add(_word);

                    }
                }

                List<FileDetails> _filedetails = new List<FileDetails>();
                FileDetails _fileDetailsClass = new FileDetails();
                _fileDetailsClass.FileLocation = fi.FullName;
                _fileDetailsClass.UpdatedDate = fi.LastWriteTime;
                _fileDetailsClass.FileSize = fi.Length;
                _fileDetailsClass.FileType = fi.Extension;
                
                _filedetails.Add(_fileDetailsClass);
                SavingTheFile(fi.Name, AddingtoJsonFile(_data, _filedetails));
                return null;
            }
            catch(Exception e)
            {
                //catch the error here
                return null;
            }
        }

        private string AddingtoJsonFile(List<Words> Words, List<FileDetails> FileDetails)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Words.ToArray());
                string jsonFileDetails = JsonConvert.SerializeObject(FileDetails.ToArray());
                jsonFileDetails = jsonFileDetails.Substring(0, jsonFileDetails.Length - 1);
                json = json.Substring(1, json.Length - 1);
                jsonFileDetails = jsonFileDetails + json;
                return jsonFileDetails;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private void SavingTheFile(String FileName, String FileJsonData)
        {
            try
            {
                string Path = ConfigurationManager.AppSettings["JsonFileStorageLocation"].ToString();

                //Path to store the json files should be taken from config file
                Path = Path + FileName;
                Path = Path.Replace(fi.Extension, ".json"); // Need to implement = "REPLACE THE EXTENTION WITH JSON"
                System.IO.File.WriteAllText(Path, FileJsonData);
                //CallTheSearchBoxForm();
            }
            catch(Exception e)
            {
                //Catch the error here
            }
        }
        
        private void CallTheSearchBoxForm()
        {
            try
            {
                //WindowsAppForSearchingWords.SearchBoxForm searchbox = new SearchBoxForm();
                //searchbox.Show();

                WindowsAppForSearchingWords.Program.Main();


                //WindowsAppForSearchingWords.Program.Main();
                //prg.

                //SearchBoxForm searchForm = new SearchBoxForm();

                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new SearchBoxForm());
                
            }
            catch(Exception e)
            {
                //write the exception here
            }
        }

        // <summary>
        /// Here I am trying to implement the find for the words in the bunch of files we have
        /// if we have couple of words, all the words will be saved in a string array, by accessing each string
        /// that string(word) will be searched in the json files (by accessing each json at a time)
        /// The basic idea : when the word is found, according to the word count the files will be prioritized.
        /// </summary>
        /// <param name="searchWords"></param>
        public List<SelectedFilesDetails> RetrieveFile(string[] Words)
        {
            try
            {
                SelectedFilesDetails selectedFile;
                List<SelectedFilesDetails> selectedFilesList = new List<SelectedFilesDetails>();
                //this is the path where all of the json files will be stored
                string Path = ConfigurationManager.AppSettings["JsonFileStorageLocation"].ToString();
                //String Path = @"D:\C# Practice\New Project\ClassLibrary1\json files\";
                // All the files will be saved in the files array and each file will be processed to find the word
                string[] files = System.IO.Directory.GetFiles(Path, "*.json");
                for (int i = 0; i < files.Count(); i++)
                {
                    String FileData = System.IO.File.ReadAllText(files[i]);
                    // This method is called, which is below
                    //for (int j = 0; j < searchWords.Count(); j++)
                    //{
                    selectedFile = ReadtheFile(FileData, Words);
                    if (selectedFile.FileLocation != null || selectedFile.searchedWords.Count != 0 )
                    {
                        selectedFilesList.Add(selectedFile);
                    }
                    // }
                }
                return selectedFilesList;
            }
            catch (Exception e)
            {
                //Write your exceptions here
                //throw new NotImplementedException();
                return null;
            }
            
        }
        
        
        /// <summary>
        /// This Method is to process the json string and find the words.
        /// </summary>
        /// <param name="jSonData"></param>
        private SelectedFilesDetails ReadtheFile(string jSonData, String[] SearchWords)
        {
            try
            {
                //As per "http://stackoverflow.com/questions/3152157/find-a-file-with-a-certain-extension-in-folder"
                // the below reader object will give an option of reading the json data by calling each value

                SelectedFilesDetails selectedFile = new SelectedFilesDetails();
                Words selectedWords = null;
                List<Words> lstsearchedWords = new List<Words>();
                String[] Splitstrngs = jSonData.Split(new Char[] { '{', '}' });

                jSonData = jSonData.Replace("{" + Splitstrngs[1] + "}", "");

                List<Words> val = JsonConvert.DeserializeObject<List<Words>>(jSonData);

                //"FileLocation":"D:\\RESUME and JOB STUFF\\Random.txt","UpdatedDate":"2015-03-12T13:13:29.525296-07:00","FileSize":721,"FileType":".txt"

                List<FileDetails> val1 = JsonConvert.DeserializeObject<List<FileDetails>>("[{" + Splitstrngs[1] + "}]");
                

                for (int i = 0; i < val.Count(); i++)
                {
                    for (int j = 0; j < SearchWords.Count(); j++)
                    {
                        if (val[i].word == SearchWords[j])
                        {
                            selectedWords = new Words();
                            selectedWords.word = SearchWords[j];
                            selectedWords.count = val[i].count;
                            lstsearchedWords.Add(selectedWords);
                        }
                    }
                }
                //selectedFile.searchedWords list = new selectedFile.searchedWords();

                selectedFile.searchedWords = lstsearchedWords;
                if (selectedFile.searchedWords.Count != 0)
                {
                    selectedFile.FileLocation = val1[0].FileLocation;
                }
                return selectedFile;
            }
            catch (Exception e)
            {
                // Write the exception here
                return null;
            }
        }


    }
}
