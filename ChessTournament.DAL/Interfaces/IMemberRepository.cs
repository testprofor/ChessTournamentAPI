﻿using ChessTournament.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DAL.Interfaces
{
    public interface IMemberRepository : IRepository<Guid, Member>
    {
        public Member GetMemberByPseudo(string pseudo);
        public Member GetMemberByEmail(string email);
    }
}
