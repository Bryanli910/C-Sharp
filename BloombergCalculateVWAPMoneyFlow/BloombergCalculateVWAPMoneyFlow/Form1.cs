using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Bloomberg API Namespaces
using Element = Bloomberglp.Blpapi.Element;
using Event = Bloomberglp.Blpapi.Event;
using EventHandler = Bloomberglp.Blpapi.EventHandler;
using EventQueue = Bloomberglp.Blpapi.EventQueue;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;
using SessionOptions = Bloomberglp.Blpapi.SessionOptions;
using Subscription = Bloomberglp.Blpapi.Subscription;
using Request = Bloomberglp.Blpapi.Request; 


namespace BloombergCalculateVWAPMoneyFlow
{
    public partial class Form1 : Form
    {
        // Declaration of SessionOptions, Session and subscriptions object 
        Session session;
        SessionOptions sessionOptions;
        List<Subscription> subscriptions;

        // These variables hold the product of all the trades so far
        double totalPriceVolume;
        double totalVolume;
        double sumMF;
        List<double> prices;
        List<double> tickTestsResults;
        //This bool value will be used to set the y axis when plotting the first event
        bool firstPointY = true;
        public Form1()
        {
            InitializeComponent();
        }

        // Event handler for the session
        public void processBBEvent(Event eventObject, Session session)
        {
            //Only use the data coming in related to our subscription data
            if (eventObject.Type == Event.EventType.SUBSCRIPTION_DATA)
            {
                //Loop through the messages in the eventObject
                foreach (Message msg in eventObject)
                {
                    // Get only the messages that have the last trade price and size of last trade
                    if (msg.HasElement("LAST_TRADE") &&
                        msg.HasElement("SIZE_LAST_TRADE"))
                    {
                        // Obtain the topic of the message
                        string topic = (string)msg.CorrelationID.Object;
                        try
                        {
                            //Creates a new thread for getting the price of last trade
                            tbPrice.Invoke(new MethodInvoker(delegate
                            {
                                tbPrice.Text = (string)msg.GetElementAsString("LAST_TRADE");
                            }));
                            //Creates a new thread for getting volume or size of trade
                            tbVolume.Invoke(new MethodInvoker(delegate
                            {
                                tbVolume.Text = (string)msg.GetElementAsString("SIZE_LAST_TRADE");
                            })); // end of tvVolume.Invoke()
                            tbVWAP.Invoke(new MethodInvoker(delegate
                            {
                                String VWAP = calculateVWAP(Convert.ToDouble(msg.GetElementAsString("LAST_TRADE")),
                                                            Convert.ToDouble(msg.GetElementAsString("SIZE_LAST_TRADE")));
                                tbVWAP.Text = VWAP;
                                chtPrices.Series[1].Points.AddY(Convert.ToDouble(VWAP));
                            })); // end of tbVWAP.invoke()
                            chtPrices.Invoke(new MethodInvoker(delegate
                            {
                                double lastTradePrice = Convert.ToDouble(msg.GetElementAsString("LAST_TRADE"));
                                double myVolume = Convert.ToDouble(msg.GetElementAsString("SIZE_LAST_TRADE"));
                                if (firstPointY)
                                {
                                    //Set the Y axis range to the lastTradePrice-1 to lastTradePrice+1
                                    chtPrices.ChartAreas[0].AxisY.Minimum = lastTradePrice - 1;
                                    chtPrices.ChartAreas[0].AxisY.Maximum = lastTradePrice + 1;
                                    
                                    //It is no longer the first plotted point from here on out
                                    firstPointY = false;
                                }
                                //This will change the primary y axis scale if price is smaller than the minimum y axis
                                else if(lastTradePrice < chtPrices.ChartAreas[0].AxisY.Minimum)
                                    chtPrices.ChartAreas[0].AxisY.Minimum = lastTradePrice-0.01;

                                //This will change the primary y axis scale if price is smaller than the minimum y axis
                                else if(lastTradePrice > chtPrices.ChartAreas[0].AxisY.Maximum)
                                    chtPrices.ChartAreas[0].AxisY.Maximum = lastTradePrice+0.01;

                                // Get previous tickTest and price
                                double prevTick = tickTestsResults[tickTestsResults.Count - 1];
                                double prevPrice = prices[prices.Count - 1];
                                // Calculate the new sum of money flow with tickTest()
                                tickTest(lastTradePrice, myVolume, prevPrice, prevTick);
                                // Plot the money flow first to get the previous trade price
                                chtPrices.Series[2].Points.AddY(sumMF);

                                //Add the lastTradePrice to our prices list
                                prices.Add(lastTradePrice);
                                // Plot the last trade price
                                chtPrices.Series[0].Points.AddY(lastTradePrice);
                            })); //end of chtPrices.Invoke()
                        }
                        catch (Exception e)
                        {
                            // Send an error message to console 
                            System.Console.WriteLine("Error: " + e.ToString());
                        }
                    } // end if msg has both last trade and size
                } // end loop over Messages in the eventObject
            } // end if event type is subscription data
        } // end processBBEvent()

        private void btnStart_Click(object sender, EventArgs e)
        {
            bool result;
            // Create 2 string variables for the security and fields
            String security = tbSymbol.Text;
            String fields = "LAST_PRICE";

            //Initialize lists used
            prices = new List<double>();
            prices.Add(0);
            tickTestsResults = new List<double>();
            tickTestsResults.Add(0);

            // Create an instance of the SessionOptions object to hold the session parameters
            sessionOptions = new SessionOptions();

            // Set the session parameters in the SessionOptions object
            sessionOptions.ServerHost = "localhost";
            sessionOptions.ServerPort = 8194;

            // Create an instance of the Session object, passing the options and processBBEvent to it
            session = new Session(sessionOptions,
                      new Bloomberglp.Blpapi.EventHandler(processBBEvent));

            // Start the Session
            try
            {
                result = session.Start();
                
                //Display successful connection
                if (result)
                    lblAppStatus.Text = "Connection Successful!";

                // Open up the Market data Service
                result = session.OpenService("//blp/mktdata");

                // Create an instance of the new list of subscriptions
                subscriptions = new List<Subscription>();

                // Add a subscription. Create a new CorrelationID on the fly
                subscriptions.Add(new Subscription(security, fields, "",
                              new Bloomberglp.Blpapi.CorrelationID(security)));

                // Send out the subscriptions
                session.Subscribe(subscriptions);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An error has occurred starting the service!");
                lblAppStatus.Text = ("An error has occurred starting the service!");
            }
        } // end btnStart_Click()

        private void btnStop_Click(object sender, EventArgs e)
        {
            //Turn off subscription
            session.Unsubscribe(subscriptions);

            //Close the session
            session.Stop();

            //Clear text boxes
            tbPrice.Text = String.Empty;
            tbVolume.Text = String.Empty;
            
            //Reset the initial variables
            firstPointY = true;
            totalPriceVolume = 0;
            totalVolume = 0;
            sumMF = 0;
        } //end btnStop_Click()

        public string calculateVWAP(double price, double volume)
        {
            totalPriceVolume += price * volume;
            totalVolume += volume;

            return Convert.ToString(totalPriceVolume/totalVolume);
        } // end calculateVWAP()

        public void tickTest(double lastPrice, double volume, double previousPrice, double previousTick)
        {
            // This variable stores the lastPrice * volume
            double priceVolume = lastPrice * volume;

            // Conduct the tick test for positive money flow
            if (lastPrice > previousPrice)
                sumMF += priceVolume;
            // Conduct the tick test for negative money flow
            else if(lastPrice < previousPrice)
                sumMF += priceVolume*(-1);
            // Conduct the tick test for equal money flow
            else
            {
                // Checks if previous tick test was positive or negative
                if (previousTick > 0)
                    sumMF += priceVolume;
                else
                    sumMF += priceVolume*(-1);
            } // end tick test for equal money flow
        } // end tickTest()

    } // end of public partial class Form1
} // end of namespace BloombergCalculateVWAPMoneyFlow
