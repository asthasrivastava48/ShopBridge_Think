using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }
       
        [HttpPost]
        public async Task<ActionResult> CreateItemAsync(CreateItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var discount = model.MaxPrice * model.DiscountPercent * 0.01f;
                    var discountPrice = model.MaxPrice - discount;
                    bool onSaleFlag = discountPrice > 0 ? true : false;
                    Item newItem = new Item
                    {
                        Name = model.Name,
                        Description = model.Description,
                        MaxPrice = model.MaxPrice,
                        DiscountPercent = model.DiscountPercent,
                        SellingPrice = discountPrice,
                        IsOnSale = onSaleFlag
                    };
                    await itemRepository.AddItem(newItem);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
        }

       
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll()
        {
            try
            {
                var item = await itemRepository.GetAll();
                return item;
            }
            catch(Exception e)
            {
                throw;
            }
          
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            try
            {
                var item = await itemRepository.GetItem(id);
                if (item == null)
                {
                    var result = NotFound("Record not found");
                    return NotFound("Record not found");
                }
                return item;
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                Item item = await itemRepository.GetItem(id);
                if (item == null)
                {
                    return NotFound("Record not found");
                }
                await itemRepository.DeleteItem(id);
                return Ok();
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.StackTrace);
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIteamAsync( int id,CreateItem model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Item item = await itemRepository.GetItem(id);
                    if (item == null)
                    {
                        return NotFound("Record not found");
                    }
                    var discount = model.MaxPrice * model.DiscountPercent * 0.01f;
                    var discountPrice = model.MaxPrice - discount;
                    bool onSaleFlag = discountPrice > 0 ? true : false;
                    item.Name = model.Name;
                    item.Description = model.Description;
                    item.DiscountPercent = model.DiscountPercent;
                    item.MaxPrice = model.MaxPrice;
                    item.SellingPrice = discountPrice;
                    item.IsOnSale = onSaleFlag;
                    await itemRepository.UpdateItem(item);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch(Exception e)
            {
                return BadRequest(e.StackTrace);
            }
           
        }
    }
}
