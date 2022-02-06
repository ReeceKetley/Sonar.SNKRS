using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonarSNKRS
{
    public class BuyProductResult
    {
        public AddToCartCode Code;
        public string Response;
        public Object Data;
        public BuyProductResult(AddToCartCode code, string response = "", Object data = null)
        {
            Code = code;
            Response = response;
            Data = data;
        }
    }
}
