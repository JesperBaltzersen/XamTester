using System;

using TestFormsAsyncAwait.Models;

namespace TestFormsAsyncAwait.ViewModels
{
    public class ItemDetailViewModel : DataStoreViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
