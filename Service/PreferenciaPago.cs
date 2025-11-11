using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PreferenciaPago
    {
        public async Task<string> preferenciaPago(MercadoPagoRequest l)
        {
            MercadoPagoConfig.AccessToken = "";
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                         Title = "Compras",
                         Quantity = 1
,                        CurrencyId ="PEN",
                         UnitPrice = l.precioFinal
                    }
                },
                Payer = new PreferencePayerRequest
                {
                    Name = l.name,
                    Surname = l.lastname,
                    Email = l.email,
                    Identification = new MercadoPago.Client.Common.IdentificationRequest
                    {
                        Type = "DNI",
                        Number = l.numberdni
                    }
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "",
                    Failure = "",
                    Pending = ""
                },
                NotificationUrl = "",
                AutoReturn = "aporved",
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>
                    {
                        new PreferencePaymentMethodRequest
                        {
                            Id="pagoefectivo_atn",
                        },
                        new PreferencePaymentMethodRequest
                        {
                            Id ="bancaInternet"
                        }
                    },
                    ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>()
                }
            };
            var Client = new PreferenceClient();
            Preference preference = await Client.CreateAsync(request);

            // CONVIERTE EL OBJETEO PREFERENCE JSON
            string preferenceJSON = JsonConvert.SerializeObject(preference);
            return preferenceJSON;
        }
    }
}
