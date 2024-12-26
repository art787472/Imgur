using Imgur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imgur.Components
{
    internal class PaginationService
    {
        public int currentPage { get; set; } = 1;
        private int pageCount;
        private int pageRange;

        public PaginationService( int pageCount, int pageRange)
        {
            
            this.pageCount = pageCount;
            this.pageRange = pageRange;
        }
       
        public int ChangePage(PaginationAction action,Action<List<int>> newPagesCallback)
        {
            int newPage = 0;
            switch (action) 
            {
                case PaginationAction.Next:
                    newPage = currentPage + 1 > pageCount ? pageCount :  currentPage + 1;
                    break;
                case PaginationAction.Previous:
                    newPage = currentPage - 1 < 1 ? 1 : currentPage - 1;
                    break;
                case PaginationAction.Backward:
                    newPage = currentPage - 5 < 1 ? 1 : currentPage - 5;
                    break;
                case PaginationAction.Forward:
                    newPage = currentPage + 5 > pageCount ? pageCount : currentPage + 5;
                    break;
                

            }

            bool switchPage = CountRange(currentPage) != CountRange(newPage);
            currentPage = newPage;
            List<int> pages = null;
            if (switchPage)
            {
                var n = currentPage % pageRange == 0 ? (currentPage / pageRange - 1) : currentPage / pageRange;
                pages = Enumerable.Range(1 + n * pageRange, pageRange).ToList();
                pages = pages.TakeWhile(x => x < pageCount).ToList();

                newPagesCallback.Invoke(pages);

            }

            return currentPage;
        }

        private int CountRange(int currentPage)
        {
            var n = currentPage % pageRange == 0 ? (currentPage / pageRange - 1) : currentPage / pageRange;
            return n;
        }

        public int ChangePage(int newPage, Action<List<int>> newPagesCallback)
        {
            var switchPage = CountRange(currentPage) == CountRange(newPage);
            currentPage = newPage;
            List<int> pages = null;
            
                var n = currentPage % pageRange == 0 ? (currentPage / pageRange - 1) : currentPage / pageRange;
                pages = Enumerable.Range(1 + n * pageRange, pageRange).ToList();
                pages = pages.TakeWhile(x => x < pageCount).ToList();

            

            newPagesCallback.Invoke(pages);

            return currentPage;
        }
    }


}
