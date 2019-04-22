﻿using ReportApp.Model;
using System.Windows.Controls;

namespace ReportApp.Pages
{
    /// <summary>
    /// PaletteSelector.xaml 的交互逻辑
    /// </summary>
    public partial class PaletteSelector : UserControl
    {
        public PaletteSelector()
        {
            InitializeComponent();

            DataContext = new MPaletteSelector();
        }
    }
}
