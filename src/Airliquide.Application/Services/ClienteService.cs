using Airliquide.Contracts.Contracts;
using Airliquide.Contracts.Exceptions;
using Airliquide.Contracts.Interfaces;
using Airliquide.Domain.Entities;
using Airliquide.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airliquide.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IClienteUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(ClienteDto model)
        {
            try
            {
                var entity = _mapper.Map<Cliente>(model);
                
                await _unitOfWork.BeginTransactionAsync();

                await _repository.AddAsync(entity);

                await _repository.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<ClienteDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClienteDto>> ListAsync(Guid? id)
        {
            try
            {
                var result = await _repository.ListAsync();
                if (id != null)
                    result = result.Where(x => x.Id.Equals(id));
                
                return _mapper.Map<IEnumerable<ClienteDto>>(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<IEnumerable<ClienteDto>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var entity = await _repository.GetByIdAsync(id);

                if (entity != null)
                {
                    await _repository.DeleteAsync(entity);

                    await _repository.SaveChangesAsync();

                    await _unitOfWork.CommitTransactionAsync();
                }
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task UpdateAsync(ClienteDto model)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(model.Id);
                if (entity == null)
                    throw new BusinessException("Id inválido");

                entity.Idade = model.Idade;
                entity.Nome = model.Nome;

                await _unitOfWork.BeginTransactionAsync();

                await _repository.UpdateAsync(entity);

                await _repository.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch(BusinessException e)
            {
                throw;
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
