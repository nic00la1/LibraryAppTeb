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
            if (int.TryParse(borrowEntry.Text, out int bookId))
            {
                if (books.ContainsKey(bookId))
                {
                    if (books[bookId].Quantity > 0)
                    {
                        books[bookId] = (books[bookId].Title, books[bookId].Quantity - 1);
                        DisplayAlert("Dziękujemy", $"Wypożyczono książkę: {books[bookId].Title}. Życzymy miłego czytania!", "OK");
                    }
                    else
                    {
                        DisplayAlert("Brak!", "Nie mamy tej książki dostępnej w bibliotece.", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error!", "Nieprawidłowe ID książki.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error!", "Niepoprawna wartość. Proszę wpisać liczby.", "OK");
            }
        }

        private void OnReturnButtonClicked(object sender, EventArgs e)
        {
            if (int.TryParse(returnEntry.Text, out int bookId))
            {
                if (books.ContainsKey(bookId))
                {
                    books[bookId] = (books[bookId].Title, books[bookId].Quantity + 1);
                    DisplayAlert("Dziękujemy", $"Dziękujemy za zwrócenie nam książki: {books[bookId].Title}. Zapraszamy ponownie!", "OK");
                }
                else
                {
                    DisplayAlert("Error!", "Nie ma u nas książki o takim ID.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error!", "Niepoprawna wartość. Proszę wpisać liczby.", "OK");
            }
        }
    }

}
