﻿using hakaton.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace hakaton.aaa
{
    public class AuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Logiran()
        {
            return GetInfo().isLogiran;
        }
        public AuthInfo GetInfo()
        {
            string authToken = _httpContextAccessor.HttpContext.Request.Headers["vrijednost"];
            AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken
                .Include(x => x.Korisnik).SingleOrDefault(x => x.vrijednost == authToken);
            return new AuthInfo(autentifikacijaToken);
        }

    }
    public class AuthInfo
    {
        public AuthInfo(AutentifikacijaToken? autentifikacijaToken)
        {
            this.autentifikacijaToken = autentifikacijaToken;
        }

        [JsonIgnore]
        public Korisnici? korisnickiNalog => autentifikacijaToken?.Korisnik;
        public AutentifikacijaToken? autentifikacijaToken { get; set; }

        public bool isLogiran => korisnickiNalog != null;

    }
}

