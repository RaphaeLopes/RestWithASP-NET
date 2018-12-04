using System.Collections.Generic;
using System.Linq;
using RestWithASP_NET.Data.Converter;
using RestWithASP_NET.Data.VO;
using RestWithASP_NET.Model;

namespace RestWithASP_NET.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null) return new BookVO();

            return new BookVO
            {
                id = origin.id,
                title = origin.title,
                author = origin.author,
                price = origin.price,
                launchDate = origin.launchDate
            };
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return new Book();
            return new Book
            {
                id = origin.id,
                title = origin.title,
                author = origin.author,
                price = origin.price,
                launchDate = origin.launchDate
            };
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null) return new List<BookVO>();
             return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null) return new List<Book>();
             return origin.Select(item => Parse(item)).ToList();
        }
    }
}