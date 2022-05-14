namespace BookStore.Models.Entities
{
    public class Category
    {
        public virtual int CategoryId { get; protected set; }
        public virtual string CategoryName { get; set; }
        public virtual IList<BaseBook>? Books { get; protected set; }
        public Category()
        {
            this.Books = new List<BaseBook>();
        }
        public virtual void AddBook(BaseBook book)
        {
            //book.Categories.Add(this);
            this.Books.Add(book);
        }
    }
}
