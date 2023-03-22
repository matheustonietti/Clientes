using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITruck.Models;
using Microsoft.EntityFrameworkCore;

namespace APITruck.Models
{  
    public class ClienteRepository : IClienteRepository
    {
        private readonly BaseContext _context;
        public ClienteRepository(BaseContext baseContext)
        {
            _context = baseContext;
        }

        public async Task<Cliente> Atualizar(string nome, Cliente obj)
        {           
            var objdb = await Buscar(nome);

            if(objdb == null)
            {
                throw new Exception($"Cliente Não Localizado.");
            }
            
            await Save();

            return (objdb);
        }

        public async Task<Cliente> Buscar(string nome)
        {
            var obj = await _context.Clientes.AsTracking().FirstOrDefaultAsync(x => x.Nome.ToLower().Contains(nome.ToLower()));
            if (obj == null)
            {
                throw new Exception("Cliente não localizado");
            }
            return obj;
        }

        public async Task Deletar(string nome)
        {
            var obj = await Buscar(nome);

            if (obj == null)
            {
                throw new Exception("Cliente não localizado");
            }

            _context.Clientes.Remove(obj);

            await Save();
        }

        public async Task<Cliente> Inserir(Cliente obj)
        {          
            _context.Clientes.Add(obj);

            await Save();

            return obj;
        }

        public async Task<List<Cliente>> Listar()
        {
            var caminhoes = await _context.Clientes.AsTracking().ToListAsync();

            return caminhoes;
        }

        private async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel Salvar Bando de dados.");
            }
        }
    }


}
