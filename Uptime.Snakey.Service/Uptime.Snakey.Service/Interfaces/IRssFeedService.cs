using System;
using System.Collections.Generic;
using System.Text;
using Uptime.Snakey.BusinessDomain;

namespace Uptime.Snakey.Service.Interfaces
{
    public interface IRssFeedService
    {
        public IList<Feed> GetRssFeed();
    }
}
