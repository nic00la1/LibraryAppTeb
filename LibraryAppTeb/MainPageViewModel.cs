using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LibraryAppTeb
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Book> Books { get; set; }

        public MainPageViewModel()
        {
            Books = new ObservableCollection<Book>
                {
                    new Book { Id = 1, Title = "Potop - Henryk Sienkiewicz", Quantity = 2 },
                    new Book { Id = 2, Title = "Pan Tadeusz - Adam Mickiewicz", Quantity = 1 },
                    new Book { Id = 3, Title = "Zbrodnia i Kara - Fiodor Dostojewski", Quantity = 4 }
                };
        }

        public delegate void DisplayAlertHandler(string title, string message);
        public event DisplayAlertHandler DisplayAlertRequested;

        public void BorrowBook(string bookIdText)
        {
            if (int.TryParse(bookIdText, out int bookId))
            {
                var book = Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    if (book.Quantity > 0)
                    {
                        book.Quantity--;
                        OnPropertyChanged(nameof(Books));
                        DisplayAlertRequested?.Invoke("Dziękujemy", $"Wypożyczono książkę: {book.Title}. Życzymy miłego czytania!");
                    }
                    else
                    {
                        DisplayAlertRequested?.Invoke("Brak!", "Nie mamy tej książki dostępnej w bibliotece.");
                    }
                }
                else
                {
                    DisplayAlertRequested?.Invoke("Error!", "Nieprawidłowe ID książki.");
                }
            }
            else
            {
                DisplayAlertRequested?.Invoke("Error!", "Niepoprawna wartość. Proszę wpisać liczby.");
            }
        }

        public void ReturnBook(string bookIdText)
        {
            if (int.TryParse(bookIdText, out int bookId))
            {
                var book = Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    book.Quantity++;
                    OnPropertyChanged(nameof(Books));
                    DisplayAlertRequested?.Invoke("Dziękujemy", $"Dziękujemy za zwrócenie nam książki: {book.Title}. Zapraszamy ponownie!");
                }
                else
                {
                    DisplayAlertRequested?.Invoke("Error!", "Nie ma u nas książki o takim ID.");
                }
            }
            else
            {
                DisplayAlertRequested?.Invoke("Error!", "Niepoprawna wartość. Proszę wpisać liczby.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Book : INotifyPropertyChanged
    {
        private int _quantity;

        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
