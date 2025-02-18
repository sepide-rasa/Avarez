﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Avarez.Saman_New {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PaymentIFBindingSoap", Namespace="urn:Foo")]
    public partial class PaymentIFBinding : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback verifyTransactionOperationCompleted;
        
        private System.Threading.SendOrPostCallback verifyTransaction1OperationCompleted;
        
        private System.Threading.SendOrPostCallback reverseTransactionOperationCompleted;
        
        private System.Threading.SendOrPostCallback reverseTransaction1OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PaymentIFBinding() {
            this.Url = global::Avarez.Properties.Settings.Default.Avarez_Saman_New_PaymentIFBinding;
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
        public event verifyTransactionCompletedEventHandler verifyTransactionCompleted;
        
        /// <remarks/>
        public event verifyTransaction1CompletedEventHandler verifyTransaction1Completed;
        
        /// <remarks/>
        public event reverseTransactionCompletedEventHandler reverseTransactionCompleted;
        
        /// <remarks/>
        public event reverseTransaction1CompletedEventHandler reverseTransaction1Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("verifyTransaction", RequestNamespace="urn:Foo", ResponseNamespace="urn:Foo")]
        [return: System.Xml.Serialization.SoapElementAttribute("result")]
        public double verifyTransaction(string String_1, string String_2) {
            object[] results = this.Invoke("verifyTransaction", new object[] {
                        String_1,
                        String_2});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void verifyTransactionAsync(string String_1, string String_2) {
            this.verifyTransactionAsync(String_1, String_2, null);
        }
        
        /// <remarks/>
        public void verifyTransactionAsync(string String_1, string String_2, object userState) {
            if ((this.verifyTransactionOperationCompleted == null)) {
                this.verifyTransactionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnverifyTransactionOperationCompleted);
            }
            this.InvokeAsync("verifyTransaction", new object[] {
                        String_1,
                        String_2}, this.verifyTransactionOperationCompleted, userState);
        }
        
        private void OnverifyTransactionOperationCompleted(object arg) {
            if ((this.verifyTransactionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verifyTransactionCompleted(this, new verifyTransactionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="urn:Foo", ResponseNamespace="urn:Foo")]
        [return: System.Xml.Serialization.SoapElementAttribute("result")]
        public double verifyTransaction1(string String_1, string String_2) {
            object[] results = this.Invoke("verifyTransaction1", new object[] {
                        String_1,
                        String_2});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void verifyTransaction1Async(string String_1, string String_2) {
            this.verifyTransaction1Async(String_1, String_2, null);
        }
        
        /// <remarks/>
        public void verifyTransaction1Async(string String_1, string String_2, object userState) {
            if ((this.verifyTransaction1OperationCompleted == null)) {
                this.verifyTransaction1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnverifyTransaction1OperationCompleted);
            }
            this.InvokeAsync("verifyTransaction1", new object[] {
                        String_1,
                        String_2}, this.verifyTransaction1OperationCompleted, userState);
        }
        
        private void OnverifyTransaction1OperationCompleted(object arg) {
            if ((this.verifyTransaction1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verifyTransaction1Completed(this, new verifyTransaction1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("reverseTransaction", RequestNamespace="urn:Foo", ResponseNamespace="urn:Foo")]
        [return: System.Xml.Serialization.SoapElementAttribute("result")]
        public double reverseTransaction(string String_1, string String_2, string Username, string Password) {
            object[] results = this.Invoke("reverseTransaction", new object[] {
                        String_1,
                        String_2,
                        Username,
                        Password});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void reverseTransactionAsync(string String_1, string String_2, string Username, string Password) {
            this.reverseTransactionAsync(String_1, String_2, Username, Password, null);
        }
        
        /// <remarks/>
        public void reverseTransactionAsync(string String_1, string String_2, string Username, string Password, object userState) {
            if ((this.reverseTransactionOperationCompleted == null)) {
                this.reverseTransactionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnreverseTransactionOperationCompleted);
            }
            this.InvokeAsync("reverseTransaction", new object[] {
                        String_1,
                        String_2,
                        Username,
                        Password}, this.reverseTransactionOperationCompleted, userState);
        }
        
        private void OnreverseTransactionOperationCompleted(object arg) {
            if ((this.reverseTransactionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.reverseTransactionCompleted(this, new reverseTransactionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("reverseTransaction1", RequestNamespace="urn:Foo", ResponseNamespace="urn:Foo")]
        [return: System.Xml.Serialization.SoapElementAttribute("result")]
        public double reverseTransaction1(string String_1, string String_2, string Password, double Amount) {
            object[] results = this.Invoke("reverseTransaction1", new object[] {
                        String_1,
                        String_2,
                        Password,
                        Amount});
            return ((double)(results[0]));
        }
        
        /// <remarks/>
        public void reverseTransaction1Async(string String_1, string String_2, string Password, double Amount) {
            this.reverseTransaction1Async(String_1, String_2, Password, Amount, null);
        }
        
        /// <remarks/>
        public void reverseTransaction1Async(string String_1, string String_2, string Password, double Amount, object userState) {
            if ((this.reverseTransaction1OperationCompleted == null)) {
                this.reverseTransaction1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnreverseTransaction1OperationCompleted);
            }
            this.InvokeAsync("reverseTransaction1", new object[] {
                        String_1,
                        String_2,
                        Password,
                        Amount}, this.reverseTransaction1OperationCompleted, userState);
        }
        
        private void OnreverseTransaction1OperationCompleted(object arg) {
            if ((this.reverseTransaction1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.reverseTransaction1Completed(this, new reverseTransaction1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void verifyTransactionCompletedEventHandler(object sender, verifyTransactionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verifyTransactionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verifyTransactionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void verifyTransaction1CompletedEventHandler(object sender, verifyTransaction1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verifyTransaction1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verifyTransaction1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void reverseTransactionCompletedEventHandler(object sender, reverseTransactionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class reverseTransactionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal reverseTransactionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void reverseTransaction1CompletedEventHandler(object sender, reverseTransaction1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class reverseTransaction1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal reverseTransaction1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public double Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((double)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591