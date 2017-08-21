using T10ConnectedAnimSample.Enums;
using Template10.Mvvm;

namespace T10ConnectedAnimSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObjectsToAnimate animationElements = ObjectsToAnimate.IconT10;
        /// <summary>
        /// Allows to track which element to animate
        /// </summary>
        public ObjectsToAnimate AnimationElements
        {
            get { return animationElements; }
            set { animationElements = value; RaisePropertyChanged(nameof(AnimationElements)); }
        }

        /// <summary>
        /// Decide if navigation needs to be done with animations
        /// </summary>
        public bool AnimateStuff { get; set; }

        /// <summary>
        /// Navigates with Image Animation
        /// </summary>
        internal void NavigateWithImageAnimation()
        {
            AnimateStuff = true;
            AnimationElements = ObjectsToAnimate.IconT10;
            NavigationService.Navigate(typeof(Views.SecondPage), "Image Animation", new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

        /// <summary>
        /// Navigates with text Animation
        /// </summary>
        internal void NavigateWithTextAnimation()
        {
            AnimateStuff = true;
            AnimationElements = ObjectsToAnimate.mainTextBlock;
            NavigationService.Navigate(typeof(Views.SecondPage), "Text Animation", new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

        /// <summary>
        /// Navigates with No Animation
        /// </summary>
        internal void JustNavigate()
        {
            AnimateStuff = false;
            NavigationService.Navigate(typeof(Views.SecondPage));
        }

    }

   
}
