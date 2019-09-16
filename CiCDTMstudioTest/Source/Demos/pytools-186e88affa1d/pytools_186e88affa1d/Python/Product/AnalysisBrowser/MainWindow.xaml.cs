﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.VisualStudioTools;

namespace Microsoft.PythonTools.Analysis.Browser {
    public partial class MainWindow : Window {
        public static readonly ICommand CloseDatabaseCommand = new RoutedCommand();
        public static readonly ICommand OpenDatabaseCommand = new RoutedCommand();
        public static readonly ICommand BrowseSaveCommand = new RoutedCommand();
        public static readonly ICommand BrowseFolderCommand = new RoutedCommand();
        public static readonly ICommand GoToItemCommand = new RoutedCommand();

        public static readonly IEnumerable<Version> SupportedVersions = new[] {
            new Version(2, 5),
            new Version(2, 6),
            new Version(2, 7),
            new Version(3, 0),
            new Version(3, 1),
            new Version(3, 2),
            new Version(3, 3),
            new Version(3, 4),
        };

        public MainWindow() {
            InitializeComponent();

            DatabaseDirectory.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Python Tools"
            );

            var path = Environment.GetCommandLineArgs().LastOrDefault();
            try {
                if (Directory.Exists(path)) {
                    Load(path);
                }
            } catch {
            }
        }


        internal AnalysisView Analysis {
            get { return (AnalysisView)GetValue(AnalysisProperty); }
            private set { SetValue(AnalysisPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey AnalysisPropertyKey = DependencyProperty.RegisterReadOnly("Analysis", typeof(AnalysisView), typeof(MainWindow), new PropertyMetadata());
        public static readonly DependencyProperty AnalysisProperty = AnalysisPropertyKey.DependencyProperty;


        public bool HasAnalysis {
            get { return (bool)GetValue(HasAnalysisProperty); }
            private set { SetValue(HasAnalysisPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey HasAnalysisPropertyKey = DependencyProperty.RegisterReadOnly("HasAnalysis", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        public static readonly DependencyProperty HasAnalysisProperty = HasAnalysisPropertyKey.DependencyProperty;

        public bool Loading {
            get { return (bool)GetValue(LoadingProperty); }
            private set { SetValue(LoadingPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey LoadingPropertyKey = DependencyProperty.RegisterReadOnly("Loading", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
        public static readonly DependencyProperty LoadingProperty = LoadingPropertyKey.DependencyProperty;



        public Version Version {
            get { return (Version)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }

        public static readonly DependencyProperty VersionProperty = DependencyProperty.Register("Version", typeof(Version), typeof(MainWindow), new PropertyMetadata(new Version(2, 7)));


        public bool LoadWithContention {
            get { return (bool)GetValue(LoadWithContentionProperty); }
            set { SetValue(LoadWithContentionProperty, value); }
        }

        public static readonly DependencyProperty LoadWithContentionProperty = DependencyProperty.Register("LoadWithContention", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public bool LoadWithLowMemory {
            get { return (bool)GetValue(LoadWithLowMemoryProperty); }
            set { SetValue(LoadWithLowMemoryProperty, value); }
        }

        public static readonly DependencyProperty LoadWithLowMemoryProperty = DependencyProperty.Register("LoadWithLowMemory", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));


        public bool LoadRecursive {
            get { return (bool)GetValue(LoadRecursiveProperty); }
            set { SetValue(LoadRecursiveProperty, value); }
        }

        public static readonly DependencyProperty LoadRecursiveProperty = DependencyProperty.Register("LoadRecursive", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));


        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Loading;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e) {
            string path;
            var tb = e.Source as TextBox;
            if (tb == null || !Directory.Exists(path = tb.Text)) {
                using (var bfd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog()) {
                    bfd.IsFolderPicker = true;
                    bfd.RestoreDirectory = true;
                    if (HasAnalysis) {
                        path = Analysis.Path;
                    } else {
                        path = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "Python Tools"
                        );
                    }
                    while (path.Length >= 4 && !Directory.Exists(path)) {
                        path = Path.GetDirectoryName(path);
                    }
                    if (path.Length <= 3) {
                        path = null;
                    }
                    bfd.InitialDirectory = path;
                    if (bfd.ShowDialog() == WindowsAPICodePack.Dialogs.CommonFileDialogResult.Cancel) {
                        return;
                    }
                    path = bfd.FileName;
                }
            }

            Load(path);
        }

        private void Load(string path) {
            HasAnalysis = false;
            Loading = true;
            Analysis = null;
            Cursor = Cursors.Wait;

            var version = Version;
            var withContention = LoadWithContention;
            var withLowMemory = LoadWithLowMemory;
            var withRecursion = LoadRecursive;

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            Task startTask = tcs.Task;

            if (withLowMemory) {
                startTask = Task.Factory.StartNew(() => {
                    var bigBlocks = new LinkedList<byte[]>();
                    var rnd = new Random();
                    try {
                        while (true) {
                            var block = new byte[10 * 1024 * 1024];
                            rnd.NextBytes(block);
                            bigBlocks.AddLast(block);
                        }
                    } catch (OutOfMemoryException) {
                        // Leave 200MB of memory available
                        for (int i = 0; i < 20 && bigBlocks.Any(); ++i) {
                            bigBlocks.RemoveFirst();
                        }
                    }
                    return bigBlocks;
                }).ContinueWith(t => {
                    Tag = t.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }

            var loadTask = startTask.ContinueWith<AnalysisView>(t => {
                return new AnalysisView(path, version, withContention, withRecursion);
            }, TaskContinuationOptions.LongRunning);

            loadTask.ContinueWith(
                t => {
                    Tag = null;

                    try {
                        Analysis = t.Result;
                        HasAnalysis = true;
                    } catch (Exception ex) {
                        HasAnalysis = false;
                        MessageBox.Show(string.Format("Error occurred:{0}{0}{1}", Environment.NewLine, ex));
                    }
                    Loading = false;
                    Cursor = Cursors.Arrow;
                },
                TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        private void Export_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = HasAnalysis && !string.IsNullOrEmpty(ExportFilename.Text);
            if (e.Command == AnalysisView.ExportDiffableCommand) {
                // Not implemented yet
                e.CanExecute = false;
            }
        }

        private void Export_Executed(object sender, ExecutedRoutedEventArgs e) {
            e.Handled = true;

            var path = ExportFilename.Text;
            var filter = ExportFilter.Text;

            Cursor = Cursors.AppStarting;
            Task t = null;
            if (e.Command == AnalysisView.ExportTreeCommand) {
                t = Analysis.ExportTree(path, filter);
            } else if (e.Command == AnalysisView.ExportDiffableCommand) {
                t = Analysis.ExportDiffable(path, filter);
            }
            if (t != null) {
                t.ContinueWith(t2 => {
                    Process.Start("explorer.exe", "/select,\"" + path + "\"");
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
                t.ContinueWith(t2 => {
                    Cursor = Cursors.Arrow;
                    if (t2.Exception != null) {
                        MessageBox.Show(string.Format("An error occurred while exporting:{0}{0}{1}",
                            Environment.NewLine,
                            t2.Exception));
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void BrowseSave_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = e.Source is TextBox && e.Parameter is string;
        }

        private void BrowseSave_Executed(object sender, ExecutedRoutedEventArgs e) {
            using (var dialog = new System.Windows.Forms.SaveFileDialog()) {
                dialog.Filter = (string)e.Parameter;
                dialog.AutoUpgradeEnabled = true;
                var path = ((TextBox)e.Source).Text;
                try {
                    dialog.FileName = path;
                    dialog.InitialDirectory = Path.GetDirectoryName(path);
                } catch (ArgumentException) {
                    dialog.FileName = string.Empty;
                    dialog.InitialDirectory = Analysis.Path;
                }
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) {
                    return;
                }
                ((TextBox)e.Source).SetCurrentValue(TextBox.TextProperty, dialog.FileName);
            }
        }

        private void BrowseFolder_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = e.Source is TextBox;
        }

        private void BrowseFolder_Executed(object sender, ExecutedRoutedEventArgs e) {
            using (var bfd = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog()) {
                bfd.IsFolderPicker = true;
                bfd.RestoreDirectory = true;
                var path = ((TextBox)e.Source).Text;
                while (path.Length >= 4 && !Directory.Exists(path)) {
                    path = Path.GetDirectoryName(path);
                }
                if (path.Length <= 3) {
                    path = null;
                }
                bfd.InitialDirectory = path;
                if (bfd.ShowDialog() == WindowsAPICodePack.Dialogs.CommonFileDialogResult.Cancel) {
                    return;
                }
                ((TextBox)e.Source).SetCurrentValue(TextBox.TextProperty, bfd.FileName);
            }
        }

        private void GoToItem_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = e.Parameter is IAnalysisItemView;
        }

        private static Stack<TreeViewItem> SelectChild(TreeViewItem root, object value) {
            if (root == null) {
                return null;
            }

            if (root.DataContext == value) {
                var lst = new Stack<TreeViewItem>();
                lst.Push(root);
                return lst;
            }
            foreach (var child in root.Items
                .OfType<object>()
                .Select(i => (TreeViewItem)root.ItemContainerGenerator.ContainerFromItem(i))) {
                var lst = SelectChild(child, value);
                if (lst != null) {
                    lst.Push(root);
                    return lst;
                }
            }
            return null;
        }

        private static void SelectChild(TreeView tree, object value) {
            Stack<TreeViewItem> result = null;

            foreach (var item in tree.Items
                .OfType<object>()
                .Select(i => (TreeViewItem)tree.ItemContainerGenerator.ContainerFromItem(i))) {
                if ((result = SelectChild(item, value)) != null) {
                    break;
                }
            }

            if (result != null) {
                while (result.Any()) {
                    var item = result.Pop();
                    item.IsExpanded = true;
                    item.Focus();
                }
            }
        }

        private void GoToItem_Executed(object sender, ExecutedRoutedEventArgs e) {
            Cursor = Cursors.Wait;
            try {
                SelectChild(DatabaseTreeView, e.Parameter);
            } finally {
                Cursor = Cursors.Arrow;
            }
        }

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = true;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e) {
            Close();
        }

        private void CloseDatabase_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = HasAnalysis;
        }

        private void CloseDatabase_Executed(object sender, ExecutedRoutedEventArgs e) {
            Analysis = null;
            Loading = false;
            HasAnalysis = false;
            DatabaseDirectory.SelectAll();
        }

        private void DatabaseDirectory_TextChanged(object sender, TextChangedEventArgs e) {
            var dir = DatabaseDirectory.Text;
            if (!Directory.Exists(dir)) {
                return;
            }

            foreach (var ver in SupportedVersions.Reverse()) {
                if (dir.Contains("\\" + ver.ToString())) {
                    Version = ver;
                    break;
                }
            }
        }

        private void NavigateTo_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = Directory.Exists(e.Parameter as string);
            e.Handled = true;
        }

        private void NavigateTo_Executed(object sender, ExecutedRoutedEventArgs e) {
            DatabaseDirectory.SetCurrentValue(TextBox.TextProperty, e.Parameter);
            DatabaseDirectory.Focus();
            DatabaseDirectory.SelectAll();
            e.Handled = true;
        }

        private void DatabaseDirectory_SubDirs_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) {
            DatabaseDirectory.Focus();
            e.Handled = true;
        }
    }

    class PropertyItemTemplateSelector : DataTemplateSelector {
        public DataTemplate Text { get; set; }
        public DataTemplate AnalysisItem { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (item is string) {
                return Text;
            } else if (item is IAnalysisItemView) {
                return AnalysisItem;
            }
            return null;
        }
    }

    [ValueConversion(typeof(string), typeof(IEnumerable<string>))]
    class DirectoryList : IValueConverter {
        public bool IncludeParentDirectory { get; set; }
        public bool IncludeDirectories { get; set; }
        public bool IncludeFiles { get; set; }
        public bool NamesOnly { get; set; }

        private IEnumerable<string> GetParentDirectory(string dir) {
            if (!IncludeParentDirectory || ! CommonUtils.IsValidPath(dir)) {
                yield break;
            }

            var parentDir = Path.GetDirectoryName(dir);
            if (!string.IsNullOrEmpty(parentDir)) {
                yield return parentDir;
            }
        }

        private IEnumerable<string> GetFiles(string dir) {
            if (!IncludeFiles) {
                return Enumerable.Empty<string>();
            }
            var files = Directory.EnumerateFiles(dir);
            if (NamesOnly) {
                files = files.Select(f => Path.GetFileName(f));
            }
            return files.OrderBy(f => f);
        }

        private IEnumerable<string> GetDirectories(string dir) {
            if (!IncludeDirectories) {
                return Enumerable.Empty<string>();
            }
            var dirs = Directory.EnumerateDirectories(dir);
            if (NamesOnly) {
                dirs = dirs.Select(d => Path.GetFileName(d));
            }
            return dirs.OrderBy(d => d);
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var dir = value as string;
            if (!Directory.Exists(dir)) {
                return Enumerable.Empty<string>();
            }

            return GetParentDirectory(dir).Concat(GetDirectories(dir)).Concat(GetFiles(dir));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}
