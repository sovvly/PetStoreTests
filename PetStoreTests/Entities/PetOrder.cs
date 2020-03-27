using System;

namespace PetStoreTests
{
    class PetOrder
    {
        private long id;
        private long petId;
        private int quantity;
        private DateTime shipDate;
        private string status;
        private bool complete;

        public PetOrder(long id, long petId, int quantity, DateTime shipDate, string status, bool complete)
        {
            this.id = id;
            this.petId = petId;
            this.quantity = quantity;
            this.shipDate = shipDate;
            this.status = status;
            this.complete = complete;
        }
    }
}
