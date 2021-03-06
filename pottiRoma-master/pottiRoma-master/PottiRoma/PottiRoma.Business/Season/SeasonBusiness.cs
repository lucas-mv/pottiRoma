﻿using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using PottiRoma.Utils.Constants;
using PottiRoma.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Season
{
    public static class SeasonBusiness
    {
        public static SeasonEntity GetCurrentSeason()
        {
            var season = SeasonRepository.Get().GetCurrentSeason();
            if(season == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.NO_SEASONS_REGISTERED);

            return season;
        }

        public static void InsertSeason(string name, DateTime startDate, DateTime endDate, bool isActive)
        {
            if(endDate < DateTime.Now || string.IsNullOrEmpty(name))
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.OBRIGATORY_DATA_MISSING);

            SeasonRepository.Get().InsertSeason(name, startDate, endDate, isActive);
        }

        public static SeasonEntity GetSeasonById(Guid seasonId)
        {
            return SeasonRepository.Get().GetSeasonById(seasonId);
        }
    }
}
