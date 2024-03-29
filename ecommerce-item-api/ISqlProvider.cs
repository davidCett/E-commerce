﻿
using System.Collections.Generic;

namespace ecommerce_item_api.Controllers
{
    public interface ISqlProvider<T>
    {
        IEnumerable<T> GetItems();
        void ReduceQuantity(string c8, string remove);
    }
}
