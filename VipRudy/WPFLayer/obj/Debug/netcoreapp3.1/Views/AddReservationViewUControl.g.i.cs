// Updated by XamlIntelliSenseFileGenerator 10/08/2020 12:25:21
#pragma checksum "..\..\..\..\Views\AddReservationViewUControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05774EAEF5FD800A4FF7E270E754AF6B019C9890"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPFLayer.Views;


namespace WPFLayer.Views
{


    /// <summary>
    /// AddReservationViewUControl
    /// </summary>
    public partial class AddReservationViewUControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFLayer;V1.0.0.0;component/views/addreservationviewucontrol.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Views\AddReservationViewUControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox ClientsComboBox;
        internal System.Windows.Controls.ComboBox ArrangementsComboBox;
        internal System.Windows.Controls.TextBox StreetTxt;
        internal System.Windows.Controls.TextBox HouseNumberTxt;
        internal System.Windows.Controls.TextBox CityTxt;
        internal System.Windows.Controls.ComboBox LocationsStartComboBox;
        internal System.Windows.Controls.ComboBox LocationsEndComboBox;
        internal System.Windows.Controls.ComboBox HourComboBox1;
        internal System.Windows.Controls.ComboBox HourComboBox2;
        internal System.Windows.Controls.Calendar StartDayCalender;
        internal System.Windows.Controls.Calendar EndDayCalender;
        internal System.Windows.Controls.Button btnCreateOverview;
        internal System.Windows.Controls.Button btnAddReservationPage;
    }
}

