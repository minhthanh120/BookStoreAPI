namespace BookStore.Models.Entities
{
    public class Picture
    {
        public virtual int PictureId { get; set; }
        public virtual string PicturePath { get; set; }
        public virtual Book Book { get; set; }
        public Picture()
        {
            this.Book = new Book();
        }
        public virtual void AddBook(Book book)
        {
            this.Book= book;
        }
    }
}
