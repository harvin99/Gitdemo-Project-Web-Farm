﻿#pragma checksum "..\..\CheckOutWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0FBEEA1E7B48E2894477CB994E83657C14DA324D"
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
    /// CheckOutWindow
    /// </summary>
    public partial class CheckOutWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spRentRoomInfo;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbID;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbRoomID;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbRenterName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPrice;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbDate;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tcUSDDetails;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUSDDetails;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTotalPrice;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\CheckOutWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCheckOutRentRoom;
        
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
            System.Uri resourceLocater = new System.Uri("/QLTro;component/checkoutwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CheckOutWindow.xaml"
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
            this.lbTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.spRentRoomInfo = ((System.Windows.Controls.StackPanel)(target));
            
            #line 12 "..\..\CheckOutWindow.xaml"
            this.spRentRoomInfo.Loaded += new System.Windows.RoutedEventHandler(this.spRentRoomInfo_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbRoomID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbRenterName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbTel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tbPrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tbDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tcUSDDetails = ((System.Windows.Controls.TabControl)(target));
            return;
            case 10:
            this.dgUSDDetails = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.tbTotalPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.btnCheckOutRentRoom = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\CheckOutWindow.xaml"
            this.btnCheckOutRentRoom.Click += new System.Windows.RoutedEventHandler(this.btnCheckOutRentRoom_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

