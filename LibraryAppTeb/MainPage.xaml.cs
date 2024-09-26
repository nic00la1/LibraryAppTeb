namespace LibraryAppTeb
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<int, (string Title, int Quantity)> books;

        public MainPage()
        {
            InitializeComponent();
            InitializeBooks();
        }

        private void InitializeBooks()
        {
            books = new Dictionary<int, (string Title, int Quantity)>
                {
                    { 1, ("Potop - Henryk Sienkiewicz", 2) },
                    { 2, ("Pan Tadeusz - Adam Mickiewicz", 1) },
                    { 3, ("Zbrodnia i Kara - Fiodor Dostojewski", 4) }
                };
        }

        private void OnBorrowButtonClicked(object sender, EventArgs e)
        {
            if (int.TryParse(borrowEntry.Text, out int bookId) && books.ContainsKey(bookId))
            {
                if (books[bookId].Quantity > 0)
                {
                    books[bookId] = (books[bookId].Title, books[bookId].Quantity - 1);
                    DisplayAlert("Sukces", $"Wypożyczono książkę: {books[bookId].Title}", "OK");
                }
                else
                {
                    DisplayAlert("Błąd", "Brak dostępnych egzemplarzy tej książki.", "OK");
                }
            }
            else
            {
                DisplayAlert("Błąd", "Nieprawidłowe ID książki.", "OK");
            }
        }

        private void OnReturnButtonClicked(object sender, EventArgs e)
        {
            if (int.TryParse(returnEntry.Text, out int bookId) && books.ContainsKey(bookId))
            {
                books[bookId] = (books[bookId].Title, books[bookId].Quantity + 1);
                DisplayAlert("Sukces", $"Oddano książkę: {books[bookId].Title}", "OK");
            }
            else
            {
                DisplayAlert("Błąd", "Nieprawidłowe ID książki.", "OK");
            }
        }
    }

}
