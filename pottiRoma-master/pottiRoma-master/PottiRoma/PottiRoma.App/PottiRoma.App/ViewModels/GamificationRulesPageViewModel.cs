using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PottiRoma.App.ViewModels
{
	public class GamificationRulesPageViewModel : ViewModelBase
	{
        private string _rules;
        public string Rules
        {
            get { return _rules; }
            set { SetProperty(ref _rules, value); }
        }
        public GamificationRulesPageViewModel()
        {

        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Rules = GameRules();
        }

        private string GameRules()
        {
            return "Lorem ipsum a vestibulum dictum posuere egestas nam sit, " +
                "aliquam purus sapien inceptos gravida curabitur adipiscing aenean " +
                "malesuada, diam aliquam eu sem sapien mattis vulputate. class erat " +
                "quis convallis tortor dui congue, lectus placerat lacinia mauris " +
                "aptent aenean porttitor, vestibulum rutrum fames praesent ullamcorper." +
                " nisi dolor aliquet mauris metus vehicula eget facilisis ullamcorper, " +
                "hac turpis aliquam ut cursus condimentum praesent tristique, vulputate " +
                "diam iaculis etiam eleifend auctor sit, cubilia lobortis suspendisse " +
                "habitant odio donec fermentum. integer pulvinar molestie gravida semper " +
                "cubilia venenatis nostra, fringilla rhoncus elit purus malesuada euismod " +
                "sagittis quisque, vestibulum turpis interdum vel volutpat enim. Tempor suscipit " +
                "etiam eleifend tempus sociosqu faucibus quisque nec curabitur sagittis " +
                "dictum class ornare, risus dolor mi aliquam sociosqu cubilia sociosqu " +
                "imperdiet tristique praesent est.etiam donec ut sagittis elit metus " +
                "nisi in leo nibh ultricies, eros non habitasse rutrum aenean auctor " +
                "accumsan sodales adipiscing praesent, vestibulum nunc commodo non " +
                "volutpat habitasse pretium et cursus.vel non maecenas semper erat " +
                "elit donec tempor accumsan eu felis accumsan, vivamus senectus nibh " +
                "proin facilisis netus gravida aliquet ut vivamus a mattis, ut non " +
                "phasellus tristique arcu mauris pretium dolor per accumsan. fermentum" +
                " habitasse vestibulum venenatis malesuada primis fusce lacus, rhoncus " +
                "nulla neque gravida consequat velit faucibus urna, erat dictumst " +
                "laoreet gravida proin phasellus. ";
        }
	}
}
