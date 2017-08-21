using System;
using T10ConnectedAnimSample.Enums;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T10ConnectedAnimSample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //tries to get the animation (if any) for the image
            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation($"IconT10{Constants.AppendingConst.NavigationAnimationAppend}");
            if (imageAnimation != null)
            {
                //Tries to continue the animation
                imageAnimation.TryStart(IconT10);
                //sets what was animated
                ViewModel.AnimationElements = Enums.ObjectsToAnimate.IconT10;
                
                //sets if anything was animated
                ViewModel.StuffAnimated = true;
            }

            //tries to get the animation (if any) for the page header
            ConnectedAnimation headerTextAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation($"mainTextBlock{Constants.AppendingConst.NavigationAnimationAppend}");
            if (headerTextAnimation != null)
            {
                //Tries to continue the animation
                headerTextAnimation.TryStart(pageHeader);

                //sets what was animated
                ViewModel.AnimationElements = Enums.ObjectsToAnimate.mainTextBlock;
                //sets if anything was animated
                ViewModel.StuffAnimated = true;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //only runs if something was animated
            if (!ViewModel.StuffAnimated)
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
                    element = pageHeader;
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

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Prepares the animation
        /// </summary>
        /// <param name="animationName"></param>
        /// <param name="elementToAnimate"></param>
        void PrepareAnimations(string animationName, UIElement elementToAnimate) =>
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate(animationName, elementToAnimate);
    }
}
