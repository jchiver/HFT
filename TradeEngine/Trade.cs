﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradeEngine
{
    public class Trade
    {
        public TradeAttributes TradeAttributes { get; set; }

        private Authentication.Session Session;

        //The deal reference from the most recent WO that was sent
        private String DealReference;

        public Trade (TradeAttributes tradeAttributes)
        {
            this.TradeAttributes = tradeAttributes;
        }

        public async void GetTradeConfirm(Authentication.Session session)
        {
            this.Session = session;

            RestCommands.Post Post = new RestCommands.Post();
            RestCommands.IGResponse<Model.Trading.TradeConfirmResponse> Response = await Post.Execute<Model.Trading.TradeConfirmResponse>(this.Session.BaseURL + "/confirms" + "/" + DealReference,Session ,RestCommands.Post.CommandType.Get, "1");

            Console.WriteLine(Response.Response.DealStatus);
        }

        public async void SendWorkingOrderRequest(Authentication.Session session)
        {
            this.Session = session;

            RestCommands.Post Post = new RestCommands.Post();
            RestCommands.IGResponse<Model.WorkingOrder.CreateWorkingOrderResponse> Response = await Post.Execute<Model.WorkingOrder.CreateWorkingOrderResponse>(this.Session.BaseURL +  "/workingorders/otc", Session, RestCommands.Post.CommandType.Post, "2", GetWorkingOrderRequestContent());

            DealReference = Response.Response.DealReference;
            Console.WriteLine(DealReference);
        }

        private Model.WorkingOrder.CreateWorkingOrderRequest GetWorkingOrderRequestContent()
        {
            Model.WorkingOrder.CreateWorkingOrderRequest Request = new Model.WorkingOrder.CreateWorkingOrderRequest();

            Request.CurrencyCode = TradeAttributes.CurrencyCode;
            Request.Direction = TradeAttributes.Direction;
            Request.Epic = TradeAttributes.Epic;
            Request.Expiry = TradeAttributes.Expiry;
            Request.ForceOpen = TradeAttributes.ForceOpen;
            Request.GoodTillDate = TradeAttributes.GoodTillDate;
            Request.GuaranteedStop = TradeAttributes.GuaranteedStop;
            Request.Level = TradeAttributes.Level; 
            Request.LimitDistance = TradeAttributes.LimitDistance;
            Request.LimitLevel = TradeAttributes.LimitLevel;
            Request.Size = TradeAttributes.Size;
            Request.StopDistance = TradeAttributes.StopDistance;
            Request.StopLevel = TradeAttributes.StopLevel;
            Request.TimeInForce = TradeAttributes.TimeInForce;
            Request.Type = TradeAttributes.Type;


            return Request;
        }

        //private List<String> GenerateCustomHTTPHeaders()
        //{
        //    List<String> TempStringList = new List<string>();

        //    //The  :: acts as the position to split the string when creating the custom headers
        //    TempStringList.Add("X-IG-API-KEY" + ":" + this.Session.API_Key);
        //    TempStringList.Add("VERSION" + ":" + "2");
        //    TempStringList.Add("X-SECURITY-TOKEN" + ":" + this.Session.X_SECURITY_TOKEN);
        //    TempStringList.Add("CST" + ":" + this.Session.CST);

        //    return TempStringList;
        //}
    }
}
