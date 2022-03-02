namespace Catalog.Client.Component.Model
{
    public class SelectedProductEventArgs:EventArgs
    {
        public int[] selectedItemIds { get; init; }

        public SelectedProductEventArgs(int[] selectedItemIds)
        {
            this.selectedItemIds = selectedItemIds;
        }


    }
}
