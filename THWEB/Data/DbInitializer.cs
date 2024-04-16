using Microsoft.EntityFrameworkCore;
using THWEB.Models;

namespace THWEB.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;
        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {
            _builder.Entity<Authors>(a =>
            {
                a.HasData(new Authors
                {
                    AuthorId = 00001,
                    FullName = "Akira Toriyama",
                }) ;
            });
            _builder.Entity<Publishers>(p =>
            {
                p.HasData(new Publishers
                {
                    PublisherId = 1,
                    Name="Kim Van Hoan",
                });
            });
            _builder.Entity<Books>(b =>
            {
                b.HasData(new Books
                {
                    BookId=1,
                    Title="Dragonball",
                    Description= " là bộ truyện nổi tiếng và phổ biến rộng rãi bậc nhất trên toàn thế giới là một trong những bộ manga được tiêu thụ nhiều nhất mọi thời đại. Nó được bán ở hơn 40 quốc gia và anime được phát sóng ở hơn 80 quốc gia. 42 tập tankōbon được sưu tầm của manga đã bán được hơn 160 triệu bản ở Nhật Bản và 260 triệu bản được bán trên toàn thế giới tính đến năm 2019[7] Nó đã có tác động đáng kể đến văn hóa đại chúng toàn cầu , được tham khảo và truyền cảm hứng cho nhiều nghệ sĩ, vận động viên, người nổi tiếng, nhà làm phim, nhạc sĩ và nhà văn trên khắp thế giới.",
                    IsRead=true,
                    Dateread= new DateTime(2024,04,16),
                    Rate=5,
                    Genre=1,
                    CoverUrl= "https://vn-test-11.slatic.net/p/0efaaf875db6cb29e98741f541540f79.jpg_1500x1500q80.jpg",
                    DateAdded= new DateTime(2024, 04, 16),
                    PublisherId=1,
                });
            });
            _builder.Entity<Book_Author>(ba =>
            {
                ba.HasData(new Book_Author
                {
                    Id=01,
                    AuthorId=00001,
                    BookId=1,
                });
            });
        }
    }
}
