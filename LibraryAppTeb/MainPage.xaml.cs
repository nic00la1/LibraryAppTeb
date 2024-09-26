namespace LibraryAppTeb
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBorrowButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.BorrowBook(borrowEntry.Text);
            }
        }

        private void OnReturnButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.ReturnBook(returnEntry.Text);
            }
        }
    }
}