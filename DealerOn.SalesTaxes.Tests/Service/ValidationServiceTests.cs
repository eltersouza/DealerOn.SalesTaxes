using DealerOn.SalesTaxes.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerOn.SalesTaxes.Tests.Service
{
    public class ValidationServiceTests
    {
        [Theory()]
        [InlineData("1 Book at 12.49,1")]
        [InlineData("1 Music CD at 14.99,0")]
        [InlineData("1 Chocolate bar at 0.85,2")]
        public void Test_ValidateInputs_ShouldPass(string inputs)
        {
            Assert.True(ValidationService.ValidateSaleItem(inputs));
        }

        [Theory()]
        [InlineData("1 Book at 12.49")]
        [InlineData("1 Music CD at 14.99")]
        [InlineData("1 Chocolate bar at 0.85")]
        public void Test_ValidateInputs_ShouldFail(string inputs)
        {
            Assert.False(ValidationService.ValidateSaleItem(inputs));
        }
    }
}
