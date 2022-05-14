namespace BookStore.Models.Entities
{
    public class Author
    {
        public virtual int AuthorId { get; protected set; }
        public virtual string AuthorName { get; set; }
        public virtual string? AuthorDescr { get; set; }
#nullable enable
        public virtual IList<BaseBook>? Books { get; protected set; }
        public Author()
        {
            this.Books = new List<BaseBook>();
        }
        public virtual void AddBook(BaseBook book)
        {
            //book.Authors.Add(this);
            this.Books.Add(book);
        }
    }
}
