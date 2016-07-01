using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using FootballApi.Domain.Models;
using FootballApi.Domain.Repositories;

namespace FootballApi.Domain.Services
{
    public interface IAddGameResultService
    {
        void Add(GameResult gameResult);
    }

    public class AddGameResultService: IAddGameResultService
    {
        private readonly IAddGameResultUnitOfWork _unitOfWork;

        public AddGameResultService(IAddGameResultUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(GameResult gameResult)
        {
        }
    }
}