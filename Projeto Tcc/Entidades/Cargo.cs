using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projeto_Tcc.Repositorio.Repositorios;

namespace Projeto_Tcc.Entidades
{
    public class Cargo
    {
        public virtual int Id { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual string Descricao { get; set; }
    }

    public interface ICargoServico
    {
        void Salvar(Cargo cargo);
        void Excluir(int id);
        Cargo Pesquisar(int id);
        IList<Cargo> PesquisarTodos();
        IList<Cargo> PesquisarPorSetor(Setor setor);
        IList<Cargo> PesquisarPorDescricao(string descricao);
        IList<Cargo> PesquisarPorSetorDescricao(Setor setor, string descricao);
    }

    public class CargoServico : ICargoServico
    {
        private readonly ICargoRepositorio _cargoRepositorio;
        public CargoServico(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public void Salvar(Cargo cargo)
        {
            _cargoRepositorio.Salvar(cargo);
        }

        public void Excluir(int id)
        {
            _cargoRepositorio.Excluir(id);
        }

        public Cargo Pesquisar(int id)
        {
            return _cargoRepositorio.Pesquisar(id);
        }

        public IList<Cargo> PesquisarTodos()
        {
            return _cargoRepositorio.PesquisarTodos();
        }

        public IList<Cargo> PesquisarPorSetor(Setor setor)
        {
            return _cargoRepositorio.PesquisarPorSetor(setor);
        }

        public IList<Cargo> PesquisarPorDescricao(string descricao)
        {
            return _cargoRepositorio.PesquisarPorDescricao(descricao);
        }

        public IList<Cargo> PesquisarPorSetorDescricao(Setor setor, string descricao)
        {
            return _cargoRepositorio.PesquisarPorSetorDescricao(setor, descricao);
        }
    }
}
