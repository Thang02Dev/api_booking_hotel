using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.PaymentMethodRepositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        public Task<PaymentMethodViewModel> Create(PaymentMethodViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodViewModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentMethodViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodViewModel> Update(PaymentMethodViewModel model, int id)
        {
            throw new NotImplementedException();
        }
    }
}
