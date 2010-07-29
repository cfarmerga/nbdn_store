using System;

namespace nothinbutdotnetstore.specs.utility
{
    public class Link<ItemType>
    {
        public static LinkFactory<ItemType> for_a(ItemType item)
        {
            return new LinkFactory<ItemType>(item);
        }
    }

    public class LinkFactory<ItemType>
    {
        private readonly ItemType item;

        public LinkFactory(ItemType item)
        {
            this.item = item;
        }

        public LinkChooser when(Func<ItemType, bool> criteria)
        {
            return new LinkChooser(criteria(item));
        }
    }

    public class LinkChooser
    {
        private readonly bool _criteria;
        private string url = string.Empty;

        public LinkChooser(bool criteria)
        {
            _criteria = criteria;
        }

        public object then(string url)
        {
            if (_criteria) this.url = url; 
        }

        public override string ToString()
        {
            return url;
        }
    }

   
}