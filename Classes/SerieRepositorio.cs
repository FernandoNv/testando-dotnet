using System.Collections.Generic;
using DIO.Series.Interfaces;
namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> LISTA_SERIES = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            LISTA_SERIES[id] = entidade;
        }

        public void Exclui(int id)
        {
            LISTA_SERIES[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            LISTA_SERIES.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return LISTA_SERIES;
        }

        public int ProximoId()
        {
            return LISTA_SERIES.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return LISTA_SERIES[id];
        }
    }
}