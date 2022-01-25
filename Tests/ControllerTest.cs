using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Models;
using Moq;
using WebApplication1.Controllers;
using StoreBL;

namespace Tests;

public class ControllerTest
{
    [Fact]  
    public void StoreControllerGetShouldGetAllStores()
    {
        var MockBL = new Mock<IBL>();
        MockBL.Setup(x => x.GetAllStores()).Returns(
            new List<Storefront>
            {
                new Storefront
                {
                    Address = "Universe",
                    Name = "Some Place"
                },
                new Storefront
                {
                    Name =  "Test Name",
                    Address = "Test Place"
                }
            }
            );
        var storeCtrller = new StoreController(MockBL.Object);
        var result = storeCtrller.Get();
        Assert.NotNull(result);
        Assert.IsType<List<Storefront>>(result);
    }
}
