using BasicWCF.Required_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BasicWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFileUploader
    {
        [OperationContract]
        void StoreTheFile(FileInfo composite);

        [OperationContract]
        List<SelectedFilesDetails> RetrieveFile(string[] Words);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ClassType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

     [DataContract]
    public class FileData
    {
        bool boolValue = true;
        string stringValue = "Hello ";
         string filelocation, filetype;
         DateTime FileLastUpdated;
         long FileSize;
         string[] words;

        [DataMember]
        public string FileLocation
        {
            get { return filelocation; }
            set { filelocation = value; }
        }

        [DataMember]
        public string FileType
        {
            get { return filetype; }
            set { filetype = value; }
        }

         [DataMember]
        public DateTime LastUpdated
        {
            get { return FileLastUpdated; }
            set { FileLastUpdated = value; }
        }

         [DataMember]
        public long SizeOftheFile
        {
            get { return FileSize; }
            set { FileSize = value; }
        }

         [DataMember]
        public String[] Words
        {
            get { return words; }
            set { words = value; }
        }
    }
}
