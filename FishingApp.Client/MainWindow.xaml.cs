using FishingApp.Client.ViewModels.MainWindow;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FishingApp.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainWindowViewModel _mainWindowViewModel;

        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
            _mainWindowViewModel = mainWindowViewModel;

            App app = (App)Application.Current;
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            switch (app.InitialTheme)
            {
                case BaseTheme.Dark:
                    ModifyTheme(true);
                    break;
                case BaseTheme.Light:
                    ModifyTheme(false);
                    break;
            }

            if (app.InitialFlowDirection == FlowDirection.RightToLeft)
            {
                FlowDirectionToggleButton.IsChecked = true;
                FlowDirection = FlowDirection.RightToLeft;
            }

            DarkModeToggleButton.IsChecked = theme.GetBaseTheme() == BaseTheme.Dark;

            if (paletteHelper.GetThemeManager() is { } themeManager)
            {
                themeManager.ThemeChanged += (_, e)
                    => DarkModeToggleButton.IsChecked = e.NewTheme?.GetBaseTheme() == BaseTheme.Dark;
            }

        }

        public void BuildSideMenuActionList()
        {
            //var test = _mainWindowViewModel.GetUserControls(this.GetType().Namespace);
            //var ass = test.First().Name;
        }

        

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            NavDrawer.IsLeftDrawerOpen = false;
            if (ActualWidth > 1600)
            {
                NavRail.Visibility = Visibility.Visible;
                MenuToggleButton.Visibility = Visibility.Visible;
            }

        }

        private void MenuToggleButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ActualWidth > 1600)
            {
                NavRail.Visibility = Visibility.Collapsed;
                MenuToggleButton.Visibility = Visibility.Collapsed;
            }
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (NavDrawer.OpenMode is not DrawerHostOpenMode.Standard)
            {
                //until we had a StaysOpen flag to Drawer, this will help with scroll bars
                var dependencyObject = Mouse.Captured as DependencyObject;

                while (dependencyObject != null)
                {
                    if (dependencyObject is ScrollBar) return;
                    dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
                }

                MenuToggleButton.IsChecked = false;
            }
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {

            //var sampleMessageDialog = new MetroWindow().ShowMessageAsync()
            //{
            //    Show = { Text = ((ButtonBase)sender).Content.ToString() }
            //};

            //await DialogHost.Show(sampleMessageDialog, "RootDialog");
        }

        private void FlowDirectionButton_Click(object sender, RoutedEventArgs e)
        => FlowDirection = FlowDirectionToggleButton.IsChecked.GetValueOrDefault(false)
            ? FlowDirection.RightToLeft
            : FlowDirection.LeftToRight;

        private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
        => MainScrollViewer.ScrollToHome();

        private void MenuDarkModeButton_Click(object sender, RoutedEventArgs e)
        => ModifyTheme(DarkModeToggleButton.IsChecked == true);

        private static void ModifyTheme(bool isDarkTheme)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(isDarkTheme ? BaseTheme.Dark : BaseTheme.Light);
            paletteHelper.SetTheme(theme);
        }

    }
}