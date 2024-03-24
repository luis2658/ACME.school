namespace ACME.School.Service.Abstract
{
    public interface IPayment<IPaymentMethod>
    {
        Task<bool> MakePayment(IPaymentMethod PaymentMethod);
    }
}
