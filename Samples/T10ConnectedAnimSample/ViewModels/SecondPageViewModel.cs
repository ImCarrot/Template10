using System.Collections.Generic;
using System.Threading.Tasks;
using T10ConnectedAnimSample.Enums;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace T10ConnectedAnimSample.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter is string passedMessage)
                HeaderContent = passedMessage;

            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        private string headerContent = "Just Navigation";
        /// <summary>
        /// Sets the header content. 
        /// Basically just for faciness
        /// </summary>
        public string HeaderContent
        {
            get { return headerContent; }
            set { headerContent = value; RaisePropertyChanged(nameof(HeaderContent)); }
        }

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
        /// Keeps a check if anything was animated.
        /// </summary>
        public bool StuffAnimated { get; set; }

    }
}
