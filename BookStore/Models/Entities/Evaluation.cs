namespace BookStore.Models.Entities
{
    public class Evaluation
    {
        public virtual int EvalId { get; protected set; }
        public virtual string Content { get; set; }
        public virtual int Score { get; set; }
        public virtual string UserId { get; set; }
        public virtual Book Book { get; protected set; }
        public Evaluation()
        {
            this.Book= new Book();
        }
        public virtual void AddBook(Book book)
        {
            book.Evals.Add(this);
            this.Book=book;
        }
    }
}
