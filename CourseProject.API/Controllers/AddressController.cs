using CourseProject.Common.Dtos;
using CourseProject.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private  IAddressService _addressService { get; }

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAddress(AddressCreate addressCreate)
    {
       var id = await _addressService.CreateAddressAsync(addressCreate);
       return Ok(id);
    }
    
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateAddress(AddressUpdate addressUpdate)
    {
        await _addressService.UpdateAddressAsync(addressUpdate);
        return Ok();
    }
    
    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAddress(AddressDelete addressDelete)
    {
        await _addressService.DeleteAddressAsync(addressDelete);
        return Ok();
    }
    
    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetAddress(int id)
    {
        var address = await _addressService.GetAddressAsync(id);
        return Ok(new { address });
    }
    
    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetAddresses()
    {
        var addresses = await _addressService.GetAddressesAsync();
        return Ok(new { addresses });
    }
}