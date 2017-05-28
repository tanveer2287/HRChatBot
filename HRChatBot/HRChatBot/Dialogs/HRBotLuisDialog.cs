using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Luis;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using System.Text;
using System.Configuration;

namespace HRChatBot.Dialogs
{
    [LuisModel("51121885-aaa0-44c6-ac2a-b5328326c08f", "276a30a3abf9447fb9a5a07fb36c2743")]
    //[LuisModel("modelid", "subkey")]
    [Serializable]
    public class HRBotLuisDialog : LuisDialog<object>
    {
        public HRBotLuisDialog(params ILuisService[] services) : base(services)
        {
        }

        private async Task AfterCommonResponseHandled(IDialogContext context, IAwaitable<bool> result)
        {
            var messageHandled = await result;

            if (!messageHandled)
            {
                await context.PostAsync("I’m not sure what you want.");
            }

            context.Wait(MessageReceived);
        }





        //[LuisIntent("Greeting")]
        //public async Task Greeting(IDialogContext context, LuisResult result)
        //{
        //    await context.PostAsync(@"Hi,how may i help you");
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("Hi")]
        //public async Task Hi(IDialogContext context, LuisResult result)
        //{
        //    await context.PostAsync(@"Hi,how may i help you");
        //    context.Wait(MessageReceived);
        //}


        [LuisIntent("None")]
        [LuisIntent("")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            var cts = new CancellationTokenSource();
            await context.Forward(new GreetingsDialog(), GreetingDialogDone, await message, cts.Token);
        }

        private async Task GreetingDialogDone(IDialogContext context, IAwaitable<object> result)
        {
            var success = await result;
            if (success==null)
                await context.PostAsync("I'm sorry. I didn't understand you.");

            context.Wait(MessageReceived);
        }


        [LuisIntent("medical reimbursement")]
        public async Task Medical(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Please contact Vinod Apte medical reimbursement related queries .email-id :vinod_apte@jltgroup.com ,extension : 2664");
            context.Wait(MessageReceived);
        }

        [LuisIntent("paternity leave")]
        public async Task PaternityLeave(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(@"Please contact Zeenat Tezabwala for  paternity leave related queries .email-id :Zeenat_Tezabwala@JLTGROUP.COM ,extension : 2559");
            context.Wait(MessageReceived);
        }
      
    }
}