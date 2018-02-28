using Microsoft.AppCenter.Analytics;
using PottiRoma.App.Dtos;
using PottiRoma.App.Insights;
using PottiRoma.App.Utils.ConstantRules;
using PottiRoma.App.ViewModels.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PottiRoma.App.ViewModels
{
	public class GamificationRulesPageViewModel : ViewModelBase
	{
        private RulesContentDto _main;
        public RulesContentDto Main
        {
            get { return _main; }
            set { SetProperty(ref _main, value); }
        }

        private RulesContentDto _objective;
        public RulesContentDto Objective
        {
            get { return _objective; }
            set { SetProperty(ref _objective, value); }
        }

        private RulesContentDto _theGame;
        public RulesContentDto TheGame
        {
            get { return _theGame; }
            set { SetProperty(ref _theGame, value); }
        }

        private RulesContentDto _bonus;
        public RulesContentDto Bonus
        {
            get { return _bonus; }
            set { SetProperty(ref _bonus, value); }
        }

        private RulesContentDto _kpis;
        public RulesContentDto Kpis
        {
            get { return _kpis; }
            set { SetProperty(ref _kpis, value); }
        }

        private RulesContentDto _seeds;
        public RulesContentDto Seeds
        {
            get { return _seeds; }
            set { SetProperty(ref _seeds, value); }
        }

        private RulesContentDto _rules;
        public RulesContentDto Rules
        {
            get { return _rules; }
            set { SetProperty(ref _rules, value); }
        }

        private RulesContentDto _where;
        public RulesContentDto Where
        {
            get { return _where; }
            set { SetProperty(ref _where, value); }
        }

        private RulesContentDto _who;
        public RulesContentDto Who
        {
            get { return _who; }
            set { SetProperty(ref _who, value); }
        }

        private RulesContentDto _generalObservations;
        public RulesContentDto GeneralObservations
        {
            get { return _generalObservations; }
            set { SetProperty(ref _generalObservations, value); }
        }
        public GamificationRulesPageViewModel()
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Analytics.TrackEvent(InsightsTypeEvents.ActionView, new Dictionary<string, string>
            {
                { InsightsPagesNames.GamificationRulesPage, InsightsActionNames.ReadRules }
            });
            GameRules();
        }

        private async void GameRules()
        {
            Device.BeginInvokeOnMainThread(async () => 
            {
                Main = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Main,
                    Title = "JOGO CRM - POTTI ROMÃ",
                    Definition = RulesConstants.Main
                });
                Objective = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Objective,
                    Title = "OBJETIVO",
                    Definition = RulesConstants.Objective
                });
                TheGame = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.TheGame,
                    Title = "O JOGO",
                    Definition = RulesConstants.TheGame
                });
                Bonus = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Bonus,
                    Title = "BÔNUS",
                    Definition = RulesConstants.Bonus
                });
                Kpis = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Kpis,
                    Title = "INDICADORES",
                    Definition = RulesConstants.Kpis
                });
                Seeds = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Seeds,
                    Title = "SEMENTES",
                    Definition = RulesConstants.Seeds
                });
                Rules = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Rules,
                    Title = "REGRAS",
                    Definition = RulesConstants.Rules,
                });
                Where = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Where,
                    Title = "ONDE JOGAR",
                    Definition = RulesConstants.Kpis,
                });
                Who = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.Who,
                    Title = "QUEM PODE JOGAR",
                    Definition = RulesConstants.Kpis
                });
                GeneralObservations = (new RulesContentDto()
                {
                    ContentRulesId = Utils.Enums.RulesTitleContentEnum.GeneralObservations,
                    Title = "OBSERVAÇÕES GERAIS",
                    Definition = RulesConstants.GeneralObservations
                });
            });
        }
	}
}
