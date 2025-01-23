using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace RentalsProMobileV9.ViewModels
{
    public class AppObservableCollection<T> : ObservableCollection<T>
    {
        public AppObservableCollection() { }

        public AppObservableCollection(IEnumerable<T> collection) : base(collection) { }

        public AppObservableCollection(List<T> list) : base(list) { }

        public void ReloadData(IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            ReloadData(innerList =>
            {
                foreach (var item in items)
                {
                    innerList.Add(item);
                }
            });
        }

        public void ReloadData(Action<IList<T>> innerListAction)
        {
            if (innerListAction == null) throw new ArgumentNullException(nameof(innerListAction));

            Items.Clear();
            innerListAction(Items);
            NotifyCollectionChanged();
        }

        public async Task ReloadDataAsync(Func<IList<T>, Task> innerListAction)
        {
            if (innerListAction == null) throw new ArgumentNullException(nameof(innerListAction));

            Items.Clear();
            await innerListAction(Items);
            NotifyCollectionChanged();
        }

        private void NotifyCollectionChanged()
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
