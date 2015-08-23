using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Runtime.Serialization.Json;
//using System.Web.Script.Serialization;
//using Newtonsoft.Json;
using Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileInfo fi;
        private void Form1_Load(object sender, EventArgs e)
        {
            fi = new FileInfo(@"C:\Users\Shivateja\Desktop\cover.txt");
            ////////////////This method call is to check the WCF Service
            ServiceReference1.FileUploaderClient client = new ServiceReference1.FileUploaderClient();
            ////////////////String[] str = { "american", "2006" };
            client.StoreTheFile(fi);

            //This method call is to check Search Ability
            //For test 1 : I am giving the words from one file, Sprite.json
            //String[] str = { "american", "2006" };
            //FindTheFile(str);


            //////////////////This method call is to store the file
            //if (fi.Length > 0)
            //{
            //    StreamReader sr = fi.OpenText();
            //    //Hashtable returnht = NewMethod(sr.ReadToEnd());

            //}

        }

        private Hashtable NewMethod(String v)
        {

            // 1
            // Keep track of words found in this Dictionary.
            var d = new Dictionary<string, bool>();
            Hashtable ht = new Hashtable();
            List<words> _data = new List<words>();
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
                words _word = new words();
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

        private string AddingtoJsonFile(List<words> Words, List<FileDetails> FileDetails)
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
            // path To Save JSon Files with File name
            String Path = @"D:\C# Practice\New Project\ClassLibrary1\json files\" + FileName;
            Path = Path.Replace(".txt", ".json");
            System.IO.File.WriteAllText(Path, FileJsonData);
        }


        /// <summary>
        /// Here I am trying to implement the find for the words in the bunch of files we have
        /// if we have couple of words, all the words will be saved in a string array, by accessing each string
        /// that string(word) will be searched in the json files (by accessing each json at a time)
        /// The basic idea : when the word is found, according to the word count the files will be prioritized.
        /// </summary>
        /// <param name="searchWords"></param>
        private void FindTheFile(String[] searchWords)
        {
            try
            {
                SelectedFileDetails selectedFile;
                List<SelectedFileDetails> selectedFilesList = new List<SelectedFileDetails>();
                //this is the path where all of the json files will be stored
                String Path = @"D:\C# Practice\New Project\ClassLibrary1\json files\";
                // All the files will be saved in the files array and each file will be processed to find the word
                string[] files = System.IO.Directory.GetFiles(Path, "*.json");
                for (int i = 0; i < files.Count(); i++)
                {
                    String FileData = System.IO.File.ReadAllText(files[i]);
                    // This method is called, which is below
                    //for (int j = 0; j < searchWords.Count(); j++)
                    //{
                    selectedFile = ReadtheFile(FileData, searchWords);
                    if (selectedFile != null)
                    {
                        selectedFilesList.Add(selectedFile);
                    }
                    // }
                }
            }
            catch (Exception e)
            {
                //Write your exceptions here
            }
        }

        /// <summary>
        /// This Method is to process the json string and find the words.
        /// </summary>
        /// <param name="jSonData"></param>
        private SelectedFileDetails ReadtheFile(string jSonData, String[] SearchWords)
        {
            try
            {
                //As per "http://stackoverflow.com/questions/3152157/find-a-file-with-a-certain-extension-in-folder"
                // the below reader object will give an option of reading the json data by calling each value

                SelectedFileDetails selectedFile = new SelectedFileDetails();
                words selectedWords = null;
                List<words> lstsearchedWords = new List<words>();
                String[] Splitstrngs = jSonData.Split(new Char[] { '{', '}' });

                jSonData = jSonData.Replace("{" + Splitstrngs[1] + "}", "");

                List<words> val = JsonConvert.DeserializeObject<List<words>>(jSonData);

                //"FileLocation":"D:\\RESUME and JOB STUFF\\Random.txt","UpdatedDate":"2015-03-12T13:13:29.525296-07:00","FileSize":721,"FileType":".txt"

                List<FileDetails> val1 = JsonConvert.DeserializeObject<List<FileDetails>>("[{" + Splitstrngs[1] + "}]");
                selectedFile.FileLocation = val1[0].FileLocation;

                for (int i = 0; i < val.Count(); i++)
                {
                    for (int j = 0; j < SearchWords.Count(); j++)
                    {
                        if (val[i].word == SearchWords[j])
                        {
                            selectedWords = new words();
                            selectedWords.word = SearchWords[j];
                            selectedWords.count = val[i].count;
                            lstsearchedWords.Add(selectedWords);
                        }
                    }
                }
                //selectedFile.searchedWords list = new selectedFile.searchedWords();
                
                selectedFile.searchedWords = lstsearchedWords;
                return selectedFile;
            }
            catch (Exception e)
            {
                // Write the exception here
                return null;
            }
        }


    }


    public class words
    {
        public string word { get; set; }
        public int count { get; set; }
    }

    public class FileDetails
    {
        public string FileLocation { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        //public int FileSize { get; set; }
    }

    public class SelectedFileDetails
    {
        public string FileLocation { get; set; }
        //public string FileName { get; set; }
        public List<words> searchedWords { get; set; }
    }

}
