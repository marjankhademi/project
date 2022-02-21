namespace Catalog.Client.Models
{
    public class TitleChangeEventArgs:EventArgs
    {
        public string? Title { get;  }
         public TitleChangeEventArgs(string title)
        {
            Title = title;
        }
    }
}
