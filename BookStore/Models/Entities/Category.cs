namespace BookStore.Models.Entities
{
    public class Category
    {
        public virtual int CategoryId { get; protected set; }
        public virtual string CategoryName { get; set; }
        public virtual IList<Book>? Books { get; protected set; }
        public Category()
        {
            this.Books = new List<Book>();
        }
        public virtual void AddBook(Book book)
        {
            book.Categories.Add(this);
            this.Books.Add(book);
        }
    }
}
