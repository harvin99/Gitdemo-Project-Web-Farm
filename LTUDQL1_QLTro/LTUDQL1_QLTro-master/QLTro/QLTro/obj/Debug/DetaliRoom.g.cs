﻿#pragma checksum "..\..\DetaliRoom.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A0D7BA95846924859D5FE50D03F723E0891DB712"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QLTro;
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


namespace QLTro {
    
    
    /// <summary>
    /// DetaliRoom
    /// </summary>
    public partial class DetaliRoom : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRent;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btapply;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btedit;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btdelete;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackpennalshow;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbstatus;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackpennaledit;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbRctgr;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbsophong;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbttrong;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtdaconguoithue;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\DetaliRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtsuachua;
        
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
            System.Uri resourceLocater = new System.Uri("/QLTro;component/detaliroom.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DetaliRoom.xaml"
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
            
            #line 8 "..\..\DetaliRoom.xaml"
            ((QLTro.DetaliRoom)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnRent = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\DetaliRoom.xaml"
            this.btnRent.Click += new System.Windows.RoutedEventHandler(this.btnRent_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btapply = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\DetaliRoom.xaml"
            this.btapply.Click += new System.Windows.RoutedEventHandler(this.btapply_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btedit = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\DetaliRoom.xaml"
            this.btedit.Click += new System.Windows.RoutedEventHandler(this.btedit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btdelete = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\DetaliRoom.xaml"
            this.btdelete.Click += new System.Windows.RoutedEventHandler(this.btdelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.stackpennalshow = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.tbstatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.stackpennaledit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.cbbRctgr = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.tbsophong = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.rbttrong = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.rbtdaconguoithue = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this.rbtsuachua = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
