﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SelectedFilesDetails", Namespace="http://schemas.datacontract.org/2004/07/BasicWCF.Required_Classes")]
    [System.SerializableAttribute()]
    public partial class SelectedFilesDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WindowsFormsApplication1.ServiceReference1.Words[] searchedWordsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileLocation {
            get {
                return this.FileLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.FileLocationField, value) != true)) {
                    this.FileLocationField = value;
                    this.RaisePropertyChanged("FileLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WindowsFormsApplication1.ServiceReference1.Words[] searchedWords {
            get {
                return this.searchedWordsField;
            }
            set {
                if ((object.ReferenceEquals(this.searchedWordsField, value) != true)) {
                    this.searchedWordsField = value;
                    this.RaisePropertyChanged("searchedWords");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Words", Namespace="http://schemas.datacontract.org/2004/07/BasicWCF.Required_Classes")]
    [System.SerializableAttribute()]
    public partial class Words : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int countField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string wordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int count {
            get {
                return this.countField;
            }
            set {
                if ((this.countField.Equals(value) != true)) {
                    this.countField = value;
                    this.RaisePropertyChanged("count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string word {
            get {
                return this.wordField;
            }
            set {
                if ((object.ReferenceEquals(this.wordField, value) != true)) {
                    this.wordField = value;
                    this.RaisePropertyChanged("word");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IFileUploader")]
    public interface IFileUploader {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileUploader/StoreTheFile", ReplyAction="http://tempuri.org/IFileUploader/StoreTheFileResponse")]
        void StoreTheFile(System.IO.FileInfo composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileUploader/StoreTheFile", ReplyAction="http://tempuri.org/IFileUploader/StoreTheFileResponse")]
        System.Threading.Tasks.Task StoreTheFileAsync(System.IO.FileInfo composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileUploader/RetrieveFile", ReplyAction="http://tempuri.org/IFileUploader/RetrieveFileResponse")]
        WindowsFormsApplication1.ServiceReference1.SelectedFilesDetails[] RetrieveFile(string[] Words);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileUploader/RetrieveFile", ReplyAction="http://tempuri.org/IFileUploader/RetrieveFileResponse")]
        System.Threading.Tasks.Task<WindowsFormsApplication1.ServiceReference1.SelectedFilesDetails[]> RetrieveFileAsync(string[] Words);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileUploaderChannel : WindowsFormsApplication1.ServiceReference1.IFileUploader, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileUploaderClient : System.ServiceModel.ClientBase<WindowsFormsApplication1.ServiceReference1.IFileUploader>, WindowsFormsApplication1.ServiceReference1.IFileUploader {
        
        public FileUploaderClient() {
        }
        
        public FileUploaderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileUploaderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileUploaderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileUploaderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void StoreTheFile(System.IO.FileInfo composite) {
            base.Channel.StoreTheFile(composite);
        }
        
        public System.Threading.Tasks.Task StoreTheFileAsync(System.IO.FileInfo composite) {
            return base.Channel.StoreTheFileAsync(composite);
        }
        
        public WindowsFormsApplication1.ServiceReference1.SelectedFilesDetails[] RetrieveFile(string[] Words) {
            return base.Channel.RetrieveFile(Words);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApplication1.ServiceReference1.SelectedFilesDetails[]> RetrieveFileAsync(string[] Words) {
            return base.Channel.RetrieveFileAsync(Words);
        }
    }
}