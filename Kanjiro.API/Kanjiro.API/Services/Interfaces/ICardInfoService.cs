﻿using Kanjiro.API.Models.Model;

namespace Kanjiro.API.Services.Interfaces
{
    public interface ICardInfoService
    {
        public Task<CardInfo> GetCardInfoById(int Id);
    }
}
