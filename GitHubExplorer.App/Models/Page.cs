using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    /// <summary>
    /// Página de <c>T</c>
    /// </summary>
    /// <typeparam name="T">Tipo dos itens da página</typeparam>
    public class Page<T>
    {
        private readonly int _itemsPerPage;

        /// <summary>
        /// Itens da página
        /// </summary>
        public IList<T> Items { get; }
        /// <summary>
        /// Número da página
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Número total de itens sem paginação
        /// </summary>
        public int TotalItems { get; }
        /// <summary>
        /// Número total de páginas
        /// </summary>
        public int TotalPages 
        { 
            get 
            {
                return (int) Math.Ceiling((decimal)TotalItems / _itemsPerPage);
            } 
        }
        /// <summary>
        /// Indica se a página é a última disponível
        /// </summary>
        public bool IsLast
        {
            get
            {
                return Number == TotalPages;
            }
        }
        /// <summary>
        /// Construtor da página
        /// </summary>
        /// <param name="items">Itens da página</param>
        /// <param name="number">Número dapágina</param>
        /// <param name="itemsPerPage">Número de itens por página</param>
        /// <param name="totalItems">Total de itens sem paginação</param>
        public Page(IList<T> items, int number, int itemsPerPage, int totalItems)
        {
            _itemsPerPage = itemsPerPage;

            Items = items;
            Number = number;
            TotalItems = totalItems;
        }
    }
}
