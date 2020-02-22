﻿#pragma checksum "..\..\..\View\Signup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "767DC856FEC5DA4D5D8DA4AAB847D36BF988130B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MDB.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MDB.View {
    
    
    /// <summary>
    /// Signup
    /// </summary>
    public partial class Signup : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdMain;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbFirstName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbLastName;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbEmail;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPhone;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbProfilePicture;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectProfilePicture;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txbPassword;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txbPasswordRetype;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSignup;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtMessage;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgProfilePicture;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MDB;component/view/signup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Signup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grdMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txbFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbProfilePicture = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSelectProfilePicture = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\View\Signup.xaml"
            this.btnSelectProfilePicture.Click += new System.Windows.RoutedEventHandler(this.btnSelectProfilePicture_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.txbPasswordRetype = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.btnSignup = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\View\Signup.xaml"
            this.btnSignup.Click += new System.Windows.RoutedEventHandler(this.btnSignup_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.txtMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.imgProfilePicture = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

