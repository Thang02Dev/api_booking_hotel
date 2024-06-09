using api_booking_hotel.ViewModels;

namespace api_booking_hotel.Repositories.PaymentMethodRepositories
{
    public interface IPaymentMethodRepository
    {
        Task<List<PaymentMethodViewModel>> GetAll();
        Task<PaymentMethodViewModel> GetById(int id);
        Task<PaymentMethodViewModel> Create(PaymentMethodViewModel model);
        Task<PaymentMethodViewModel> Update(PaymentMethodViewModel model, int id);
        Task<PaymentMethodViewModel> Delete(int id);
    }
}
