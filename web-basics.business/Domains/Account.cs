using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
    public class Account
    {
        private readonly IMapper _mapper;
        private readonly data.Repositories.Account _repository;

        public Account(IConfiguration configuration)
        {
            _repository = new data.Repositories.Account(configuration);
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Account, ViewModels.Account>();
                cfg.CreateMap<ViewModels.Account, data.Entities.Account>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Account> Get()
        {
            var accounts = _repository.Get();
            return accounts.Select(account => _mapper.Map<data.Entities.Account, ViewModels.Account>(account));
        }

        public ViewModels.Account Create(ViewModels.Account accountModel)
        {
            data.Entities.Account acc = null;
            try
            {
                acc = _repository.Create(_mapper.Map<data.Entities.Account>(accountModel));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return _mapper.Map<ViewModels.Account>(acc);
        }

        public ViewModels.Account Update(ViewModels.Account accountModel)
        {
            data.Entities.Account changedAccount = null;
            try
            {
                changedAccount = _repository.Update(_mapper.Map<data.Entities.Account>(accountModel));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            accountModel = _mapper.Map<ViewModels.Account>(changedAccount);

            return accountModel;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}