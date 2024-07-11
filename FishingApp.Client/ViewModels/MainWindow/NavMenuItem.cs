using FishingApp.Client.ViewModels.Abstract;
using MaterialDesignThemes.Wpf;
using Prism.Mvvm;
using System.Windows.Controls;
using System.Windows;

namespace FishingApp.Client.ViewModels.MainWindow
{
    public class NavMenuItem : ViewModelBase
    {
        private object? _content;
        private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto;
        private Thickness _marginRequirement = new(16);
        private readonly Type _contentType;
        private readonly object? _dataContext;

        public string Name { get; }
        public PackIconKind SelectedIcon { get; }
        public PackIconKind UnselectedIcon { get; }
        public object? Content => _content ??= CreateContent();

        public NavMenuItem(string name, Type contentType, PackIconKind selectedIcon, PackIconKind unselectedIcon, object? dataContext = null)
        {
            Name = name;
            _contentType = contentType;
            _dataContext = dataContext;
            SelectedIcon = selectedIcon;
            UnselectedIcon = unselectedIcon;
        }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get => _horizontalScrollBarVisibilityRequirement;
            set => SetProperty(ref _horizontalScrollBarVisibilityRequirement, value);
        }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get => _verticalScrollBarVisibilityRequirement;
            set => SetProperty(ref _verticalScrollBarVisibilityRequirement, value);
        }

        public Thickness MarginRequirement
        {
            get => _marginRequirement;
            set => SetProperty(ref _marginRequirement, value);
        }

        private object? CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            if (_dataContext != null && content is FrameworkElement element)
            {
                element.DataContext = _dataContext;
            }

            return content;
        }
    }
}
