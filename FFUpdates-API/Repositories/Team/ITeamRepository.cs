﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFUpdates_API.Models;

namespace FFUpdates_API.Repositories.Team
{
    public interface ITeamRepository
    {
        Task<List<Models.Team>> Get();

        Task<Models.Team> GetById(int id);

        Task<List<Models.Team>> GetFantasyTeams();

        Task<List<Models.Team>> GetNFLTeams();
    }
}
