using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITruck.Models;
using Microsoft.EntityFrameworkCore;

namespace APITruck.Models
{
    public interface IClienteRepository
    {
        Task<Cliente> Inserir(Cliente obj);
        Task Deletar(string nome);
        Task<Cliente> Buscar(string nome);
        Task<Cliente> Atualizar(string nome, Cliente obj);
        Task<List<Cliente>> Listar();

    }
}
