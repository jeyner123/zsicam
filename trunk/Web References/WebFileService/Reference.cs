﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3615.
// 
#pragma warning disable 1591

namespace zsi.PhotoFingCapture.WebFileService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebFileManagerSoap", Namespace="http://tempuri.org/police-records/WebFileServices")]
    public partial class WebFileManager : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback UploadBiometricsDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserTempProfileIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProfileInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback UploadFileOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserIdOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebFileManager() {
            this.Url = Util.GetWebServiceURL;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event UploadBiometricsDataCompletedEventHandler UploadBiometricsDataCompleted;
        
        /// <remarks/>
        public event GetUserTempProfileIdCompletedEventHandler GetUserTempProfileIdCompleted;
        
        /// <remarks/>
        public event GetProfileInfoCompletedEventHandler GetProfileInfoCompleted;
        
        /// <remarks/>
        public event UploadFileCompletedEventHandler UploadFileCompleted;
        
        /// <remarks/>
        public event GetUserIdCompletedEventHandler GetUserIdCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/police-records/WebFileServices/UploadBiometricsData", RequestNamespace="http://tempuri.org/police-records/WebFileServices", ResponseNamespace="http://tempuri.org/police-records/WebFileServices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UploadBiometricsData(string UserId, string FileName, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] Data) {
            object[] results = this.Invoke("UploadBiometricsData", new object[] {
                        UserId,
                        FileName,
                        Data});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UploadBiometricsDataAsync(string UserId, string FileName, byte[] Data) {
            this.UploadBiometricsDataAsync(UserId, FileName, Data, null);
        }
        
        /// <remarks/>
        public void UploadBiometricsDataAsync(string UserId, string FileName, byte[] Data, object userState) {
            if ((this.UploadBiometricsDataOperationCompleted == null)) {
                this.UploadBiometricsDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadBiometricsDataOperationCompleted);
            }
            this.InvokeAsync("UploadBiometricsData", new object[] {
                        UserId,
                        FileName,
                        Data}, this.UploadBiometricsDataOperationCompleted, userState);
        }
        
        private void OnUploadBiometricsDataOperationCompleted(object arg) {
            if ((this.UploadBiometricsDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadBiometricsDataCompleted(this, new UploadBiometricsDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/police-records/WebFileServices/GetUserTempProfileId", RequestNamespace="http://tempuri.org/police-records/WebFileServices", ResponseNamespace="http://tempuri.org/police-records/WebFileServices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserTempProfileId(int UserId) {
            object[] results = this.Invoke("GetUserTempProfileId", new object[] {
                        UserId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserTempProfileIdAsync(int UserId) {
            this.GetUserTempProfileIdAsync(UserId, null);
        }
        
        /// <remarks/>
        public void GetUserTempProfileIdAsync(int UserId, object userState) {
            if ((this.GetUserTempProfileIdOperationCompleted == null)) {
                this.GetUserTempProfileIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserTempProfileIdOperationCompleted);
            }
            this.InvokeAsync("GetUserTempProfileId", new object[] {
                        UserId}, this.GetUserTempProfileIdOperationCompleted, userState);
        }
        
        private void OnGetUserTempProfileIdOperationCompleted(object arg) {
            if ((this.GetUserTempProfileIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserTempProfileIdCompleted(this, new GetUserTempProfileIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/police-records/WebFileServices/GetProfileInfo", RequestNamespace="http://tempuri.org/police-records/WebFileServices", ResponseNamespace="http://tempuri.org/police-records/WebFileServices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetProfileInfo(string UserId, string ProfileId) {
            object[] results = this.Invoke("GetProfileInfo", new object[] {
                        UserId,
                        ProfileId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetProfileInfoAsync(string UserId, string ProfileId) {
            this.GetProfileInfoAsync(UserId, ProfileId, null);
        }
        
        /// <remarks/>
        public void GetProfileInfoAsync(string UserId, string ProfileId, object userState) {
            if ((this.GetProfileInfoOperationCompleted == null)) {
                this.GetProfileInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProfileInfoOperationCompleted);
            }
            this.InvokeAsync("GetProfileInfo", new object[] {
                        UserId,
                        ProfileId}, this.GetProfileInfoOperationCompleted, userState);
        }
        
        private void OnGetProfileInfoOperationCompleted(object arg) {
            if ((this.GetProfileInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProfileInfoCompleted(this, new GetProfileInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/police-records/WebFileServices/UploadFile", RequestNamespace="http://tempuri.org/police-records/WebFileServices", ResponseNamespace="http://tempuri.org/police-records/WebFileServices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UploadFile(string strUserId, string strFileName, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] objFile) {
            object[] results = this.Invoke("UploadFile", new object[] {
                        strUserId,
                        strFileName,
                        objFile});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UploadFileAsync(string strUserId, string strFileName, byte[] objFile) {
            this.UploadFileAsync(strUserId, strFileName, objFile, null);
        }
        
        /// <remarks/>
        public void UploadFileAsync(string strUserId, string strFileName, byte[] objFile, object userState) {
            if ((this.UploadFileOperationCompleted == null)) {
                this.UploadFileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUploadFileOperationCompleted);
            }
            this.InvokeAsync("UploadFile", new object[] {
                        strUserId,
                        strFileName,
                        objFile}, this.UploadFileOperationCompleted, userState);
        }
        
        private void OnUploadFileOperationCompleted(object arg) {
            if ((this.UploadFileCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UploadFileCompleted(this, new UploadFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/police-records/WebFileServices/GetUserId", RequestNamespace="http://tempuri.org/police-records/WebFileServices", ResponseNamespace="http://tempuri.org/police-records/WebFileServices", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetUserId(string UserName, string Password) {
            object[] results = this.Invoke("GetUserId", new object[] {
                        UserName,
                        Password});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserIdAsync(string UserName, string Password) {
            this.GetUserIdAsync(UserName, Password, null);
        }
        
        /// <remarks/>
        public void GetUserIdAsync(string UserName, string Password, object userState) {
            if ((this.GetUserIdOperationCompleted == null)) {
                this.GetUserIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserIdOperationCompleted);
            }
            this.InvokeAsync("GetUserId", new object[] {
                        UserName,
                        Password}, this.GetUserIdOperationCompleted, userState);
        }
        
        private void OnGetUserIdOperationCompleted(object arg) {
            if ((this.GetUserIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserIdCompleted(this, new GetUserIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void UploadBiometricsDataCompletedEventHandler(object sender, UploadBiometricsDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadBiometricsDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadBiometricsDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetUserTempProfileIdCompletedEventHandler(object sender, GetUserTempProfileIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserTempProfileIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserTempProfileIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetProfileInfoCompletedEventHandler(object sender, GetProfileInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProfileInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProfileInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void UploadFileCompletedEventHandler(object sender, UploadFileCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UploadFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UploadFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void GetUserIdCompletedEventHandler(object sender, GetUserIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591