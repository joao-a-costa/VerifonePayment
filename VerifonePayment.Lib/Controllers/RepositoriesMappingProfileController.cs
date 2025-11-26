using AutoMapper;
using VerifonePayment.Lib.Models;

namespace VerifonePayment.Lib.Controllers
{
    /// <summary>
    /// Controller for mapping repositories.
    /// </summary>
    public class RepositoriesMappingProfileController
    {
        public MapperConfiguration Configuration { get; private set; }

        public RepositoriesMappingProfileController()
        {
            CreateMapping();
        }

        private void CreateMapping()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                // ================================
                // ROOT RECEIPT MAPPING
                // ================================
                cfg.CreateMap<VerifoneSdk.Receipt, Receipt>()
                    .ReverseMap();

                // ================================
                // PAYMENT ROOT
                // ================================
                cfg.CreateMap<VerifoneSdk.Payment, Payment>()
                    .ForMember(dest => dest.TaxAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.Signature, opt => opt.Ignore())
                    .ForMember(dest => dest.RequestedAmounts, opt => opt.Ignore())
                    .ForMember(dest => dest.Receipts, opt => opt.Ignore())
                    .ForMember(dest => dest.PaymentAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.GratuityAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.FeesAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.CashbackAmount, opt => opt.Ignore())
                    .ForMember(dest => dest.CardInformation, opt => opt.Ignore())
                    .ForMember(dest => dest.Amounts, opt => opt.Ignore())
                    .ReverseMap();

                // ================================
                // SIMPLE VALUE OBJECTS
                // ================================
                //cfg.CreateMap<VerifoneSdk.Total, Total>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.Tax, Tax>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.Gratuity, Gratuity>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.Fees, Fees>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.Cashback, Cashback>().ReverseMap();
                cfg.CreateMap<VerifoneSdk.Donation, Donation>().ReverseMap();

                //cfg.CreateMap<VerifoneSdk.GratuityAmount, GratuityAmount>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.FeesAmount, FeesAmount>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.CashbackAmount, CashbackAmount>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.PaymentAmount, PaymentAmount>().ReverseMap();
                //cfg.CreateMap<VerifoneSdk.TaxAmount, TaxAmount>().ReverseMap();


                // ================================
                // EMV TAGS
                // ================================
                //cfg.CreateMap<VerifoneSdk.EmvTags, EmvTags>().ReverseMap();


                // ================================
                // CARD INFORMATION
                // ================================
                cfg.CreateMap<VerifoneSdk.CardInformation, CardInformation>().ReverseMap();


                // ================================
                // SIGNATURE
                // ================================
                //cfg.CreateMap<VerifoneSdk.Signature, Signature>().ReverseMap();


                // ================================
                // AMOUNTS
                // ================================
                //cfg.CreateMap<VerifoneSdk.Amounts, Amounts>().ReverseMap();

                //cfg.CreateMap<VerifoneSdk.RequestedAmounts, RequestedAmounts>().ReverseMap();


                // ================================
                // RECEIPTS ROOT
                // ================================
                //cfg.CreateMap<VerifoneSdk.Receipts, Receipts>().ReverseMap();

                // ================================
                // CUSTOMER RECEIPT SECTION
                // ================================
                //cfg.CreateMap<VerifoneSdk.CUSTOMER, CUSTOMER>().ReverseMap();

                // ================================
                // MERCHANT RECEIPT SECTION
                // ================================
                //cfg.CreateMap<VerifoneSdk.MERCHANT, MERCHANT>().ReverseMap();
            });
        }
    }
}