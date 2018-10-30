using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        Checkout GetById(int id);
        void Add(Checkout model);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assedId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        Checkout GetLatestCheckout(int id);
        string GetCurrenCheckoutPatron(int assetId);
        bool IsCheckedOut(int id);

        void PlaceHold(int assetId, int libraryCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int assetId);
        void MarkFound(int assetId);
    }
}
