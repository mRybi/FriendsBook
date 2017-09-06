using System.Collections.Generic;

namespace FriendsBook.Core.Domain
{
    public class Gallery
    {
        private ISet<Photo> _photos = new HashSet<Photo>();

        public IEnumerable<Photo> Photo
        {
            get { return _photos; }
            set { _photos = new HashSet<Photo>(value); }
        }
    }
}