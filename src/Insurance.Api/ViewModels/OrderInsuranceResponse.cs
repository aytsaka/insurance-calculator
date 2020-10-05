namespace Insurance.Api.ViewModels
{
    public class OrderInsuranceResponse
    {
        public double InsuranceValue { get; set; }

        protected OrderInsuranceResponse()
        {
        }

        public OrderInsuranceResponse(double insuranceValue)
        {
            InsuranceValue = insuranceValue;
        }
    }
}