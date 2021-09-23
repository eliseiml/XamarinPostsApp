using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Posts
{
    public partial class NavigationBar
    {
        #region -- Public properties --


        public static readonly BindableProperty LeftRightColumnDefinitionProperty = BindableProperty.Create(nameof(LeftRightColumnDefinition), typeof(GridLength), typeof(NavigationBar),
            defaultValue: GridLength.Star);

        public GridLength LeftRightColumnDefinition
        {
            get => (GridLength)GetValue(LeftRightColumnDefinitionProperty);
            set => SetValue(LeftRightColumnDefinitionProperty, value);
        }

        public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(Style), typeof(NavigationBar),
            default(Style));

        public Style TitleStyle
        {
            get => (Style)GetValue(TitleStyleProperty);
            set => SetValue(TitleStyleProperty, value);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(NavigationBar), string.Empty, BindingMode.TwoWay, propertyChanged: TitlePropertyChanged);


        public IList<View> RightToolbarItems { get; set; }

        public IList<View> LeftToolbarItems { get; set; }

        public IList<View> CentralToolBarItems { get; set; }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public NavigationBar()
        {
            InitializeComponent();

            var rightToolbarItems = new ObservableCollection<View>();
            rightToolbarItems.CollectionChanged += OnRightToolbarItemsCollectionChanged;
            RightToolbarItems = rightToolbarItems;

            var leftToolbarItems = new ObservableCollection<View>();
            leftToolbarItems.CollectionChanged += OnLeftToolbarItemsCollectionChanged;
            LeftToolbarItems = leftToolbarItems;

            var centralToolbarItems = new ObservableCollection<View>();
            centralToolbarItems.CollectionChanged += OnCentralToolbarItemsCollectionChanged;
            CentralToolBarItems = centralToolbarItems;

            Title = null;
        }

        #endregion

        #region -- Private helpers --

        private static void TitlePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var newText = newvalue as String;
            ((NavigationBar)bindable).TitleLabel.Text = newText;
        }

        private void OnRightToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RightToolBarItemsContainer.Children.Clear();
            foreach (var toolbarItem in RightToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
                RightToolBarItemsContainer.Children.Add(toolbarItem);
            }
        }

        private void OnLeftToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LeftToolBarItemsContainer.Children.Clear();
            foreach (var toolbarItem in LeftToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
                LeftToolBarItemsContainer.Children.Add(toolbarItem);
            }
        }

        private void OnCentralToolbarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CentralToolBarItemsContainer.Children.Clear();

            if (CentralToolBarItems.Any())
            {
                TitleLabel.IsVisible = false;

                foreach (var toolbarItem in CentralToolBarItems)
                {
                    toolbarItem.BindingContext = BindingContext;
                    CentralToolBarItemsContainer.Children.Add(toolbarItem);
                }
            }
            else
            {
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region -- Overrides --

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Title))
            {
                TitleLabel.IsVisible = !string.IsNullOrWhiteSpace(Title);
                TitleLabel.Text = Title;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            foreach (var toolbarItem in LeftToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }

            foreach (var toolbarItem in RightToolbarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }

            foreach (var toolbarItem in CentralToolBarItems)
            {
                toolbarItem.BindingContext = BindingContext;
            }
        }

        #endregion
    }
}
