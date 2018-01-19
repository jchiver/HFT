using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Console
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TradeEngine.Authentication.Session Session = new TradeEngine.Authentication.Session("ADemoUSer", "BlaBlaBla123!", "f18d6aa81e37f2c4701f1684b17b8fb7f7da8ec8", "https://demo-api.ig.com/gateway/deal");

            Session.Logon();

            TradeEngine.TradeAttributes tradeAttributes = new TradeEngine.TradeAttributes();

            tradeAttributes.CurrencyCode = "GBP";
            tradeAttributes.Direction = "BUY";
            tradeAttributes.Epic = "IX.D.DOW.DAILY.IP";
            tradeAttributes.GuaranteedStop = "false";
            tradeAttributes.Level = "26090";
            tradeAttributes.LimitDistance = "1";
            tradeAttributes.Size = "1";
            tradeAttributes.StopDistance = "50";
            tradeAttributes.Type = "STOP";


            TradeEngine.Trade tr = new TradeEngine.Trade(tradeAttributes);

            tr.SendWorkingOrderRequest(Session);

            tr.GetTradeConfirm(Session);

        }
    }
}
