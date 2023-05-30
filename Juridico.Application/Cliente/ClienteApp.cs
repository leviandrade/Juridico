using AutoMapper;
using Juridico.Application.Cliente.Interfaces;
using Juridico.Domain.Cliente.Entities;
using Juridico.Domain.Cliente.Repositories;
using Juridico.Domain.Interfaces;
using Juridico.DTL.Cliente;
using Juridico.Infra.Data.Contexts;

namespace Juridico.Application.Cliente
{
    public sealed class ClienteApp : IClienteApp
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork<JuridicoContext> _unitOfWork;

        public ClienteApp
        (
            IMapper mapper,
            IUnitOfWork<JuridicoContext> unitOfWork,
            IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Adicionar(ClienteDTO cliente)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(cliente);
            _clienteRepository.Adicionar(oClienteEntity);
            await _unitOfWork.CommitAsync();

            return oClienteEntity.Id;
        }

        public async Task Atualizar(ClienteDTO cliente)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(cliente);
            _clienteRepository.Atualizar(oClienteEntity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<ClienteDTO>> Listar()
        {
            var lstClientes = await _clienteRepository.Listar();
            return _mapper.Map<List<ClienteDTO>>(lstClientes);
        }

        public async Task<ClienteDTO> ObterPorId(int id)
        {
            var oCliente = await _clienteRepository.ObterPorId(id);
            return _mapper.Map<ClienteDTO>(oCliente);
        }

        public async Task Remover(int id)
        {
            await _clienteRepository.Remover(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
