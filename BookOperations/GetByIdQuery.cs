using Fimple_Cohorts_Model_Kullanimi.DataAccess.Context;
using Fimple_Cohorts_Model_Kullanimi.Entities.Enums;

namespace Fimple_Cohorts_Model_Kullanimi.BookOperations
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BooksViewModel Handle(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
                throw new InvalidOperationException("İlgili id ile bir kitap bulunamadı.");

            BooksViewModel vm = new BooksViewModel();
            vm.Title = book.Title;
            vm.Genre=((Genre)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            return vm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}
