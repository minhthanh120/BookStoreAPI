namespace BookStore.Models.Entities
{
    public class Book
    {
        public virtual int BookId { get; protected set; }
        public virtual string BookName { get; set; }
        public virtual int Price { get; set; }
        public virtual string BookDescr { get; set; }
        public virtual string Supplier { get; set; }
        public virtual string Publisher { get; set; }
        public virtual double Weight { get; set; }//Length, Height, Weight
        public virtual double Height { get; set; }
        public virtual double Length { get; set; }
        public virtual double Width { get; set; }
        public virtual int PublishYear { get; set;}
        public virtual IList<Author>? Authors { get; protected set; }
        public virtual IList<Category>? Categories { get; protected set; }
        public virtual IList<Picture>? Pictures { get; protected set; }
        public virtual IList<Evaluation>? Evals { get; protected set; }
        public Book()
        {
            this.Authors = new List<Author>();
            this.Categories = new List<Category>();
            this.Pictures= new List<Picture>();
            this.Evals = new List<Evaluation>();
        }
        public virtual void AddAuthor(Author author)
        {
            this.Authors.Add(author);
        }
        public virtual void AddCategory(Category category)
        {
            this.Categories.Add(category);
        }
        public virtual void AddPicture(Picture picture)
        {
            this.Pictures.Add(picture);
        }
        public virtual void AddEval(Evaluation evaluation)
        {
            this.Evals.Add(evaluation);
        }
    }
}
