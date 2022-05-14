namespace BookStore.Models.Entities
{
    public class BaseModel
    {
    }
    public class BaseBook
    {
        public virtual int BookId { get; protected set; }
        public virtual string BookName { get; set; }
        public virtual int? Price { get; set; }
        public virtual string? BookDescr { get; set; }
        public virtual string? Supplier { get; set; }
        public virtual string? Publisher { get; set; }
        public virtual double? Weight { get; set; }//Length, Height, Weight
        public virtual double? Height { get; set; }
        public virtual double? Length { get; set; }
        public virtual double? Width { get; set; }
        public virtual int? PublishYear { get; set; }
        public BaseBook()
        {

        }
    }
    public class BaseAuthor
    {
        public virtual int AuthorId { get; protected set; }
        public virtual string AuthorName { get; set; }
        public virtual string? AuthorDescr { get; set; }
        public BaseAuthor()
        {

        }
    }
    public class BaseCategory
    {
        public virtual int CategoryId { get; protected set; }
        public virtual string CategoryName { get; set; }
        public BaseCategory()
        {

        }
    }
}
