using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ItemInterface
    {
        public List<ItemDTO> GetItemCodes();
        public string AddPriceChangeAndUpdateItem(PriceChangeDTO priceChangeDTO);
    }
}
