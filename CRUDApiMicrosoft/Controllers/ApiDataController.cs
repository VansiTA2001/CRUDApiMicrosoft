using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using CRUDApiMicrosoft.Models;

namespace CRUDApiMicrosoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ApiDataController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string sql = @"
                select OrderId, DateTime, ClientCode, StockCode, MarketSegment, BuySell, OrderType, RemainingQty, Quantity, Price, Exchange, Status, TradingAccount, Message from 
                dbo.tbl_OrderHistory";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Db_EzTrade4-clone");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost("SendOrder")]
        public JsonResult Post(OrderHistory OH)
        {
            string sql = $"insert into dbo.tbl_OrderHistory (DateTime, ClientCode, StockCode, MarketSegment, BuySell, OrderType, RemainingQty, Quantity, Price, Exchange, Status, TradingAccount, Message) values ('{DateTime.Now}', '{OH.ClientCode}', '{OH.StockCode}', '{OH.MarketSegment}', '{OH.BuySell}', '{OH.OrderType}', '{OH.RemainingQty.ToString()}', '{OH.Quantity.ToString()}', '{OH.Price.ToString()}', '{OH.Exchange}', '{OH.Status}', '{OH.TradingAccount}', '{OH.Message}')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Db_EzTrade4-clone");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {
                    myCommand.Parameters.AddWithValue("DateTime", OH.DateTime = DateTime.Now);
                    myCommand.Parameters.AddWithValue("ClientCode", OH.ClientCode);
                    myCommand.Parameters.AddWithValue("StockCode", OH.StockCode);
                    myCommand.Parameters.AddWithValue("MarketSegment", OH.MarketSegment);
                    myCommand.Parameters.AddWithValue("BuySell", OH.BuySell);
                    myCommand.Parameters.AddWithValue("OrderType", OH.OrderType);
                    myCommand.Parameters.AddWithValue("RemainingQty", OH.RemainingQty);
                    myCommand.Parameters.AddWithValue("Quantity", OH.Quantity);
                    myCommand.Parameters.AddWithValue("Price", OH.Price);
                    myCommand.Parameters.AddWithValue("Exchange", OH.Exchange);
                    myCommand.Parameters.AddWithValue("Status", OH.Status);
                    myCommand.Parameters.AddWithValue("TradingAccount", OH.TradingAccount);
                    myCommand.Parameters.AddWithValue("Message", OH.Message);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("them thanh cong");
        }
        [HttpPut("{OrderId}")]
        public JsonResult Put(int OrderId, OrderHistory OH)
        {
            string sql = @"update dbo.tbl_OrderHistory set DateTime =@DateTime, ClientCode=@ClientCode, StockCode=@StockCode, MarketSegment=@MarketSegment, BuySell=@BuySell, OrderType=@OrderType, RemainingQty=@RemainingQty, Quantity=@Quantity, Price=@Price, Exchange=@Exchange, Status=@Status, TradingAccount=@TradingAccount, Message=@Message where OrderId=@OrderId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Db_EzTrade4-clone");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {

                    myCommand.Parameters.AddWithValue("@OrderId", OrderId);
                    myCommand.Parameters.AddWithValue("@DateTime", OH.DateTime = DateTime.Now);
                    myCommand.Parameters.AddWithValue("@ClientCode", OH.ClientCode);
                    myCommand.Parameters.AddWithValue("@StockCode", OH.StockCode);
                    myCommand.Parameters.AddWithValue("@MarketSegment", OH.MarketSegment);
                    myCommand.Parameters.AddWithValue("@BuySell", OH.BuySell);
                    myCommand.Parameters.AddWithValue("@OrderType", OH.OrderType);
                    myCommand.Parameters.AddWithValue("@RemainingQty", OH.RemainingQty.ToString());
                    myCommand.Parameters.AddWithValue("@Quantity", OH.Quantity.ToString());
                    myCommand.Parameters.AddWithValue("@Price", OH.Price.ToString());
                    myCommand.Parameters.AddWithValue("@Exchange", OH.Exchange);
                    myCommand.Parameters.AddWithValue("@Status", OH.Status);
                    myCommand.Parameters.AddWithValue("@TradingAccount", OH.TradingAccount);
                    myCommand.Parameters.AddWithValue("@Message", OH.Message);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("update thanh cong");
        }
        [HttpDelete("{OrderId}")]
        public JsonResult Delete(int OrderId)
        {
            string sql = @"delete from dbo.tbl_OrderHistory where OrderId=@OrderId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Db_EzTrade4-clone");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {
           
                    myCommand.Parameters.AddWithValue("OrderId", OrderId);
                
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("xoa thanh cong");
        }
    }
}
