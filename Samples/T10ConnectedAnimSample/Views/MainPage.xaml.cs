using System;
using T10ConnectedAnimSample.Enums;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace T10ConnectedAnimSample.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //only runs the below code if the navigation is 
            //coming back to this page
            if (e.NavigationMode != NavigationMode.Back)
                return;

            //Ignores everything is it did not animate stuff
            if (!ViewModel.AnimateStuff)
                return;

            //handles back animation 
            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation($"IconT10{Constants.AppendingConst.NavigationAnimationAppend}");
            if (imageAnimation != null)
                imageAnimation.TryStart(IconT10);

            ConnectedAnimation headerTextAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation($"mainTextBlock{Constants.AppendingConst.NavigationAnimationAppend}");
            if (headerTextAnimation != null)
                headerTextAnimation.TryStart(mainTextBlock);

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            if (!ViewModel.AnimateStuff)
                return;

            
            UIElement element = null;

            //Generates the name of the animation. 
            //It can further be more dynamic, by using Attributes of an enum.
            //But this is just a sample :)
            string animationName = $"{ViewModel.AnimationElements.ToString()}{Constants.AppendingConst.NavigationAnimationAppend}";

            //Picks which element to animate
            switch (ViewModel.AnimationElements)
            {
                case ObjectsToAnimate.mainTextBlock:
                    element = mainTextBlock;
                    break;
                case ObjectsToAnimate.IconT10:
                    element = IconT10;
                    break;
                default:
                    throw new Exception("Fall Through!!!!!");
            }

            //Handles animation prep.
            if (element != null)
                PrepareAnimations(animationName, element);

        }

        void PrepareAnimations(string animationName, UIElement elementToAnimate) =>
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate(animationName, elementToAnimate);
    }
}