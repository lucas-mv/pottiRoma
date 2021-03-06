﻿using PottiRoma.App.Utils.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class User : BindableBase
    {
        #region Database Values

        public Guid UsuarioId { get; set; }
        public UserType UserType { get; set; }
        public Guid MotherFlowerId { get; set; }
        public Guid TemporadaId { get; set; }
        public bool IsActive { get; set; }

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _primaryTelephone;
        public string PrimaryTelephone
        {
            get { return _primaryTelephone; }
            set { SetProperty(ref _primaryTelephone, value); }
        }

        private string _secundaryTelephone;
        public string SecundaryTelephone
        {
            get { return _secundaryTelephone; }
            set { SetProperty(ref _secundaryTelephone, value); }
        }

        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { SetProperty(ref _cep, value); }
        }

        private int _averageTicketPoints;
        public int AverageTicketPoints
        {
            get { return _averageTicketPoints; }
            set { SetProperty(ref _averageTicketPoints, value); }
        }

        private int _RegisterClientsPoints;
        public int RegisterClientsPoints
        {
            get { return _RegisterClientsPoints; }
            set { SetProperty(ref _RegisterClientsPoints, value); }
        }

        private int _salesNumberPoints;
        public int SalesNumberPoints
        {
            get { return _salesNumberPoints; }
            set { SetProperty(ref _salesNumberPoints, value); }
        }

        private int _averageItensPerSalePoints;
        public int AverageItensPerSalePoints
        {
            get { return _averageItensPerSalePoints; }
            set { SetProperty(ref _averageItensPerSalePoints, value); }
        }

        private int _inviteAllyFlowersPoints;
        public int InviteAllyFlowersPoints
        {
            get { return _inviteAllyFlowersPoints; }
            set { SetProperty(ref _inviteAllyFlowersPoints, value); }
        }

        #endregion

        #region Helper Values

        private int _totalPoints;
        public int TotalPoints
        {
            get { return _totalPoints; }
            set { SetProperty(ref _totalPoints, value); }
        }

        private string _rankingPosition;
        public string RankingPosition
        {
            get { return _rankingPosition; }
            set { SetProperty(ref _rankingPosition, value); }
        }

        private string _listRankingPoints;
        public string ListRankingPoints
        {
            get { return _listRankingPoints; }
            set { SetProperty(ref _listRankingPoints, value); }
        }

        #endregion

        public User()
        {
            TotalPoints = SetTotalPoints();
        }

        private int SetTotalPoints()
        {
            return AverageItensPerSalePoints + AverageTicketPoints + RegisterClientsPoints + InviteAllyFlowersPoints + RegisterClientsPoints;
        }
    }
}
