namespace WinLendingProject
{
    public struct Book
    {
        public int BookID;
        public string BookName;
        public string Author;
        public string Publisher;
        public string BookImage;

        public Book(int bookID, string bookName, string author, string publisher, string bookImage)
        {
            this.BookID = bookID;
            this.BookName = bookName;
            this.Author = author;
            this.Publisher = publisher;
            this.BookImage = bookImage;
        }
    }
}
