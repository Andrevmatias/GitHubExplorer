using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    public class Page<T>
    {
        private readonly int _itemsPerPage;

        public IList<T> Itens { get; }
        public int Number { get; }
        public int TotalItems { get; }

        public int TotalPages 
        { 
            get 
            {
                return (int) Math.Ceiling((decimal)TotalItems / _itemsPerPage);
            } 
        }
        public bool IsLast
        {
            get
            {
                return Number == TotalPages;
            }
        }

        public Page(IList<T> itens, int number, int itemsPerPage, int totalItems)
        {
            Itens = itens;
            Number = number;
            _itemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}
