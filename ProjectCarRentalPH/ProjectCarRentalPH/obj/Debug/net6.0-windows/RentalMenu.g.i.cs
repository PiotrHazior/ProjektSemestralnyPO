﻿#pragma checksum "..\..\..\RentalMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3190686B7AEC389A074BB94465A6CC8D01897EB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectCarRentalPH;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjectCarRentalPH {
    
    
    /// <summary>
    /// RentalMenu
    /// </summary>
    public partial class RentalMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\RentalMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID_SportCar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\RentalMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker RentalDate;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\RentalMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfReturn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\RentalMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RentalDGV;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\RentalMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid YourRental;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectCarRentalPH;component/rentalmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RentalMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\RentalMenu.xaml"
            ((ProjectCarRentalPH.RentalMenu)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\..\RentalMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CustomerMenu);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ID_SportCar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 19 "..\..\..\RentalMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Add3);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\..\RentalMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Delete3);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RentalDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.DateOfReturn = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.RentalDGV = ((System.Windows.Controls.DataGrid)(target));
            
            #line 57 "..\..\..\RentalMenu.xaml"
            this.RentalDGV.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RentalDGV_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.YourRental = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\..\RentalMenu.xaml"
            this.YourRental.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.YourRental_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 61 "..\..\..\RentalMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.INFO);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

