﻿#pragma checksum "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D3B12145291A92FF45362E265E289764D58FF8A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using LicenseGenerator.MVVM.View;
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


namespace LicenseGenerator.MVVM.View {
    
    
    /// <summary>
    /// GenerateView
    /// </summary>
    public partial class GenerateView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Use_Key;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton No_Key;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton One_Day;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Fourteen_Day;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton thirty_Day;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LicenseGenerator;V1.0.0.0;component/mvvm/view/generateview%20-%20kopieren.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Use_Key = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.No_Key = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.One_Day = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.Fourteen_Day = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.thirty_Day = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.create = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\..\..\..\MVVM\View\GenerateView - Kopieren.xaml"
            this.create.Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

