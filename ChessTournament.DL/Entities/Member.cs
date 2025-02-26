﻿using ChessTournament.DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Entities
{
    public class Member : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public DateTime Birthday { get; set; }
        public double Elo { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public Guid Salt { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
        public virtual ICollection<Matchup> MatchupsAsWhite { get; set; } = new List<Matchup>();
        public virtual ICollection<Matchup> MatchupsAsBlack { get; set; } = new List<Matchup>();
    }
}
