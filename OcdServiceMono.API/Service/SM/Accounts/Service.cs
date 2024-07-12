﻿using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.Lib.Interfaces;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace OcdServiceMono.API.Service.SM.Accounts
{
    public class Service : RepositoryBase<Models.Entities.SM.SM_Accounts>, SM.Accounts.IService
    {
        private readonly ReadDomainDbContext _readDbContext;
        private readonly WriteDomainDbContext _writeDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        public Service(ReadDomainDbContext readDbContext, WriteDomainDbContext writeDbContext, IDateTimeProvider dateTimeProvider, IUserProvider userService)
            : base(readDbContext, writeDbContext, dateTimeProvider, userService)
        {
            _readDbContext = readDbContext;
            _writeDbContext = writeDbContext;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }

        public async Task<List<Models.Entities.SM.SM_Accounts>> GetAllMenu()
        {
            return await _readDbContext.SM_Accounts.ToListAsync();
        }

        public async Task<Models.Entities.SM.SM_Accounts> CreateAcc(Models.Entities.SM.SM_Accounts model)
        {
            model.Id = Guid.NewGuid();
            model.PassWord = BCrypt.Net.BCrypt.HashPassword(model.PassWord);
            var result = await _writeDbContext.SM_Accounts.AddAsync(model);
            await _writeDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}